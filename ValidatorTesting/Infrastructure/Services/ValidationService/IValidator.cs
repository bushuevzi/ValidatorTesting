using System;
using System.Collections.Generic;

namespace ValidatorTesting.Infrastructure.Services.ValidatorService
{
    /// <summary>
    /// Инкапсулирует набор правил проверки данных даных. Выполняет валидацию по заданным правилам.
    /// </summary>
    public interface IValidator
    {
        /// <summary>
        /// Возвращает id валидатора. Может использоваться для исключения дублирования валидаторов в коллекциях.
        /// </summary>
        int ValidatorId { get; set; }
        
        /// <summary>
        /// Установка разрешения за запуск валидатора.
        /// </summary>
        Func<bool> CanExecute { get; set; }
        
        /// <summary>
        /// Применяет правила проверки данных.
        /// </summary>
        /// <returns>Коллекция, которая содержит описания проблем/ошибок.</returns>
        IEnumerable<ValidationResult> Validate();
    }
}