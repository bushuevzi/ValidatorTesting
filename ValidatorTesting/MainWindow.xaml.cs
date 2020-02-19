﻿using System.Threading.Tasks;
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
        public Person Person { get; set; }
        
        public MainWindow()
        {
            _container = AutofacInitializer.CreateContainer();
            _validatorService = _container.Resolve<IValidationService>();
            
            InitializeComponent();
            
            // Создание модели и привязки ее к контексту главного окна
            Person = new Person();
            this.DataContext = Person;
            
            // Создание валидаторов и регистрация их в сервисе валидации
            var personAgeValidator = new PersonAgeValidator(Person)
            {
                // Не выполняем проверку на возраст если человека зовут Admin
                CanExecute = () => Person.Name != "Admin"
            };
            var personNameValidator = new PersonNameValidator(Person);
            _validatorService.AddValidator(personAgeValidator);
            _validatorService.AddValidator(personNameValidator);
        }

        private async void ValidateButton(object sender, RoutedEventArgs e)
        {
            var notifications = await _validatorService.ValidateAsync();
            MessageCollector.Text = string.Join("\n", notifications);
        }
    }
}