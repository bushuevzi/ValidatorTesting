using Autofac;
using ValidatorTesting.Data.DomainModels;
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

            builder.RegisterType<ValidationService>()
                .As<IValidationService>()
                .SingleInstance();
            builder.RegisterType<PersonsViewModel>();
            
            #endregion
            
            return builder.Build();
        }
    }
}