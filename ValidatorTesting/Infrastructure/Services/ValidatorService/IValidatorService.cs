using System.Collections.Generic;

namespace ValidatorTesting.Infrastructure.Services.ValidatorService
{
    /// <summary>
    /// Сервис проверки данных, предоставляющий функционал объединения нескольких валидаторов и одновременной провеки.
    /// </summary>
    public interface IValidatorService
    {
        /// <summary>
        /// Добавление валидатора в сервис.
        /// </summary>
        /// <param name="validator">Валидатор</param>
        void AddValidator(IValidator validator);

        /// <summary>
        /// Удаление валидатора из сервиса.
        /// </summary>
        /// <param name="validator">Валидатор</param>
        void RemoveValidator(IValidator validator);

        /// <summary>
        /// Валидация данных через все зарегистрированные валидаторы.
        /// </summary>
        /// <returns>Коллекция уведомлений</returns>
        IEnumerable<ValidationNotification> Validate();
    }
}