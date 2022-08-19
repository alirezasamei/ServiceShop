using App.Domain.Core.Expert.Contracts.Repositories;
using App.Domain.Core.Expert.Contracts.Services;
using App.Domain.Core.Expert.Dtos;

namespace App.Domain.Services.Expert
{
    public class PastWorkService : IPastWorkService
    {
        private readonly IPastWorkCommandRepository _pastWorkCommandRepository;
        private readonly IPastWorkQueryRepository _pastWorkQueryRepository;

        public PastWorkService(IPastWorkCommandRepository pastWorkCommandRepository,
            IPastWorkQueryRepository pastWorkQueryRepository)
        {
            _pastWorkCommandRepository = pastWorkCommandRepository;
            _pastWorkQueryRepository = pastWorkQueryRepository;
        }
        public async Task<int> Add(PastWorkDto dto, CancellationToken cancellationToken)
        {
            var id = await _pastWorkCommandRepository.Add(dto, cancellationToken);
            return id;
        }

        public async Task<int> Add(int tenderId, DateTime complitionDate, CancellationToken cancellationToken)
        {
            var id = await _pastWorkCommandRepository.Add(tenderId, complitionDate, cancellationToken);
            return id;
        }

        public async Task<int> Delete(int id, CancellationToken cancellationToken)
        {
            var entityId = await _pastWorkCommandRepository.Delete(id, cancellationToken);
            return entityId;
        }

        public async Task<PastWorkDto?> Get(int id, CancellationToken cancellationToken)
        {
            var dto = await _pastWorkQueryRepository.Get(id, cancellationToken);
            return dto;
        }

        public async Task<List<PastWorkDto>> GetAll(CancellationToken cancellationToken)
        {
            var dtos = await _pastWorkQueryRepository.GetAll(cancellationToken);
            return dtos;
        }

        public async Task<List<PastWorkDto>> GetByCustomerId(int id, CancellationToken cancellationToken)
        {
            var dtos = await _pastWorkQueryRepository.GetByCustomerId(id, cancellationToken);
            return dtos;
        }

        public async Task<List<PastWorkDto>> GetByExpertId(int id, CancellationToken cancellationToken)
        {
            var dtos = await _pastWorkQueryRepository.GetByExpertId(id, cancellationToken);
            return dtos;
        }

        public async Task<int> Update(PastWorkDto dto, CancellationToken cancellationToken)
        {
            var id = await _pastWorkCommandRepository.Update(dto, cancellationToken);
            return id;
        }
    }
}
