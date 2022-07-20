using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Applicaion.Features.Orders.Commands.CreateOrder
{
    public class CreateNewOrderCommandValidator : AbstractValidator<CreateNewOrderCommand>
    {
        public CreateNewOrderCommandValidator()
        {
            RuleFor(p => p.UserId)
                .NotNull()
                .WithMessage("{UserId} Not Valid Fot Null Value");
            RuleFor(p => p.RequestPayId)
                .NotNull()
                 .WithMessage("{RequestPayId} Not Valid Fot Null Value"); ;
        
        }
    }
}
