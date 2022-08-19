using App.Domain.Core.BaseData.Contracts.Services;
using App.Domain.Core.Expert.Contracts.AppServices;
using App.Domain.Core.Expert.Contracts.Services;
using App.Domain.Core.Expert.Dtos;

namespace App.Domain.Services.Expert
{
    public class PastWorkAppService : IPastWorkAppService
    {
        private readonly IPastWorkService _pastWorkService;
        private readonly IUserService _userService;

        public PastWorkAppService(IPastWorkService pastWorkService,
            IUserService userService)
        {
            _pastWorkService = pastWorkService;
            _userService = userService;
        }
        public async Task<int> Add(PastWorkDto dto, CancellationToken cancellationToken)
        {
            var id = await _pastWorkService.Add(dto, cancellationToken);
            return id;
        }

        public async Task<int> Delete(int id, CancellationToken cancellationToken)
        {
            var entityId = await _pastWorkService.Delete(id, cancellationToken);
            return entityId;
        }

        public async Task<PastWorkDto?> Get(int id, CancellationToken cancellationToken)
        {
            var dto = await _pastWorkService.Get(id,  cancellationToken);
            return dto;
        }

        public async Task<List<PastWorkDto>> GetAll(CancellationToken cancellationToken)
        {
            var dtos = await _pastWorkService.GetAll( cancellationToken);
            return dtos;
        }

        public async Task<List<PastWorkDto>> GetByCustomerId(int id, CancellationToken cancellationToken)
        {
            int customerId = await _userService.ConvertUserIdToCustomerId(id, cancellationToken);
            var dtos = await _pastWorkService.GetByCustomerId(customerId, cancellationToken);
            return dtos;
        }

        public async Task<List<PastWorkDto>> GetByExpertId(int id, CancellationToken cancellationToken)
        {
            int expertId = await _userService.ConvertUserIdToExpertId(id, cancellationToken);
            var dtos = await _pastWorkService.GetByExpertId(expertId,  cancellationToken);
            return dtos;
        }

        public async Task<int> Update(PastWorkDto dto, CancellationToken cancellationToken)
        {
            var id = await _pastWorkService.Update(dto, cancellationToken);
            return id;
        }
    }
}
