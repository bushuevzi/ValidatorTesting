using System;
using System.Collections.Generic;

namespace ValidatorTesting.Infrastructure.Services.ValidatorService
{
    /// <summary>
    /// Интерфейс типа, который обеспечивает проверку/валидацию определненных данных.
    /// </summary>
    public interface IValidator
    {
        /// <summary>
        /// Возвращение и задание идентификатор валидатора. Используется для работы с сервисом валидации (дублирование валидаторов в сервисе не допускается)
        /// </summary>
        int ValidatorId { get; set; }
        
        /// <summary>
        /// Установка разрешения за запуск валидатора.
        /// </summary>
        Func<bool> CanExecute { get; set; }
        
        /// <summary>
        /// Выполнение валидации данных.
        /// </summary>
        /// <returns>Коллекция уведомлений</returns>
        IEnumerable<ValidationNotification> Validate();
    }
}