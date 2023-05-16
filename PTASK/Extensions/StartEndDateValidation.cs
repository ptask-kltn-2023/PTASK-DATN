using System.ComponentModel.DataAnnotations;

namespace PTASK.Extensions
{
    public class StartEndDateValidation : ValidationAttribute
    {
        private readonly string _endTimePropertyName;

        public StartEndDateValidation(string endTimePropertyName)
        {
            _endTimePropertyName = endTimePropertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var startTimeProperty = validationContext.ObjectType.GetProperty(validationContext.MemberName);
            var endTimeProperty = validationContext.ObjectType.GetProperty(_endTimePropertyName);

            if (startTimeProperty != null && endTimeProperty != null)
            {
                var startTimeValue = (DateTime)startTimeProperty.GetValue(validationContext.ObjectInstance);
                var endTimeValue = (DateTime)endTimeProperty.GetValue(validationContext.ObjectInstance);

                if (startTimeValue > endTimeValue)
                {
                    return new ValidationResult(ErrorMessage);
                }
            }

            return ValidationResult.Success;
        }
    }
}
