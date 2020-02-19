using System;
using System.Collections.Generic;

namespace ValidatorTesting.Infrastructure.Services.ValidatorService
{
    public abstract class BasicValidator : IValidator
    {
        public virtual Func<bool> CanExecute { get; set; } = () => true;
        public virtual IEnumerable<ValidationResult> Validate()
        {
            yield break;
        }
    }
}