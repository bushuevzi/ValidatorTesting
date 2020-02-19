using ValidatorTesting.Data.Enums;

namespace ValidatorTesting.Infrastructure.Services.ValidatorService
{
    /// <summary>
    /// Объект, содержащий сведения и описание проблемы/ошибки.
    /// </summary>
    public class ValidationResult
    {
        /// <summary>
        /// Возвращает и задает уроверь проблемы/ошибки.
        /// </summary>
        public Severity Severity { get; set; }
        
        /// <summary>
        /// Возвращает и задает текст сообщения проблемы/ошибоки.
        /// </summary>
        public string Message { get; set; }
        
        /// <summary>
        /// Возвращает и задает наименование типа проверяемого объекта.
        /// </summary>
        public string Target { get; set; }

        public override string ToString()
        {
            return $"{Severity.ToString().ToUpper()} | {Message} | {Target}";
        }
    }
}