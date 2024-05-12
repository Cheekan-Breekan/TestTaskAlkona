using System.ComponentModel.DataAnnotations;

namespace TestTaskAlkona.Core.Entities;
public class ContractItem
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public decimal Price { get; set; }
    public Contract Contract { get; set; }
}
