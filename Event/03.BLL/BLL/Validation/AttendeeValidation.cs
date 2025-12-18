using Entities.TableModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Validation
{
    public class AttendeeValidation: AbstractValidator<Attendee>
    {
        public AttendeeValidation()
        {
            RuleFor(d => d.Name).NotEmpty().WithMessage("Attendee name cannot be empty.")
                              .MaximumLength(250).WithMessage("Attendee name cannot exceed 250 characters.");
            RuleFor(d => d.Surname).MaximumLength(250).WithMessage("Surname name cannot exceed 250 characters.");                              
            RuleFor(d => d.Email).MaximumLength(250).WithMessage("Email name cannot exceed 250 characters.");
            
        }
    }
}
