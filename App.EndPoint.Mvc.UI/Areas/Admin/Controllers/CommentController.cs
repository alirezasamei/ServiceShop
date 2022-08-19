using App.Domain.Core.Expert.Contracts.AppServices;
using App.EndPoint.Mvc.UI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoint.Mvc.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class CommentController : Controller
    {
        private readonly ICommentAppService _commentAppService;
        private readonly IMapper _mapper;
        private readonly ILogger<CommentController> _logger;

        public CommentController(ICommentAppService commentAppService,
            IMapper mapper,
            ILogger<CommentController> logger)
        {
            _commentAppService = commentAppService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IActionResult> Index(string? keyWord, bool? isConfirmed, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<List<CommentViewModel>>(await _commentAppService.GetAll(keyWord, isConfirmed, cancellationToken));
            return View(model);
        }

        public async Task<IActionResult> ChangeConfirmState(int id, CancellationToken cancellationToken)
        {
            try
            {
                await _commentAppService.ChangeConfirmState(id, cancellationToken);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message);
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            try
            {
                await _commentAppService.Delete(id, cancellationToken);
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
