using App.Domain.Core.Customer.Contracts.AppServices;
using App.Domain.Core.Customer.Dtos;
using App.Domain.Core.Expert.Contracts.AppServices;
using App.Domain.Core.Expert.Dtos;
using App.EndPoint.Mvc.UI.Areas.Admin.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace App.EndPoint.Mvc.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class OrderController : Controller
    {
        private readonly IOrderAppService _orderAppService;
        private readonly IOrderStateAppService _orderStateAppService;
        private readonly ITenderAppService _tenderAppService;
        private readonly IMapper _mapper;

        public OrderController(IOrderAppService orderAppService,
            IOrderStateAppService orderStateAppService,
            ITenderAppService tenderAppService,
            IMapper mapper)
        {
            _orderAppService = orderAppService;
            _orderStateAppService = orderStateAppService;
            _tenderAppService = tenderAppService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(string keyWord, CancellationToken cancellationToken)
        {
            ViewBag.UserName = this.User.FindFirstValue(ClaimTypes.Name);
            var model = _mapper.Map<List<OrderViewModel>>(await _orderAppService.GetAll(keyWord));
            foreach (var item in model)
            {
                item.TendersCount = (await _tenderAppService.GetByOrder((int)item.Id)).Count;
            }
            return View(model);
        }

        public async Task<IActionResult> Create(CancellationToken cancellationToken)
        {
            ViewBag.UserName = this.User.FindFirstValue(ClaimTypes.Name);
            ViewBag.OrderStates = await _orderStateAppService.GetAll();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrderViewModel model, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var dto = _mapper.Map<OrderDto>(model);
                var result = await _orderAppService.Add(dto);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Edit(int id, CancellationToken cancellationToken)
        {
            ViewBag.UserName = this.User.FindFirstValue(ClaimTypes.Name);
            ViewBag.OrderStates = await _orderStateAppService.GetAll();
            var model = _mapper.Map<OrderViewModel>(await _orderAppService.Get(id));
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(OrderViewModel model, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var dto = _mapper.Map<OrderDto>(model);
                await _orderAppService.Update(dto);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Tenders(int id, CancellationToken cancellationToken)
        {
            OrderTenderViewModel model = new();
            model.Order = _mapper.Map<OrderViewModel>(await _orderAppService.Get(id));
            model.Tenders = _mapper.Map<List<TenderViewModel>>(await _tenderAppService.GetByOrder(id));
            return View(model);
        }

        public async Task<IActionResult> AddTender(int id, CancellationToken cancellationToken)
        {
            ViewBag.UserName = this.User.FindFirstValue(ClaimTypes.Name);
            ViewBag.OrderStates = await _orderStateAppService.GetAll();
            TenderViewModel model = new TenderViewModel { OrderId = id };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddTender(TenderViewModel model, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var dto = _mapper.Map<TenderDto>(model);
                var result = await _tenderAppService.Add(dto);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            await _orderAppService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> DeleteTender(int id, CancellationToken cancellationToken)
        {
            await _tenderAppService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
