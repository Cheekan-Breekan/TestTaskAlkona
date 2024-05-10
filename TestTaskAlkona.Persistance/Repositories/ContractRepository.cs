﻿using Microsoft.EntityFrameworkCore;
using TestTaskAlkona.Core.Entities;
using TestTaskAlkona.Core.Interfaces;
using System.Data;
using System.Data.SqlClient;
using NpgsqlTypes;
using Npgsql;

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

    public async Task<bool> CreateContract(Contract contract)
    {
        await _db.Contracts.AddAsync(contract);

        return await _db.SaveChangesAsync() > 0;
    }

    public async Task<List<Contract>> GetContractsByFilterSortPagingAsync(string searchFilter, string sortOrder, int page, int tablePageSize)
    {
        var contractsQuery = _db.Contracts.AsQueryable();

        ApplySearchFilter(contractsQuery, searchFilter);
        ApplySorting(contractsQuery, sortOrder);

        var contracts = await contractsQuery.Skip((page - 1) * tablePageSize).Take(tablePageSize).ToListAsync();

        return contracts;
    }

    public async Task<Contract> GetContractByIdAsync(int contractId)
    {
        return await _db.Contracts.Include(c => c.ContractItems).FirstAsync(x => x.Id == contractId);
    }

    public async Task<decimal> GetContractSumByIdAsync(int contractId)
    {
        //decimal totalPrice = 0;
        //var sqlParameter = new NpgsqlParameter("@contract_id", NpgsqlDbType.Integer)
        //{
        //    Value = contractId
        //};
        //var t = _db.Database.SqlQueryRaw<decimal>("SELECT GetContractSumById(@contract_id)", sqlParameter).FirstOrDefault();
        //return t;
        return 0;
    }

    private static void ApplySorting(IQueryable<Contract> contractsQuery, string sortOrder)
    {
        contractsQuery = sortOrder switch
        {
            "number_desc" => contractsQuery.OrderByDescending(c => c.Number),
            "date" => contractsQuery.OrderBy(c => c.Date),
            "date_desc" => contractsQuery.OrderByDescending(c => c.Date),
            _ => contractsQuery.OrderBy(c => c.Number)
        };
    }

    private static void ApplySearchFilter(IQueryable<Contract> contractsQuery, string searchFilter)
    {
        if (!string.IsNullOrWhiteSpace(searchFilter))
        {
            contractsQuery = contractsQuery.Where(x => x.Number.Contains(searchFilter));
        }
    }
}
