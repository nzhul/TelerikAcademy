using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Application.Models
{
    public class ShouldNotContainEmailAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string valueAsString = value as string;
            if (valueAsString == null)
            {
                return false;
            }

            if (Regex.IsMatch(valueAsString, @"\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,4}"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
