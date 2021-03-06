﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace ValidatorTesting.Infrastructure.Services.ValidatorService
{
    /// <summary>
    /// Сервис проверки данных. Предоставляет функционал объединения валидаторов, асинхронный запуск всех
    /// зарегистрированных валидаторов.
    /// </summary>
    public class ValidationService : IValidationService
    {
        private List<IValidator> _validators = new List<IValidator>();

        /// <inheritdoc />
        public void AddValidator(IValidator validator)
        {
            if (validator == null) throw new ArgumentNullException(nameof(validator));
            if (IsValidatorExist(validator))
            {
                throw new ArgumentException(
                    $"Правило проверки данных {validator.GetType()} уже был добавлен в сервис ранее");
            }

            _validators.Add(validator);
        }

        /// <inheritdoc />
        public void RemoveValidator(IValidator validator)
        {
            if (validator == null) throw new ArgumentNullException(nameof(validator));
            _validators.RemoveAll(v => v == validator);
        }

//        /// <inheritdoc />
//        public async Task<IEnumerable<ValidationResult>> ValidateAsync()
//        {
//            var validationResults = new ConcurrentBag<ValidationResult>();
//            
//            var stopwatch = Stopwatch.StartNew();
//            
//            await Task.Run(() =>
//                Parallel.ForEach(_validators, validator =>
//                {
//                    if (validator.CanExecute is null || validator.CanExecute())
//                    {
//                        foreach (var validationResult in validator.Validate())
//                        {
//                            validationResults.Add(validationResult);
//                        }
//
//                        Task.Delay(1000).GetAwaiter().GetResult();
//                    }
//                }));
//            
//            stopwatch.Stop();
//            validationResults.Add(new ValidationResult{Message = stopwatch.Elapsed.ToString()});
//
//            return validationResults;
//        }

        /// <inheritdoc />
        public async Task<IEnumerable<ValidationResult>> ValidateAsync()
        {
            var validationResults = new List<ValidationResult>();

            List<Task> tasks = new List<Task>();

            foreach (var validator in _validators)
            {
                tasks.Add(Task.Run(() =>
                {
                    if (validator.CanExecute is null || validator.CanExecute())
                    {
                        validationResults.AddRange(validator.Validate());
                    }
                }));
            }

            await Task.WhenAll(tasks.ToArray());

            return validationResults;
        }

        private bool IsValidatorExist(IValidator validator)
        {
            if (validator == null) throw new ArgumentNullException(nameof(validator));
            return _validators.Any(v => v == validator);
        }
    }
}