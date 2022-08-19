using App.Domain.Core.BaseData.Contracts.AppServices;
using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.Customer.Contracts.AppServices;
using App.Domain.Core.Expert.Contracts.AppServices;
using App.Domain.Core.Expert.Dtos;
using App.Domain.Core.Service.Contracts.AppServices;
using App.EndPoint.Mvc.UI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace App.EndPoint.Mvc.UI.Controllers
{
    public class ExpertController : Controller
    {
        private readonly ILogger<ExpertController> _logger;
        private readonly IUserAppService _userAppService;
        private readonly IExpertServiceAppService _expertServiceAppService;
        private readonly IServiceAppService _serviceAppService;
        private readonly IOrderAppService _orderAppService;
        private readonly ITenderAppService _tenderAppService;
        private readonly IPastWorkAppService _pastWorkAppService;
        private readonly IMapper _mapper;
        private readonly ICommentAppService _commentAppService;

        public ExpertController(ILogger<ExpertController> logger,
            IUserAppService userAppService,
            IExpertServiceAppService expertServiceAppService,
            IServiceAppService serviceAppService,
            IOrderAppService orderAppService,
            ITenderAppService tenderAppService,
            IPastWorkAppService pastWorkAppService,
            ICommentAppService commentAppService,
            IMapper mapper)
        {
            _logger = logger;
            _userAppService = userAppService;
            _expertServiceAppService = expertServiceAppService;
            _serviceAppService = serviceAppService;
            _orderAppService = orderAppService;
            _tenderAppService = tenderAppService;
            _pastWorkAppService = pastWorkAppService;
            _commentAppService = commentAppService;
            _mapper = mapper;
        }
        [Authorize(Roles = "expert")]
        public async Task<ActionResult> Index(CancellationToken cancellationToken)
        {
            int id = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var model = _mapper.Map<UserDetailViewModel>(await _userAppService.Get(id, cancellationToken));
            return View(model);
        }

        public async Task<IActionResult> Edit(CancellationToken cancellationToken)
        {
            int id = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var model = _mapper.Map<UserEditViewModel>(await _userAppService.Get(id, cancellationToken));
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserEditViewModel model, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var dto = _mapper.Map<AppUserDetailDto>(model);
                var result = await _userAppService.Update(dto, cancellationToken);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(String.Empty, item.Description);
                    }
                    return View(model);
                }
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditPicture(IFormFile? userImage, CancellationToken cancellationToken)
        {
            if (userImage == null)
                return RedirectToAction(nameof(Index));
            if (!userImage.ContentType.Contains("image"))
                ModelState.AddModelError(string.Empty, "فرمت عکس صحیح نیست.");
            if (ModelState.IsValid)
            {
                int id = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
                await _userAppService.UpdatePicture(id, userImage, cancellationToken);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<ActionResult> ExpertService(CancellationToken cancellationToken)
        {
            int id = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var model = new ExpertServiceEditViewModel();
            model.ExpertServices = _mapper.Map<List<ExpertServiceViewModel>>(await _expertServiceAppService.GetByExpertId(id, cancellationToken));
            model.Services = _mapper.Map<List<ServiceViewModel>>(await _serviceAppService.GetAll(null, cancellationToken))
                .Where(s => !model.ExpertServices.Any(es => es.ServiceId == s.Id)).ToList();
            foreach (var expertService in model.ExpertServices)
                expertService.CommentsCount = (await _commentAppService.GetByExpertServiceId((int)expertService.Id, null, cancellationToken)).Count;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddExpertService(int serviceId, CancellationToken cancellationToken)
        {
            int expertId = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
            await _expertServiceAppService.Add(expertId, serviceId, cancellationToken);
            return RedirectToAction(nameof(ExpertService));
        }

        public async Task<ActionResult> DeleteExpertService(int id, CancellationToken cancellationToken)
        {
            await _expertServiceAppService.Delete(id, cancellationToken);
            return RedirectToAction(nameof(ExpertService));
        }

        public async Task<ActionResult> Orders(CancellationToken cancellationToken)
        {
            int id = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var orders = _mapper.Map<List<OrderForExpertViewModel>>(await _orderAppService.GetByExpertId(id, cancellationToken));
            return View(orders);
        }

        public async Task<ActionResult> Tenders(CancellationToken cancellationToken)
        {
            int id = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var model = _mapper.Map<List<TenderWithOrderViewModel>>(await _tenderAppService.GetTendersAndOrdersByExpertId(id, cancellationToken));
            return View(model);
        }

        public ActionResult AddTender(int id)
        {
            var tender = new TenderViewModel() { OrderId = id };
            return View(tender);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddTender(TenderViewModel model, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                model.ExpertId = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
                await _tenderAppService.Add(_mapper.Map<TenderDto>(model), cancellationToken);
                return RedirectToAction(nameof(Orders));
            }
            return View();
        }

        public async Task<ActionResult> TenderDetail(int id, CancellationToken cancellationToken)
        {
            var tender = _mapper.Map<TenderViewModel>(await _tenderAppService.Get(id, cancellationToken));
            return View(tender);
        }

        public async Task<ActionResult> EditTender(int id, CancellationToken cancellationToken)
        {
            var tender = _mapper.Map<TenderViewModel>(await _tenderAppService.Get(id, cancellationToken));
            return View(tender);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditTender(TenderViewModel model, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                model.ExpertId = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
                await _tenderAppService.Add(_mapper.Map<TenderDto>(model), cancellationToken);
                return RedirectToAction(nameof(Tenders));
            }
            return View();
        }

        public async Task<ActionResult> DeleteTender(int id, CancellationToken cancellationToken)
        {
            await _tenderAppService.Delete(id, cancellationToken);
            return RedirectToAction(nameof(Tenders));
        }
        public async Task<ActionResult> WorkDone(int id, CancellationToken cancellationToken)
        {
            await _orderAppService.Done(id, cancellationToken);
            return RedirectToAction(nameof(Tenders));
        }

        public async Task<IActionResult> PastWorks(CancellationToken cancellationToken)
        {
            int id = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var model = _mapper.Map<List<PastWorkViewModel>>(await _pastWorkAppService.GetByExpertId(id, cancellationToken));
            return View(model);
        }

        public async Task<ActionResult> Comments(int id, string keyWord, CancellationToken cancellationToken)
        {
            var comments = _mapper.Map<List<CommentViewModel>>(await _commentAppService.GetByExpertServiceId(id, keyWord, cancellationToken));
            return View(comments);
        }
    }
}
