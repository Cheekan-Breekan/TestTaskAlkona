using Microsoft.EntityFrameworkCore;
using TestTaskAlkona.Core.Entities;

namespace TestTaskAlkona.Persistance;
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Contract> Contracts { get; set; }
    public DbSet<ContractItem> ContractItems { get; set; }
}
