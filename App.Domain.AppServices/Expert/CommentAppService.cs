using App.Domain.Core.BaseData.Contracts.Services;
using App.Domain.Core.Expert.Contracts.AppServices;
using App.Domain.Core.Expert.Contracts.Services;
using App.Domain.Core.Expert.Dtos;
using Microsoft.Extensions.Logging;

namespace App.Domain.Services.Expert
{
    public class CommentAppService : ICommentAppService
    {
        private readonly ICommentService _commentService;
        private readonly IUserService _userService;
        private readonly ILogger<CommentAppService> _logger;

        public CommentAppService(ICommentService commentService,
            IUserService userService,
            ILogger<CommentAppService> logger)
        {
            _commentService = commentService;
            _userService = userService;
            _logger = logger;
        }
        public async Task<int> Add(CommentDto dto, CancellationToken cancellationToken)
        {
            dto.CustomerId = await _userService.ConvertUserIdToCustomerId(dto.CustomerId, cancellationToken);
            dto.SubmitDate = DateTime.Now;
            var id = await _commentService.Add(dto, cancellationToken);
            return id;
        }

        public async Task ChangeConfirmState(int id, CancellationToken cancellationToken)
        {
            var dto = await _commentService.Get(id, cancellationToken);
            if (dto is null)
            {
                _logger.LogError("method {method} of AppService {appService} is called by commentId: {wrongCommentId} that there is not in database",
                    nameof(ChangeConfirmState), nameof(CommentAppService), id);
                throw new Exception("there is no comment with id: " + id);
            }
            dto.IsConfirmed = !dto.IsConfirmed;
            await _commentService.Update(dto, cancellationToken);
            if (!dto.IsConfirmed)
                _logger.LogInformation("comment with id: {commentId} state changed to not confirmed", id);
        }

        public async Task<int> Delete(int id, CancellationToken cancellationToken)
        {
            var entityId = await _commentService.Delete(id, cancellationToken);
            return entityId;
        }

        public async Task<CommentDto?> Get(int id, CancellationToken cancellationToken)
        {
            var dto = await _commentService.Get(id, cancellationToken);
            return dto;
        }

        public async Task<CommentDto?> Get(string title, CancellationToken cancellationToken)
        {
            var dto = await _commentService.Get(title, cancellationToken);
            return dto;
        }

        public async Task<List<CommentDto>> GetAll(string? keyWord, bool? isConfirmed, CancellationToken cancellationToken)
        {
            var dtos = await _commentService.GetAll( cancellationToken);
            if (dtos.Count == 0)
                _logger.LogWarning("method {method} of service {service} returns empty collection", nameof(GetAll), nameof(ICommentService));
            dtos = Search(dtos, keyWord, isConfirmed);
            return dtos;
        }

        public async Task<List<CommentDto>> GetByExpertServiceId(int id, string keyWord, CancellationToken cancellationToken)
        {
            var dtos = (await _commentService.GetAll( cancellationToken)).Where(c => c.ExpertServiceId == id).ToList();
            dtos = Search(dtos, keyWord, true);
            return dtos;
        }

        public async Task<List<CommentDto>> GetByCustomerId(int id, string keyWord, CancellationToken cancellationToken)
        {
            var customerId = await _userService.ConvertUserIdToCustomerId(id, cancellationToken);
            var dtos = (await _commentService.GetAll( cancellationToken)).Where(c => c.CustomerId == customerId).ToList();
            dtos = Search(dtos, keyWord, true);
            return dtos;
        }

        public List<CommentDto> Search(List<CommentDto> dtos, string? keyWord, bool? isConfirmed)
        {
            if (isConfirmed != null)
                dtos = dtos.Where(d => d.IsConfirmed == isConfirmed).ToList();
            if (keyWord != null)
            {
                keyWord = keyWord.ToLower();
                dtos = dtos.Where(d => d.Expert.ToLower().Contains(keyWord) || d.Service.ToLower().Contains(keyWord) ||
                d.Title.ToLower().Contains(keyWord) || (string.IsNullOrEmpty(d.Text) ? false : d.Text.ToLower().Contains(keyWord))).ToList();

            }
            return dtos;
        }

        public async Task<int> Update(CommentDto dto, CancellationToken cancellationToken)
        {
            var id = await _commentService.Update(dto, cancellationToken);
            return id;
        }
    }
}
