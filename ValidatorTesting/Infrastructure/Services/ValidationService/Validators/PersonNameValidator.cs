using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ValidatorTesting.Data.DomainModels;
using ValidatorTesting.Data.Enums;

namespace ValidatorTesting.Infrastructure.Services.ValidatorService.Validators
{
    public class PersonNameValidator : BasicValidator
    {
        private readonly Person _target;

        public PersonNameValidator(Person target)
        {
            _target = target;
        }
        public override IEnumerable<ValidationResult> Validate()
        {
            if (!Regex.IsMatch(_target.Name ?? "", @"^\w{2,30}"))
            {
                yield return new ValidationResult
                {
                    Target =_target.GetType().Name,
                    Message = "Имя должно содержать буквенные литералы и быть больше 2 символов.",
                    Severity = Severity.Error
                };
            }
        }
    }
}