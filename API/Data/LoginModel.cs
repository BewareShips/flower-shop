using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public record LoginModel
     (
         [Required(ErrorMessage = "User name is required!")] string UserName,
         [Required(ErrorMessage = "Password is required!")] string Password
     );
}
