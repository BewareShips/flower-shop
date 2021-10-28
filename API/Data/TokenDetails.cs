using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public record TokenDetails
     (
         string Token,
         DateTime Expiration
     );
}
