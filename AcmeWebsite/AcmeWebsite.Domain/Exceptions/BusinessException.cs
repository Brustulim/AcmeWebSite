using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcmeWebsite.Domain.Entities;

namespace AcmeWebsite.Domain.Exceptions
{
    public class BusinessException: Exception
    {
        public List<ValidationResult> Errors { get; set; } 
    }
}
