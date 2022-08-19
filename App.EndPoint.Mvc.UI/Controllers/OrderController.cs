using App.Domain.Core.Customer.Contracts.AppServices;
using App.Domain.Core.Customer.Dtos;
using App.Domain.Core.Expert.Contracts.AppServices;
using App.Domain.Core.Service.Contracts.AppServices;
using App.EndPoint.Mvc.UI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace App.EndPoint.Mvc.UI.Controllers
{
    [Authorize(Roles = "customer")]
    public class OrderController : Controller
    {
        private readonly IOrderAppService _orderAppService;
        private readonly IOrderStateAppService _orderStateAppService;
        private readonly ITenderAppService _tenderAppService;
        private readonly IServiceAppService _serviceAppService;
        private readonly IMapper _mapper;

        public OrderController(IOrderAppService orderAppService,
            IOrderStateAppService orderStateAppService,
            ITenderAppService tenderAppService,
            IServiceAppService serviceAppService,
            IMapper mapper)
        {
            _orderAppService = orderAppService;
            _orderStateAppService = orderStateAppService;
            _tenderAppService = tenderAppService;
            _serviceAppService = serviceAppService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(string keyWord, CancellationToken cancellationToken)
        {
            ViewBag.UserName = this.User.FindFirstValue(ClaimTypes.Name);
            int customerId = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var model = _mapper.Map<List<OrderViewModel>>(await _orderAppService.GetByCustomerId(customerId, keyWord, cancellationToken));

            foreach (var item in model)
            {
                item.TendersCount = (await _tenderAppService.GetByOrder((int)item.Id, cancellationToken)).Count;
            }
            return View(model);
        }

        public async Task<IActionResult> Create(int id, CancellationToken cancellationToken)
        {
            var customerId = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
            OrderDto dto = new()
            {
                CustomerId = customerId,
                ServiceId = id,
            };
            var orderId = await _orderAppService.Add(dto, cancellationToken);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Tenders(int id, CancellationToken cancellationToken)
        {
            var customerId = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
            OrderTenderViewModel model = new();
            model.Order = _mapper.Map<OrderViewModel>(await _orderAppService.Get(id, customerId, cancellationToken));
            model.Tenders = _mapper.Map<List<TenderViewModel>>(await _tenderAppService.GetByOrder(id, cancellationToken));
            model.Order.TendersCount = model.Tenders.Count;
            return View(model);
        }

        public async Task<IActionResult> AcceptTender(int id, CancellationToken cancellationToken)
        {
            var dto = await _tenderAppService.Accept(id, cancellationToken);
            return RedirectToAction(nameof(Tenders), new { id = dto.OrderId });
        }

        public async Task<IActionResult> CancelTender(int id, CancellationToken cancellationToken)
        {
            var dto = await _tenderAppService.Cancel(id, cancellationToken);
            return RedirectToAction(nameof(Tenders), new { id = dto.OrderId });
        }

        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var customerId = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
            try
            {
                await _orderAppService.Delete(id, customerId, cancellationToken);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}