using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using Core.Utilities.Messages;
using FluentValidation;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspectAttribute : MethodInterceptionAttribute
    {
        readonly Type _validatorType;
        public ValidationAspectAttribute(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new ArgumentException(message: AspectMessage.WrongValidationType, nameof(validatorType));
            }
            _validatorType = validatorType;
        }

        protected override void OnBefore(IInvocation invocation)
        {
            // 1) Validator instance
            var validator = (IValidator)Activator.CreateInstance(_validatorType)!;

            // 2) BaseType null olabilir → kontrol et
            var baseType = _validatorType.BaseType
                           ?? throw new InvalidOperationException(AspectMessage.ValidatorCannotBeNull);

            // 3) Generic argument yoksa → kontrol et
            var genericArgs = baseType.GetGenericArguments();
            if (genericArgs.Length == 0)
                throw new InvalidOperationException(AspectMessage.ValidatorMustGeneric);

            var entityType = genericArgs[0];

            // 4) invocation.Arguments içinde null olabilir → filtrele
            var entities = invocation.Arguments
                .Where(arg => arg != null && arg.GetType() == entityType);

            foreach (var entity in entities)
            {
                // burada entity null OLMADIĞI için güvenli
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
