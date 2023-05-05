using EasyCashIdentityProject.DtoLayer.Dtos.AppUserDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.BusinessLayer.ValidationRules.AppUserValidationRules
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDto>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanı boş geçilmemelidir!");

            RuleFor(x => x.SurName).NotEmpty().WithMessage("Soyad alanı boş geçilmemelidir!");

            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı alanı boş geçilmemelidir!");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email alanı boş geçilmemelidir!");

            RuleFor(x => x.Passoword).NotEmpty().WithMessage("Şifre alanı boş geçilmemelidir!");

            RuleFor(x => x.ConfirmPassoword).NotEmpty().WithMessage("Şifre tekrar alanı boş geçilmemelidir!");

            RuleFor(x => x.Name).MaximumLength(30).WithMessage("Lütfen en fazla 30 karakter girişi yapın.");

            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Lütfen en az 30 karakter girişi yapın.");

            RuleFor(x => x.ConfirmPassoword).Equal(y => y.Passoword).WithMessage("Şifreleriniz eşleşmiyor");

            RuleFor(x => x.Email).EmailAddress().WithMessage("Lütfen geçerli bir mail adresi giriniz.");
        }
    }
}
