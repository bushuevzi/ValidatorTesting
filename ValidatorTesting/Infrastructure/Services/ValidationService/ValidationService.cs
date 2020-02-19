using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ValidatorTesting.Infrastructure.Services.ValidatorService
{
    /// <summary>
    /// Сервис проверки данных. Предоставляет функционал объединения валидаторов, асинхронный запуск всех
    /// зарегистрированных валидаторов.
    /// </summary>
    public class ValidationService : IValidationService
    {
        private List<IValidator> _validators = new List<IValidator>();
        
        /// <summary>
        /// Добавление валидатора в коллекцию валидаторов сервиса.
        /// </summary>
        /// <param name="validator">Валидатор, который нужно добавить в сервис</param>
        public void AddValidator(IValidator validator)
        {
            if (validator == null) throw new ArgumentNullException(nameof(validator));
            if (!IsValidatorExist(validator))
            {
                _validators.Add(validator);
            }
            else
            {
                throw new ArgumentException(
                    $"Валидатор {nameof(validator)} - {validator.ValidatorId} уже был добавлен в сервис ранее");
            }        
        }

        /// <summary>
        /// Исключение валидатора из сервиса.
        /// </summary>
        /// <param name="validator">Валидатор, который нужно удалить из сервиса</param>
        public void RemoveValidator(IValidator validator)
        {
            if (validator == null) throw new ArgumentNullException(nameof(validator));
            _validators.RemoveAll(v => v.ValidatorId == validator.ValidatorId);
        }

        /// <summary>
        /// Асинхронная проверка данных через все зарегистрированные валидаторы.
        /// </summary>
        /// <returns>Асинхронная задача, представляющая результаты проверки данных валидаторами</returns>
        public async Task<IEnumerable<ValidationResult>> ValidateAsync()
        {
            var notifications = new List<ValidationResult>();
            await Task.Run(() =>
                Parallel.ForEach(_validators, (validator) =>
                {
                    if(validator.CanExecute())
                    {
                        notifications.AddRange(validator.Validate());
                    }
                }));
                
            return notifications;
        }

        /// <summary>
        /// Проверка зарегистирован ли валидатор.
        /// </summary>
        private bool IsValidatorExist(IValidator validator)
        {
            if (validator == null) throw new ArgumentNullException(nameof(validator));
            return _validators.Any(v => v.ValidatorId == validator.ValidatorId);
        }
    }
}