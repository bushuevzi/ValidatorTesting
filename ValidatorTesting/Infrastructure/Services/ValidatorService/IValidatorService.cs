using System.Collections.Generic;

namespace ValidatorTesting.Infrastructure.Services.ValidatorService
{
    /// <summary>
    /// Сервис валидации данных
    /// </summary>
    public interface IValidatorService
    {
        /// <summary>
        /// Добавление валидатора
        /// </summary>
        /// <param name="validator">Валидатор</param>
        void AddValidator(IValidator validator);

        /// <summary>
        /// Удаление валидатора
        /// </summary>
        /// <param name="validator">Валидатор</param>
        void RemoveValidator(IValidator validator);

        /// <summary>
        /// Валидация данных через все зарегистрированные валидаторы
        /// </summary>
        /// <returns>Коллекция уведомлений</returns>
        IEnumerable<Notification> Validate();
    }
}