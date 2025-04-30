using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Services
{
    public interface IValidationService
    {
        void Validate<T>(T instance);
    }

    public class ValidationService : IValidationService
    {
        private readonly IServiceProvider _serviceProvider;

        public ValidationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void Validate<T>(T instance)
        {
            var validator = _serviceProvider.GetService<IValidator<T>>();
            if (validator == null)
            {
                throw new InvalidOperationException($"No validator found for type {typeof(T).Name}");
            }

            var validationResult = validator.Validate(instance);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
        }
    }
}