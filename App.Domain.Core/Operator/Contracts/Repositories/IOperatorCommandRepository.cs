using App.Domain.Core.Operator.Dtos;

namespace App.Domain.Core.Operator.Contracts.Repositories
{
    public interface IOperatorCommandRepository
    {
        Task<int> Add(OperatorDto dto);
        Task<int> Update(OperatorDto dto);
        Task<int> Delete(int id);
    }
}
