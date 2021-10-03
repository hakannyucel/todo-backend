using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
  public class TodoValidator : AbstractValidator<Todo>
  {
    public TodoValidator()
    {
      RuleFor(x => x.Id).NotEmpty();
      RuleFor(x => x.Task).NotEmpty();
      RuleFor(x => x.CreatedDate).NotEmpty();

      RuleFor(x => x.Task).MaximumLength(50);
      RuleFor(x => x.Description).MaximumLength(1000);
      RuleFor(x => x.CreatedDate).NotEmpty();
    }
  }
}
