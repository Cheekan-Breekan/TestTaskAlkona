using Microsoft.EntityFrameworkCore;
using TestTaskAlkona.Core.Entities;
using TestTaskAlkona.Core.Interfaces;

namespace TestTaskAlkona.Persistance.Repositories;
public class ContractRepository : IContractRepository
{
    private readonly AppDbContext _db;

    public ContractRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<int> CountContractsAsync(string searchFilter)
    {
        return await _db.Contracts.CountAsync();
    }

    public async Task<List<Contract>> GetContractsByFilterSortPagingAsync(string searchFilter, string sortOrder, int page, int tablePageSize)
    {

        return [];
    }
}
