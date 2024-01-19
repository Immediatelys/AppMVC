using App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Areas.Database.Controllers;

[Area("Database")]
[Route("/database-manage/[action]")]
public class DatabaseManageController : Controller
{

    private readonly AppDbContext _appContext;
    public DatabaseManageController(AppDbContext appContext)
    {
        _appContext = appContext;
    }
    public IActionResult Index()
    {
        return View();
    }

    [TempData]
    public string StatusMessage { get; set; }

    [HttpGet]
    public IActionResult Deletedb()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> DeletedbAsync()
    {

        var succes = await _appContext.Database.EnsureDeletedAsync();

        StatusMessage = succes ? "Delete successfully" : "Deletedb failed";
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Migrate()
    {
        await _appContext.Database.MigrateAsync();

        StatusMessage = "Update database successfully";
        return RedirectToAction(nameof(Index));
    }
}