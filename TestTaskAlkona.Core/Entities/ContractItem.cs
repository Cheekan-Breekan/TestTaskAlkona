namespace TestTaskAlkona.Core.Entities;
public class ContractItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Contract Contract { get; set; }
}
