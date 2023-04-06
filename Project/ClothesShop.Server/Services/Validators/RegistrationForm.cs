using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesShop.Services.Models.Authentication;
using FluentValidation;

namespace ClothesShop.Services.Validators
{
    public class RegistrationForm : AbstractValidator<RegisterData>
    {
        public RegistrationForm() { 
            RuleFor(x=>x.Name)
                .NotEmpty();

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password)
                .MinimumLength(8)
                .NotEmpty();

            RuleFor(rm => rm.Phone)
               .NotEmpty()
               .Matches(@"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$");


        }
    }
}
