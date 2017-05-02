using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeWebsite.Domain.Enums
{
    public enum ValidationType
    {
        NullOrEmpty,
        Null,
        Empty,
        WhiteSpaces,
        MinLength,
        MaxLength,
        BetweenLength,
        FragmentLength
    }
}
