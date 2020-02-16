using ValidatorTesting.Data.Enums;

namespace ValidatorTesting.Infrastructure.Services.ValidatorService
{
    /// <summary>
    /// Уведомления
    /// </summary>
    public class Notification
    {
        /// <summary>
        /// Важность
        /// </summary>
        public Severity Severity { get; set; }
        
        /// <summary>
        /// Сообщение
        /// </summary>
        public string Message { get; set; }
        
        /// <summary>
        /// Проверяемый объект
        /// </summary>
        public string ValidatedTarget { get; set; }

        public override string ToString()
        {
            return $"{Severity.ToString().ToUpper()} | {Message} | {ValidatedTarget}";
        }
    }
}