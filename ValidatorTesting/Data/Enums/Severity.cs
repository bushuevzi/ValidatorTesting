namespace ValidatorTesting.Data.Enums
{
    /// <summary>
    /// Важность
    /// </summary>
    public enum Severity
    {
        /// <summary>
        /// Фатальная ошибка после которой дальнейшое выполенине не возможно
        /// </summary>
        Fatal,
        
        /// <summary>
        /// Ошибка, но выполенине может быть продолжено
        /// </summary>
        Error,
        
        /// <summary>
        /// Проблемное место которое может негативно сказаться на результате работы 
        /// </summary>
        Warning,
        
        /// <summary>
        /// Рекомендация
        /// </summary>
        Hint
    }
}