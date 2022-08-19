using App.Domain.Core.BaseData.Contracts.AppServices;
using App.Domain.Core.Expert.Contracts.AppServices;
using App.Domain.Core.Expert.Dtos;
using App.EndPoint.Mvc.UI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace App.EndPoint.Mvc.UI.Controllers
{
    [Authorize(Roles = "customer")]
    public class CustomerController : Controller
    {
        private readonly IUserAppService _userAppService;
        private readonly IPastWorkAppService _pastWorkAppService;
        private readonly ICommentAppService _commentAppService;
        private readonly IMapper _mapper;

        public CustomerController(IUserAppService userAppService,
            IPastWorkAppService pastWorkAppService,
            ICommentAppService commentAppService,
            IMapper mapper)
        {
            _userAppService = userAppService;
            _pastWorkAppService = pastWorkAppService;
            _commentAppService = commentAppService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            int id = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var model = _mapper.Map<UserDetailViewModel>(await _userAppService.Get(id, cancellationToken));
            return View(model);
        }

        public async Task<IActionResult> PastWorks(CancellationToken cancellationToken)
        {
            int id = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var model = _mapper.Map<List<PastWorkViewModel>>(await _pastWorkAppService.GetByCustomerId(id, cancellationToken));
            return View(model);
        }

        public async Task<IActionResult> Comments(string keyWord, CancellationToken cancellationToken)
        {
            int customerId = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var model = _mapper.Map<List<CommentViewModel>>(await _commentAppService.GetByCustomerId(customerId, keyWord, cancellationToken));
            return View(model);
        }

        public IActionResult AddComment(int id, CancellationToken cancellationToken)
        {
            int customerId = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var model = new CommentViewModel { ExpertServiceId = id, CustomerId = customerId };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddComment(CommentViewModel model, CancellationToken cancellationToken)
        {
            var dto = _mapper.Map<CommentDto>(model);
            await _commentAppService.Add(dto, cancellationToken);
            return RedirectToAction(nameof(PastWorks));
        }

        public async Task<IActionResult> DeleteComment(int id, CancellationToken cancellationToken)
        {
            await _commentAppService.Delete(id, cancellationToken);
            return RedirectToAction(nameof(Comments));
        }
    }
}
