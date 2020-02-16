using Autofac;
using ValidatorTesting.Infrastructure.Services.ValidatorService;

namespace ValidatorTesting.Infrastructure.IoC
{
    /// <summary>
    /// Инициализация контейнера DI
    /// </summary>
    public static class AutofacInitializer
    {
        public static IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();

            #region Регистрация сервисов
            
            builder.RegisterType<ValidatorService>()
                .As<IValidatorService>()
                .SingleInstance();
            
            #endregion
            
            return builder.Build();
        }
    }
}