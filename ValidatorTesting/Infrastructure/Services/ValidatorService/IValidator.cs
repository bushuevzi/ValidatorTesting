using System;
using System.Collections.Generic;

namespace ValidatorTesting.Infrastructure.Services.ValidatorService
{
    /// <summary>
    /// Валидатор данных
    /// </summary>
    public interface IValidator
    {
        /// <summary>
        /// Идентификатор валидатора
        /// </summary>
        int ValidatorId { get; set; }
        
        /// <summary>
        /// Разрешение за запуск валидатора
        /// </summary>
        Func<bool> CanExecute { get; set; }
        
        /// <summary>
        /// Валидация данных
        /// </summary>
        /// <returns>Коллекция уведомлений</returns>
        IEnumerable<Notification> Validate();
    }
}