using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityProject.PresentationLayer.ViewComponents.Customer
{
    public class _CustomerScriptLayoutPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
