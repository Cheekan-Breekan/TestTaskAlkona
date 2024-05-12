using System.ComponentModel.DataAnnotations;

namespace TestTaskAlkona.MVC.Models;

public class CreateContractViewModel
{
    [Required]
    [Display(Name = "Номер договора")]
    public string Number { get; set; }
    public List<CreateContractItemsViewModel> Items { get; set; } = [];
}
