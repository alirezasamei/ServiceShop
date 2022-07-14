using App.Domain.Core.Operator.Dtos;

namespace App.Domain.Core.Operator.Contracts.Repositories
{
    public interface IOperatorQueryRepository
    {
        Task<List<OperatorDto>> GetAll();
        Task<OperatorDto?> Get(int id);
        Task<OperatorDto?> Get(string name);
    }
}
