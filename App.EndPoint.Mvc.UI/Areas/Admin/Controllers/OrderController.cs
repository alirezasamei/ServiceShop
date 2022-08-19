using App.Domain.Core.BaseData.Contracts.AppServices;
using App.Domain.Core.BaseData.Enums;
using App.Domain.Core.Customer.Contracts.AppServices;
using App.Domain.Core.Customer.Dtos;
using App.Domain.Core.Customer.Enums;
using App.Domain.Core.Expert.Contracts.AppServices;
using App.Domain.Core.Expert.Dtos;
using App.EndPoint.Mvc.UI.Models;
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
        private readonly IUserAppService _userAppService;
        private readonly IMapper _mapper;
        private readonly ILogger<OrderController> _logger;

        public OrderController(IOrderAppService orderAppService,
            IOrderStateAppService orderStateAppService,
            ITenderAppService tenderAppService,
            IUserAppService userAppService,
            IMapper mapper,
            ILogger<OrderController> logger)
        {
            _orderAppService = orderAppService;
            _orderStateAppService = orderStateAppService;
            _tenderAppService = tenderAppService;
            _userAppService = userAppService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IActionResult> Index(string keyWord, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<List<OrderViewModel>>(await _orderAppService.GetAll(keyWord, cancellationToken));
            foreach (var item in model)
            {
                item.TendersCount = (await _tenderAppService.GetByOrder((int)item.Id, cancellationToken)).Count;
            }
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrderViewModel model, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var dto = _mapper.Map<OrderDto>(model);
                dto.OrderStateId = (int)OrderStateEnum.WaitingForTender;
                var id = await _orderAppService.Add(dto, cancellationToken);
                dto.Id = id;
                _logger.LogInformation("Order {orderDto} was added by {userRole}", dto, "admin");
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Edit(int id, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<OrderViewModel>(await _orderAppService.Get(id, cancellationToken));
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(OrderViewModel model, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var dto = _mapper.Map<OrderDto>(model);
                try
                {
                    await _orderAppService.Update(dto, cancellationToken);
                    _logger.LogInformation("Order {orderDto} was edited by {userRole}", dto, "admin");
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(String.Empty, ex.Message);
                }
            }
            return View();
        }

        public async Task<IActionResult> Tenders(int id, CancellationToken cancellationToken)
        {
            OrderTenderViewModel model = new();
            model.Order = _mapper.Map<OrderViewModel>(await _orderAppService.Get(id, cancellationToken));
            if (model.Order is null)
            {
                _logger.LogError("method {method} of appService {appService} returns null by orderId: {ordertId}",
                    "Get", nameof(IOrderAppService), id);
                ModelState.AddModelError(String.Empty, "there is no order with id: " + id);
            }
            model.Tenders = _mapper.Map<List<TenderViewModel>>(await _tenderAppService.GetByOrder(id, cancellationToken));
            return View(model);
        }

        public async Task<IActionResult> AddTender(int id, CancellationToken cancellationToken)
        {
            ViewBag.Experts = _mapper.Map<List<UserListViewModel>>(await _userAppService.GetByRole(RoleEnum.expert, cancellationToken));
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
                var id = await _tenderAppService.Add(dto, cancellationToken);
                dto.Id = id;
                _logger.LogInformation("Tender {tenderDto} was added by {userRole}", dto, "admin");
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            try
            {
                await _orderAppService.Delete(id, cancellationToken);
                _logger.LogInformation("Order with id: {orderId} was deleted by {userRole}", id, "admin");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message);
            }
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> DeleteTender(int id, CancellationToken cancellationToken)
        {
            try
            {
                await _tenderAppService.Delete(id, cancellationToken);
                _logger.LogInformation("Tender with id: {tenderId} was deleted by {userRole}", id, "admin");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
