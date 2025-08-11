using Microsoft.AspNetCore.Mvc;

namespace GM.WebApp.MVC.Extensions;

[ViewComponent(Name = "SummaryViewComponent")]
public class SummaryViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View("Default", TempData);
    }
}