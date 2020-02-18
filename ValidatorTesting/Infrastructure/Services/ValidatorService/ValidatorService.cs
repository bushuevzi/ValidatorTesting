using System;
using System.Collections.Generic;
using System.Linq;

namespace ValidatorTesting.Infrastructure.Services.ValidatorService
{
    /// <summary>
    /// Сервис проверки данных, предоставляющий функционал объединения нескольких валидаторов и одновременной провеки.
    /// </summary>
    public class ValidatorService : IValidatorService
    {
        private List<IValidator> _validators = new List<IValidator>();
        
        /// <summary>
        /// Добавление валидатора в коллекцию валидаторов сервиса.
        /// </summary>
        /// <param name="validator">Добавляемый валидатор</param>
        public void AddValidator(IValidator validator)
        {
            if (validator == null) throw new ArgumentNullException(nameof(validator));
            if (!IsValidatorExist(validator))
            {
                _validators.Add(validator);
            }

            throw new ArgumentException(
                $"Валидатор {nameof(validator)} - {validator.ValidatorId} уже был добавлен в сервис ранее");
        }

        /// <summary>
        /// Исключение валидатора из сервиса.
        /// </summary>
        /// <param name="validator">Валидатор</param>
        public void RemoveValidator(IValidator validator)
        {
            if (validator == null) throw new ArgumentNullException(nameof(validator));
            _validators.RemoveAll(v => v.ValidatorId == validator.ValidatorId);
        }

        /// <summary>
        /// Валидация данных через все зарегистрированные валидаторы.
        /// </summary>
        /// <returns>Коллекция уведомлений</returns>
        // TODO: сделать асинхронно (см. IEnvoron....)
        public IEnumerable<ValidationNotification> Validate()
        {
            var notifications = new List<ValidationNotification>();
            foreach (var validator in _validators)
            {
                if (validator.CanExecute())
                {
                    // TODO: task
                    notifications.AddRange(validator.Validate());
                }
            }

            return notifications;
        }

        /// <summary>
        /// Проверка зарегистирован ли валидатор.
        /// </summary>
        /// <param name="validator">Валидатор</param>
        /// <returns></returns>
        private bool IsValidatorExist(IValidator validator)
        {
            if (validator == null) throw new ArgumentNullException(nameof(validator));
            return _validators.Any(v => v.ValidatorId == validator.ValidatorId);
        }
    }
}