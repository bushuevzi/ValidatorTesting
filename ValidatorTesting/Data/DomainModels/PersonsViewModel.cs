using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Autofac;
using ValidatorTesting.Infrastructure.IoC;
using ValidatorTesting.Infrastructure.Services.ValidatorService;
using ValidatorTesting.Infrastructure.Services.ValidatorService.Validators;

namespace ValidatorTesting.Data.DomainModels
{
    public class PersonsViewModel
    {
        private readonly IValidationService _validationService;
        public IEnumerable<Person> Persons { get; set; } = new ObservableCollection<Person>
        {
            new Person("Admin", 10),
            new Person("Ярл", 100),
            new Person("Ульфрик", 40)
        };

        public PersonsViewModel(IValidationService validationService)
        {
            _validationService = validationService;
            _validationService.AddValidator(new PersonsCollectionValidator(Persons));
        }
    }
}