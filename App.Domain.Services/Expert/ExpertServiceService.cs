using App.Domain.Core.Expert.Contracts.Repositories;
using App.Domain.Core.Expert.Contracts.Services;
using App.Domain.Core.Expert.Dtos;

namespace App.Domain.Services.Expert
{
    public class ExpertServiceService : IExpertServiceService
    {
        private readonly IExpertServiceQueryRepository _expertServiceQueryRepository;
        private readonly IExpertServiceCommandRepository _expertServiceCommandRepository;

        public ExpertServiceService(IExpertServiceQueryRepository expertServiceQueryRepository,
            IExpertServiceCommandRepository expertServiceCommandRepository)
        {
            _expertServiceQueryRepository = expertServiceQueryRepository;
            _expertServiceCommandRepository = expertServiceCommandRepository;
        }
        public async Task<int> Add(ExpertServiceDto dto, CancellationToken cancellationToken)
        {
            var id = await _expertServiceCommandRepository.Add(dto, cancellationToken);
            return id;
        }

        public async Task<int> Delete(int id, CancellationToken cancellationToken)
        {
            var entityId = await _expertServiceCommandRepository.Delete(id, cancellationToken);
            return entityId;
        }

        public async Task<ExpertServiceDto?> Get(int id, CancellationToken cancellationToken)
        {
            var dto = await _expertServiceQueryRepository.Get(id, cancellationToken);
            return dto;
        }

        public async Task<List<ExpertServiceDto>> GetAll(CancellationToken cancellationToken)
        {
            var dtos = await _expertServiceQueryRepository.GetAll(cancellationToken);
            return dtos;
        }

        public async Task<List<ExpertServiceDto>> GetByExpertId(int id, CancellationToken cancellationToken)
        {
            var dtos = await _expertServiceQueryRepository.GetByExpertId(id, cancellationToken);
            return dtos;
        }

        public async Task<int> Update(ExpertServiceDto dto, CancellationToken cancellationToken)
        {
            var id = await _expertServiceCommandRepository.Update(dto, cancellationToken);
            return id;
        }
    }
}
