using TestTaskAlkona.Core.Entities;
using TestTaskAlkona.Core.Interfaces;

namespace TestTaskAlkona.Application.Services;
public class ContractService : IContractService
{
    private readonly IContractRepository _repo;

    public ContractService(IContractRepository repo)
    {
        _repo = repo;
    }

    public async Task<int> CountContractsAsync(string searchFilter)
    {
        return await _repo.CountContractsAsync(searchFilter);
    }

    public async Task<List<Contract>> GetContractsByFilterSortPagingAsync(string searchFilter, string sortOrder, int page, int tablePageSize)
    {
        return await _repo.GetContractsByFilterSortPagingAsync(searchFilter, sortOrder, page, tablePageSize);
    }
}
