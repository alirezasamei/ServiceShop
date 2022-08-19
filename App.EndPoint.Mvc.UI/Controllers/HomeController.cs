using App.Domain.Core.Service.Contracts.AppServices;
using App.EndPoint.Mvc.UI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics;
using System.Security.Claims;

namespace App.EndPoint.Mvc.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMemoryCache _memoryCache;
        private readonly IDistributedCache _distributedCache;
        private readonly IServiceAppService _serviceAppService;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger,
            IServiceAppService serviceAppService,
            IMapper mapper)
        {
            _logger = logger;
            _serviceAppService = serviceAppService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(int? id, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<List<ServiceViewModel>>(await _serviceAppService.GetByParentId(id, cancellationToken));
            if (!model.Any())
            {
                return RedirectToAction(nameof(Details), new { id = id });
            }
            return View(model);
        }

        public async Task<IActionResult> Search(string keyWord, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrEmpty(keyWord))
            {
                var model = _mapper.Map<List<ServiceViewModel>>(await _serviceAppService.GetAll(keyWord, cancellationToken));
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id, CancellationToken cancellationToken)
        {
            var parents = _mapper.Map<List<ServiceViewModel>>(await _serviceAppService.GetParentsByServiceId(id, cancellationToken));
            ViewBag.Parents = new SelectList(parents, "Id", "Name");
            var model = _mapper.Map<ServiceViewModel>(await _serviceAppService.Get(id, cancellationToken));
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}