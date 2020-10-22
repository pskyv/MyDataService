using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDataServiceAPI.Models
{
    public enum StatusCodeType
    {
        Success,
        ValidationError,
        TechnicalError,
        XMLSyntaxError
    }
}
