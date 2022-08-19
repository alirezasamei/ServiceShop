using App.Domain.Core.Expert.Contracts.Repositories;
using App.Domain.Core.Expert.Contracts.Services;
using App.Domain.Core.Expert.Dtos;

namespace App.Domain.Services.Expert
{
    public class TenderService : ITenderService
    {
        private readonly ITenderQueryRepository _tenderQueryRepository;
        private readonly ITenderCommandRepository _tenderCommandRepository;

        public TenderService(ITenderQueryRepository tenderQueryRepository,
            ITenderCommandRepository tenderCommandRepository)
        {
            _tenderQueryRepository = tenderQueryRepository;
            _tenderCommandRepository = tenderCommandRepository;
        }

        public async Task<int> Add(TenderDto dto, CancellationToken cancellationToken)
        {
            int id = await _tenderCommandRepository.Add(dto, cancellationToken);
            return id;
        }

        public async Task<int> Delete(int id, CancellationToken cancellationToken)
        {
            int entityId = await _tenderCommandRepository.Delete(id, cancellationToken);
            return entityId;
        }

        public async Task<TenderDto?> Get(int id, CancellationToken cancellationToken)
        {
            var dto = await _tenderQueryRepository.Get(id, cancellationToken);
            return dto;
        }

        public async Task<List<TenderDto>> GetAll(CancellationToken cancellationToken)
        {
            var dtos = await _tenderQueryRepository.GetAll(cancellationToken);
            return dtos;
        }

        public async Task<List<TenderDto>> GetByOrder(int orderId, CancellationToken cancellationToken)
        {
            var dtos = (await _tenderQueryRepository.GetAll(cancellationToken)).Where(d => d.OrderId == orderId).ToList();
            return dtos;
        }

        public async Task<List<TenderDto>?> GetByExpertId(int id, CancellationToken cancellationToken)
        {
            var dtos = (await _tenderQueryRepository.GetAll(cancellationToken)).Where(d => d.ExpertId == id).ToList();
            return dtos;
        }

        public async Task<int> Update(TenderDto dto, CancellationToken cancellationToken)
        {
            int id = await _tenderCommandRepository.Update(dto, cancellationToken);
            return id;
        }
        public async Task<TenderDto> Accept(int id, CancellationToken cancellationToken)
        {
            var dto = await _tenderCommandRepository.Accept(id, cancellationToken);
            return dto;
        }
        public async Task<TenderDto> Cancel(int id, CancellationToken cancellationToken)
        {
            var dto = await _tenderCommandRepository.Cancel(id, cancellationToken);
            return dto;
        }
    }
}
