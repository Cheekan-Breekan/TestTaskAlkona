using System.ComponentModel.DataAnnotations;

namespace TestTaskAlkona.Core.Entities;
public class Contract
{
    public int Id { get; set; }
    [Required]
    public string Number { get; set; }
    [Required]
    public DateTime Date { get; set; }
    public List<ContractItem> ContractItems { get; set; } = [];
}
