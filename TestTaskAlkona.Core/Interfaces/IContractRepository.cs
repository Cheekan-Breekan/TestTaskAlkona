using TestTaskAlkona.Core.Entities;

namespace TestTaskAlkona.Core.Interfaces;
public interface IContractRepository
{
    Task<int> CountContractsAsync(string searchFilter);
    Task<List<Contract>> GetContractsByFilterSortPagingAsync(string searchFilter, string sortOrder, int page, int tablePageSize);
    Task<bool> CreateContract(Contract contract);
}
