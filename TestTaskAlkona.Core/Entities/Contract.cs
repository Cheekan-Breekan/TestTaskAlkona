namespace TestTaskAlkona.Core.Entities;
public class Contract
{
    public int Id { get; set; }
    public string Number { get; set; }
    public DateTime Date { get; set; }
    public List<ContractItem> ContractItems { get; set; } = [];
}
