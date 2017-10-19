using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace webApp_test.Validations
{
    public class MaxChildrenAttribute : ValidationAttribute
    {
        private readonly int _max;

        public MaxChildrenAttribute(int max)
        {
            _max = max;
        }


        public override bool IsValid(object value)
        {
            return _max <= (int)value;
        }
        
        public override string FormatErrorMessage(string name)
        {
            return string.Format(CultureInfo.CurrentCulture,
                ErrorMessageString, "", _max);
        }

    }
}