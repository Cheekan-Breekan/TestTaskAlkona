using System.ComponentModel.DataAnnotations;

namespace TestTaskAlkona.MVC.Models;

public class CreateContractItemsViewModel
{
    [Required]
    public string Name { get; set; }
    [Required]
    public decimal Price { get; set; }
}
