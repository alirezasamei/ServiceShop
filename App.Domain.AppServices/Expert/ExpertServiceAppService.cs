using App.Domain.Core.BaseData.Contracts.Services;
using App.Domain.Core.Expert.Contracts.AppServices;
using App.Domain.Core.Expert.Contracts.Services;
using App.Domain.Core.Expert.Dtos;

namespace App.Domain.Services.Expert
{
    public class ExpertServiceAppService : IExpertServiceAppService
    {
        private readonly IExpertServiceService _expertServiceService;
        private readonly ICommentService _commentService;
        private readonly IUserService _userService;

        public ExpertServiceAppService(IExpertServiceService expertServiceService,
            ICommentService commentService,
            IUserService userService)
        {
            _expertServiceService = expertServiceService;
            _commentService = commentService;
            _userService = userService;
        }
        public async Task<int> Add(int expertId, int serviceId, CancellationToken cancellationToken)
        {
            expertId = await _userService.ConvertUserIdToExpertId(expertId, cancellationToken);
            var dto = new ExpertServiceDto
            {
                ExpertId = expertId,
                ServiceId = serviceId,
                CreationDate = DateTime.Now,
                IsActive = true,
            };
            var id = await _expertServiceService.Add(dto, cancellationToken);
            return id;
        }

        public async Task<int> Delete(int id, CancellationToken cancellationToken)
        {
            var entityId = await _expertServiceService.Delete(id, cancellationToken);
            return entityId;
        }

        public async Task<ExpertServiceDto?> Get(int id, CancellationToken cancellationToken)
        {
            var dto = await _expertServiceService.Get(id, cancellationToken);
            return dto;
        }

        public async Task<List<ExpertServiceDto>> GetAll(CancellationToken cancellationToken)
        {
            var dtos = await _expertServiceService.GetAll(cancellationToken);
            return dtos;
        }

        public async Task<List<ExpertServiceDto>> GetByExpertId(int id, CancellationToken cancellationToken)
        {
            var expertId = await _userService.ConvertUserIdToExpertId(id, cancellationToken);
            var dtos = await _expertServiceService.GetByExpertId(expertId, cancellationToken);
            return dtos;
        }

        public async Task<int> Update(ExpertServiceDto dto, CancellationToken cancellationToken)
        {
            var id = await _expertServiceService.Update(dto, cancellationToken);
            return id;
        }
    }
}
