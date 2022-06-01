using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuthentiTrack.UI.Helpers
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MultipleOfAttribute : ValidationAttribute, IClientValidatable
    {
        string basePropName;

        public MultipleOfAttribute(string BasePropName, string ErrorMessage = "")
            : base(ErrorMessage)
        {
            this.basePropName = BasePropName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult validationResult = ValidationResult.Success;

            ErrorMessage = ErrorMessageString;

            try
            {
                var basePropValue = validationContext.ObjectType.GetProperty(basePropName);
                if (basePropValue.PropertyType.Equals(new Int32().GetType()))
                {
                    decimal targetValue =  Convert.ToDecimal(value);
                    decimal baseValue = Convert.ToDecimal(basePropValue.GetValue(validationContext.ObjectInstance, null));

                    //if (targetValue == null) return validationResult;
                    if (targetValue % baseValue != 0)
                        validationResult = new ValidationResult(ErrorMessage);
                    else
                    {
                        return validationResult;
                    }
                }
                else
                {
                    validationResult = new ValidationResult(basePropName + " is not an integer.");
                }
            }
            catch (Exception)
            {
                throw;
            }
            return validationResult;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            string errorMessage = ErrorMessageString;

            ModelClientValidationRule multipleOfRule = new ModelClientValidationRule();
            multipleOfRule.ErrorMessage = ErrorMessage;
            multipleOfRule.ValidationType = "checkifmultipleof"; // Name of the JavaScript method used by jQuery adapter
            multipleOfRule.ValidationParameters.Add("checkifmultipleof", basePropName);
                // First parameter is name of the jQuery parameter for the adapter
            yield return multipleOfRule;
        }
    }
}