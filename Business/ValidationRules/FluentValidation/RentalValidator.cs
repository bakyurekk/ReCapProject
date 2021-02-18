﻿using Entities.Contract;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator:AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.CarId).NotEmpty();
            RuleFor(r => r.CustomerId).NotEmpty();
            RuleFor(r => r.ReturnDate).NotEmpty().When(r => r.ReturnDate != null).WithMessage("Araç Teslim Edilmemiştir");
        }
    }
}
