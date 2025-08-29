using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    //tests
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new Exception("Bu bir doğrulama sınıfı değil");
            }
            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = Activator.CreateInstance(_validatorType) as IValidator;
            if (validator == null)
            {
                throw new Exception("Validator örneği oluşturulamadı");
            }

            var baseType = _validatorType.BaseType;
            if (baseType == null || !baseType.IsGenericType)
            {
                throw new Exception("Geçersiz doğrulayıcı tipi");
            }

            var entityType = baseType.GetGenericArguments()[0];

            var entities = invocation.Arguments
                .Where(t => t != null && t.GetType() == entityType);

            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }

    }
}
