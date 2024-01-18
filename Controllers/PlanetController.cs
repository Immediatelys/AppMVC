using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;



public class PlanetController : Controller
{
    private readonly PlanetService _planetService;
    public PlanetController(PlanetService planetService)
    {
        _planetService = planetService;
    }
    public IActionResult Index()
    {
        return View();  
    }


    [BindProperty(SupportsGet =true , Name = "action") ]
    public string Name { get; set; }

    public IActionResult Mercury()
    {
        var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
        return View("Detail", planet);
    }

     public IActionResult Venus()
    {
        var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
        return View("Detail", planet);
    }

     public IActionResult Earth()
    {
        var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
        return View("Detail", planet);
    }

    [Route("hanhtinh/{id:int}")]
    public IActionResult PlanetInfo(int id)
    {
        var planet = _planetService.Where(p => p.Id == id).FirstOrDefault();
        return View("Detail", planet);
    }

    
}