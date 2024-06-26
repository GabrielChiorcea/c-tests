using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using FluentValidation;

namespace Application.Activities
{
    public class ActivtyValidator : AbstractValidator<Activity>
    {
        public ActivtyValidator()
        {
            RuleFor(el => el.Title).NotEmpty();
            RuleFor(el => el.City).NotEmpty();
            RuleFor(el => el.Category).NotEmpty();
            RuleFor(el => el.Description).NotEmpty();
            RuleFor(el => el.Venue).NotEmpty();
            RuleFor(el => el.Date).NotEmpty();


        }
    }
}