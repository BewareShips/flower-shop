using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public record RegistrationModel
      (
          [Required(ErrorMessage = "User name is required!")] string UserName,
          [Required(ErrorMessage = "Password is required!")] string Password,
          [Required(ErrorMessage = "Confirm password is required!")] string ConfirmPassword,
          [Required(ErrorMessage = "Email is required!")] string Email,
          [Required(ErrorMessage = "Full name is required!")] string FullName
      );
}
