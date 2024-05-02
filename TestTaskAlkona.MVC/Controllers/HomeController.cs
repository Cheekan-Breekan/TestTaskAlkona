using Microsoft.AspNetCore.Mvc;
using TestTaskAlkona.Core.Entities;
using TestTaskAlkona.Core.Interfaces;
using TestTaskAlkona.MVC.Extensions;
using TestTaskAlkona.MVC.Models;

namespace TestTaskAlkona.MVC.Controllers;
public class HomeController : Controller
{
    private readonly IContractService _contractService;
    private readonly int tablePageSize = 10;

    public HomeController(IContractService contractService)
    {
        _contractService = contractService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> FindContract(string sortOrder, string searchFilter, string currentFilter, int page = 1)
    {
        ViewBag.CurrentSortOrder = sortOrder;
        ViewBag.NameSortOrder = string.IsNullOrWhiteSpace(sortOrder) ? "number_desc" : string.Empty;
        ViewBag.IsDeletedSortOrder = sortOrder == "date" ? "date_desc" : "date";

        if (!string.IsNullOrWhiteSpace(searchFilter))
        {
            page = 1;
        }
        else
        {
            searchFilter = currentFilter;
        }
        ViewBag.CurrentSearchFilter = searchFilter;

        var contractsCount = await _contractService.CountContractsAsync(searchFilter);
        page = page < 1 ? 1 : page;
        var pager = new Pager(contractsCount, page, ControllerExt.NameOf<HomeController>(), nameof(Index), tablePageSize);

        ViewBag.Pager = pager;

        var contracts = await _contractService.GetContractsByFilterSortPagingAsync(searchFilter, sortOrder, page, tablePageSize);

        return View(contracts);
    }

    public IActionResult CreateContract()
    {
        return View(new Contract());
    }

    [HttpPost]
    public IActionResult CreateContract(Contract model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var result = _contractService.CreateContract(model);

        return RedirectToAction(nameof(FindContract));
    }

    public IActionResult ContractInfo()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View();
    }
}
