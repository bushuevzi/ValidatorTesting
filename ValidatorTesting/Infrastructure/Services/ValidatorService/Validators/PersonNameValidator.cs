using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ValidatorTesting.Data.DomainModels;
using ValidatorTesting.Data.Enums;

namespace ValidatorTesting.Infrastructure.Services.ValidatorService.Validators
{
    public class PersonNameValidator : IValidator
    {
        private readonly Person _target;

        public PersonNameValidator(Person target)
        {
            _target = target;
            ValidatorId = this.GetHashCode();
        }
        
        public int ValidatorId { get; set; }
        public Func<bool> CanExecute { get; set; } = () => true;
        public IEnumerable<Notification> Validate()
        {
            if (!CanExecute()) yield break;
            if (!Regex.IsMatch(_target.Name ?? "", @"^[A-Za-z]{2,30}"))
            {
                yield return new Notification
                {
                    ValidatedTarget =_target.GetType().Name,
                    Message = "Имя должно содержать буквенные литералы и быть больше 2 символов",
                    Severity = Severity.Fatal
                };
            }
        }
    }
}