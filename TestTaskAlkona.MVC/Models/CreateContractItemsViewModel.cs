using System.ComponentModel.DataAnnotations;

namespace TestTaskAlkona.MVC.Models;

public class CreateContractItemsViewModel
{
    [Required]
    [Display(Name = "Наименование")]
    public string Name { get; set; }
    [Required]
    [Display(Name = "Цена")]
    public decimal Price { get; set; }
}
