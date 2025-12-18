using Entities.TableModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Validation
{
    public class EventValidation: AbstractValidator<Event>
    {
        public EventValidation()
        {
            RuleFor(e => e.Name).NotEmpty().WithMessage("Event name cannot be empty.")
                              .MaximumLength(250).WithMessage("Event name cannot exceed 250 characters.");
            RuleFor(e => e.Type).MaximumLength(250).WithMessage("Event name cannot exceed 250 characters.");
            RuleFor(e => e.Description).MaximumLength(250).WithMessage("Event name cannot exceed 250 characters.");
        }
    }
}
