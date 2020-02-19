using System;
using System.Collections.Generic;
using ValidatorTesting.Data.DomainModels;
using ValidatorTesting.Data.Enums;

namespace ValidatorTesting.Infrastructure.Services.ValidatorService.Validators
{
    public class PersonAgeValidator : IValidator
    {
        private readonly Person _target;

        public PersonAgeValidator(Person target)
        {
            _target = target;
            ValidatorId = this.GetHashCode();
        }

        public int ValidatorId { get; set; }
        public Func<bool> CanExecute { get; set; } = () => true;
        public IEnumerable<ValidationResult> Validate()
        {
            if (_target.Age <= 0 || _target.Age > 120)
            {
                yield return new ValidationResult
                {
                    Target =_target.GetType().Name,
                    Message = "Возраст должен быть больше 0 и меньше 120.",
                    Severity = Severity.Warning
                };
            }
        }
    }
}