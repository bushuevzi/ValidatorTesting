using System.Collections.Generic;
using System.Threading.Tasks;

namespace ValidatorTesting.Infrastructure.Services.ValidatorService
{
    /// <summary>
    /// Сервис проверки данных. Предоставляет функционал объединения валидаторов, асинхронный запуск всех
    /// зарегистрированных валидаторов.
    /// </summary>
    public interface IValidationService
    {
        /// <summary>
        /// Добавление валидатора в коллекцию валидаторов сервиса.
        /// </summary>
        /// <param name="validator">Валидатор, который нужно добавить в сервис</param>
        void AddValidator(IValidator validator);

        /// <summary>
        /// Исключение валидатора из сервиса.
        /// </summary>
        /// <param name="validator">Валидатор, который нужно удалить из сервиса</param>
        void RemoveValidator(IValidator validator);

        /// <summary>
        /// Запускает проверку данных по добавленным правилам.
        /// </summary>
        /// <returns>Результаты проверки данных валидаторами.</returns>
        Task<IEnumerable<ValidationResult>> ValidateAsync();
    }
}