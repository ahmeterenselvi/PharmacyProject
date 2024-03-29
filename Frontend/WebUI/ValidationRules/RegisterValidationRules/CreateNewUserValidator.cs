﻿using DtoLayer.RegisterDto;
using FluentValidation;
using System.Text.RegularExpressions;

namespace WebUI.ValidationRules.RegisterValidationRules
{
    public class CreateNewUserValidator : AbstractValidator<CreateNewUserDto>
    {
        public CreateNewUserValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Bir ad giriniz.")
                .Length(2, 255).WithMessage("Adınız 2 ile 255 karakter arasında olmalıdır.");

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Bir soy ad giriniz.")
                .Length(2, 255).WithMessage("Soyadınız 2 ile 255 karakter arasında olmalıdır.");

            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Bir kullanıcı adı giriniz.")
                .Length(3, 255).WithMessage("Kullanıcı adınız 3 ile 255 karakter arasında olmalıdır.");

            RuleFor(x => x.Mail)
                .NotEmpty().WithMessage("Bir mail adresi giriniz.")
                .EmailAddress().WithMessage("Geçerli bir mail adresi giriniz.");

            RuleFor(x => x.TurkishIdentityNumber)
                .Must(BeAValidTurkishIdentityNumber).When(x => !string.IsNullOrEmpty(x.TurkishIdentityNumber))
                .WithMessage("Geçerli bir Türkiye kimlik numarası giriniz.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Bir şifre giriniz.")
                .MinimumLength(8).WithMessage("Şifre en az 8 karakter olmalıdır.")
                .MaximumLength(255).WithMessage("Şifre en fazla 255 karakter olmalıdır.");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage("Şifrenizi tekrar giriniz.")
                .Equal(x => x.Password).WithMessage("Şifreler eşleşmiyor.");
        }

        private bool BeAValidTurkishIdentityNumber(string identityNumber)
        {
            Regex regex = new Regex(@"^\d{11}$");
            if (!regex.IsMatch(identityNumber))
            {
                return false;
            }

            int[] digits = identityNumber.Select(c => int.Parse(c.ToString())).ToArray();

            int sum = digits.Take(10).Sum();
            int tenthDigit = sum % 10;

            if (tenthDigit != digits[10])
            {
                return false;
            }

            return true;
        }
    }
}
