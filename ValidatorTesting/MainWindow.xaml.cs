using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Autofac;
using ValidatorTesting.Data.DomainModels;
using ValidatorTesting.Data.Enums;
using ValidatorTesting.Infrastructure.IoC;
using ValidatorTesting.Infrastructure.Services.ValidatorService;
using ValidatorTesting.Infrastructure.Services.ValidatorService.Validators;
using ValidationResult = ValidatorTesting.Infrastructure.Services.ValidatorService.ValidationResult;

namespace ValidatorTesting
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly IValidationService _validatorService;
        private readonly IContainer _container;
        private readonly PersonsViewModel _persons;
        public List<ValidationResult> ValidationResults { get; set; } = new List<ValidationResult>();

        public MainWindow()
        {
            Loaded += MainWindow_Loaded;
            
            _container = AutofacInitializer.CreateContainer();
            _validatorService = _container.Resolve<IValidationService>();
            
            InitializeComponent();

            _persons = _container.Resolve<PersonsViewModel>();

//            foreach (var person in _persons)
//            {
//                var personAgeValidator = new PersonAgeValidator(person)
//                {
//                    // Не выполняем проверку на возраст если человека зовут Admin
//                    CanExecute = () => person.Name != "Admin"
//                };
//                var personNameValidator = new PersonNameValidator(person);
//                
//                _validatorService.AddValidator(personAgeValidator);
//                _validatorService.AddValidator(personNameValidator);
//
//            }
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            PersonGrid.ItemsSource = _persons.Persons;
            MessageCollector.ItemsSource = ValidationResults;
        }

        // TODO: Какое событие нужно обрабатывать чтобы оно запускалось при переходе между ячейками? Сейчас отрабатывает при смене строки.
        
        private async void personGrid_CellChanged(object sender, EventArgs eventArgs)
        {
            ValidationResults.Clear();
            ValidationResults.AddRange(await _validatorService.ValidateAsync());
            
            // TODO: Нормально ли такое "ручное обновление"?
            MessageCollector.Items.Refresh();
        }
        
        // Оттеняем вывод ошибок
        private void messageCollector_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            ValidationResult validationResult = e.Row.DataContext as ValidationResult;

            if (validationResult?.Severity == Severity.Error)
            {
                e.Row.Foreground = new SolidColorBrush(Colors.DarkRed);
                e.Row.FontWeight = FontWeights.Bold;
            }
        }
    }
}