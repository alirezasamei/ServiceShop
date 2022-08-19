using App.Domain.Core.BaseData.Contracts.AppServices;
using App.EndPoint.Mvc.UI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoint.Mvc.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class FileController : Controller
    {
        private readonly IFileAppService _fileAppService;
        private readonly IMapper _mapper;
        private readonly ILogger<FileController> _logger;

        public FileController(IFileAppService fileAppService,
            IMapper mapper,
            ILogger<FileController> logger)
        {
            _fileAppService = fileAppService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IActionResult> Index(string? keyWord, CancellationToken cancellationToken)
        {
            List<FileViewModel> model;
            if (keyWord == null)
            {
                model = _mapper.Map<List<FileViewModel>>(await _fileAppService.GetAll(cancellationToken));
                if (model.Count == 0)
                    _logger.LogWarning("method {method} of appService {appService} returns empty collection", "GetAll", nameof(IFileAppService));
            }
            else
                model = _mapper.Map<List<FileViewModel>>(await _fileAppService.Search(keyWord, cancellationToken));
            return View(model);
        }

        public async Task<IActionResult> Details(string id, CancellationToken cancellationToken)
        {
            try
            {
                var model = _mapper.Map<FileViewModel>(await _fileAppService.Get(id, cancellationToken));
                return View(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message);
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
        {
            try
            {
                await _fileAppService.Delete(id, cancellationToken);
                _logger.LogInformation("comment with id: {commentId} was deleted by {userRole}", id, "admin");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
