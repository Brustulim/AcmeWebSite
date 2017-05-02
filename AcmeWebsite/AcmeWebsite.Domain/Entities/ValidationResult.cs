using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcmeWebsite.Domain.Enums;

namespace AcmeWebsite.Domain.Entities
{
    public class ValidationResult
    {
        
        public ValidationType ValidationType { get; set; }
        public string Field { get; set; }
        public string Message { get; set; }

        public ValidationResult(ValidationType validationType, string field, string message)
        {
            ValidationType = validationType;
            Field = field;
            Message = message;
        }
    }
}
