using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
  public class TagValidator : AbstractValidator<Tag>
  {
    public TagValidator()
    {
      RuleFor(x => x.Id).NotNull();
      RuleFor(x => x.Name).MaximumLength(50);
    }
  }
}
