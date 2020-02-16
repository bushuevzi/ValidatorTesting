using System.Collections.Generic;
using System.Linq;

namespace ValidatorTesting.Infrastructure.Services.ValidatorService
{
    /// <summary>
    /// Сервис валидации данных
    /// </summary>
    public class ValidatorService : IValidatorService
    {
        private List<IValidator> _validators = new List<IValidator>();
        
        /// <summary>
        /// Добавление валидатора
        /// </summary>
        /// <param name="validator">Валидатор</param>
        public void AddValidator(IValidator validator)
        {
            if (!IsValidatorExist(validator))
            {
                _validators.Add(validator);
            }
        }

        /// <summary>
        /// Удаление валидатора
        /// </summary>
        /// <param name="validator">Валидатор</param>
        public void RemoveValidator(IValidator validator) =>
            _validators.RemoveAll(v => v.ValidatorId == validator.ValidatorId);

        /// <summary>
        /// Валидация данных через все зарегистрированные валидаторы
        /// </summary>
        /// <returns>Коллекция уведомлений</returns>
        public IEnumerable<Notification> Validate()
        {
            var notifications = new List<Notification>();
            foreach (var validator in _validators)
            {
                notifications.AddRange(validator.Validate());
            }

            return notifications;
        }

        /// <summary>
        /// Проверка зарегистирован ли валидатор
        /// </summary>
        /// <param name="validator">Валидатор</param>
        /// <returns></returns>
        private bool IsValidatorExist(IValidator validator) =>
            _validators.Any(v => v.ValidatorId == validator.ValidatorId);
    }
}