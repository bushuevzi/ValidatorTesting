using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Autofac;
using ValidatorTesting.Data.DomainModels;
using ValidatorTesting.Infrastructure.IoC;
using ValidatorTesting.Infrastructure.Services.ValidatorService;
using ValidatorTesting.Infrastructure.Services.ValidatorService.Validators;

namespace ValidatorTesting
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly IValidationService _validatorService;
        private readonly IContainer _container;
        private List<Person> _persons;

        public MainWindow()
        {
            _container = AutofacInitializer.CreateContainer();
            _validatorService = _container.Resolve<IValidationService>();
            
            InitializeComponent();
            
            // Создание модели и привязки ее к контексту главного окна
            _persons = new List<Person>
            {
                new Person("Admin", 10),
                new Person("Ян", 100),
                new Person("Захар", 25)
            };
          
            personsGrid.DataContext = _persons;
            
            _validatorService.AddValidator(new PersonsCollectionValidator(_persons));
            
            // Создание валидаторов и регистрация их в сервисе валидации
            foreach (var person in _persons)
            {
//                var personAgeValidator = new PersonAgeValidator(person)
//                {
//                    // Не выполняем проверку на возраст если человека зовут Admin
//                    CanExecute = () => person.Name != "Admin"
//                };
//                var personNameValidator = new PersonNameValidator(person);
//                
//                _validatorService.AddValidator(personAgeValidator);
//                _validatorService.AddValidator(personNameValidator);

            }
        }
        
        // TODO: при создании строки -- нужно создать и зарегистировать обработчик новый объект.
        

        private async void personGrid_MouseUp(object sender, EventArgs eventArgs)
        {
            var notifications = await _validatorService.ValidateAsync();
            MessageCollector.Text = string.Join("\n", notifications);
        }
    }
}