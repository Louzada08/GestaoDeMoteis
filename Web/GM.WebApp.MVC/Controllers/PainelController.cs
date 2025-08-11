using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GM.WebApp.MVC.Controllers;

[Authorize]
public class PainelController : MainController
{
    //private readonly IPainelService _painelService;

    public PainelController()
    {
    }

    [HttpGet]
    [Route("")]
    public  IActionResult Index()
    {
        //var produtos = await _painelService.ObterTodos();
        return View();

       //return RedirectToAction("login", "Identidade");
    }

}