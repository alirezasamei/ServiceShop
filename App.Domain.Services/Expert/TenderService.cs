using App.Domain.Core.Expert.Contracts.Repositories;
using App.Domain.Core.Expert.Contracts.Services;
using App.Domain.Core.Expert.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<int> Add(TenderDto dto)
        {
            int id = await _tenderCommandRepository.Add(dto);
            return id;
        }

        public async Task<int> Delete(int id)
        {
            int entityId = await _tenderCommandRepository.Delete(id);
            return entityId;
        }

        public async Task<TenderDto?> Get(int id)
        {
            var dto = await _tenderQueryRepository.Get(id);
            return dto;
        }

        public async Task<List<TenderDto>> GetAll()
        {
            var dtos = await _tenderQueryRepository.GetAll();
            return dtos;
        }

        public async Task<int> Update(TenderDto dto)
        {
            int id = await _tenderCommandRepository.Update(dto);
            return id;
        }
    }
}
