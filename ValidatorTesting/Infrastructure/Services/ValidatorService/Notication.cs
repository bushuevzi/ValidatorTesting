using ValidatorTesting.Data.Enums;

namespace ValidatorTesting.Infrastructure.Services.ValidatorService
{
    /// <summary>
    /// Объект содержащий сведения и описание найденной проблемы/ошибки.
    /// </summary>
    public class ValidationNotification
    {
        /// <summary>
        /// Возвращает и задает уроверь серьезности проблемы/ошибки.
        /// </summary>
        public Severity Severity { get; set; }
        
        /// <summary>
        /// Возвращает и задает текст сообщения о наличии проблем/ошибок.
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