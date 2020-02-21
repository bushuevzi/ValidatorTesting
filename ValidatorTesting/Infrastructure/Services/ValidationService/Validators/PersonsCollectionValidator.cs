using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using ValidatorTesting.Data.DomainModels;
using ValidatorTesting.Data.Enums;

namespace ValidatorTesting.Infrastructure.Services.ValidatorService.Validators
{
    public class PersonsCollectionValidator : BasicValidator
    {
        private readonly IEnumerable<Person> _target;

        public PersonsCollectionValidator(IEnumerable<Person> target)
        {
            _target = target;
        }

        public override IEnumerable<ValidationResult> Validate()
        {
            foreach (var person in _target)
            {
                if (!Regex.IsMatch(person.Name ?? "", @"^\w{2,30}"))
                {
                    yield return new ValidationResult
                    {
                        Target = typeof(Person).GetProperty("Name").ReflectedType.FullName,
                        Message = "Имя должно содержать буквенные литералы и быть больше 2 символов.",
                        Severity = Severity.Error
                    };
                }

                if (person.Age <= 0 || person.Age > 120)
                {
                    yield return new ValidationResult
                    {
                        Target = typeof(Person).GetProperty("Age").ReflectedType.FullName,
                        Message = "Возраст должен быть больше 0 и меньше 120.",
                        Severity = Severity.Warning
                    };
                }
            }
        }
    }
}