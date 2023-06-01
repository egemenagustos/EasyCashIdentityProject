using EasyCashIdentityProject.DtoLayer.Dtos.AppUserDtos;
using EasyCashIdentityProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityProject.PresentationLayer.Controllers
{
    [Authorize]
    public class MyAccountsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public MyAccountsController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity!.Name);
            AppUserEditDto dto = new AppUserEditDto()
            {
                Name = values.Name,
                City = values.City,
                District = values.District,
                Email = values.Email,
                ImageUrl = values.ImageUrl, 
                SurName = values.SurName,
                UserName = values.UserName,
                PhoneNumber = values.PhoneNumber,
            };
            return View(dto);
        }
    }
}
