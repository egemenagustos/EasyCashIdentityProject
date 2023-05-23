using EasyCashIdentityProject.DtoLayer.Dtos.AppUserDtos;
using EasyCashIdentityProject.EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace EasyCashIdentityProject.PresentationLayer.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUserRegisterDto appUserRegisterDto)
        {
            if (ModelState.IsValid)
            {
                Random rnd = new Random();
                int confirmCode = rnd.Next(10000, 10000000);
                AppUser appUser = new()
                {
                    Name = appUserRegisterDto.Name,
                    SurName = appUserRegisterDto.SurName,
                    Email = appUserRegisterDto.Email,
                    UserName = appUserRegisterDto.UserName,
                    City = "sjkdjsd",
                    District = "sdjkklsdjksjd",
                    ImageUrl = "sdlslkdklsd",
                    ConfirmCode = confirmCode
                };
                var result = await _userManager.CreateAsync(appUser,appUserRegisterDto.Passoword);
                if (result.Succeeded)
                {
                    MimeMessage mimeMessage = new();
                    MailboxAddress mailboxAddress = new("Admin", "dfdfdfdf@gmail.com");
                    MailboxAddress mailboxAddressTo = new("user",appUser.Email);
                    mimeMessage.From.Add(mailboxAddress);
                    mimeMessage.To.Add(mailboxAddressTo);
                    var bodyBuilder = new BodyBuilder();
                    bodyBuilder.TextBody = "kayıt işlemi gerçekleştirmek için onay kodunuz :" + confirmCode;
                    mimeMessage.Body = bodyBuilder.ToMessageBody();
                    mimeMessage.Subject = "easy cash onay kodu";

                    SmtpClient client = new();
                    client.Connect("smtp.gmail.com",587,false);
                    client.Authenticate("dffddffdfd@gmail.com", "fdfdfdfdfd");
                    client.Send(mimeMessage);
                    client.Disconnect(true);

                    TempData["Mail"] = appUser.Email;

                    return RedirectToAction("Index","ConfirmMail");
                }
                else
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError("",error.Description);
                    }
                    return View();
                }
            }
            return View();
        }
    }
}
