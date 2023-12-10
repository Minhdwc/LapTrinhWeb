using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace project_1.ViewModel
{
    public class LoginVM
    {
        [Required(ErrorMessage = "UserName cannot be blank.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password cannot be blank.")]
        public string Password { get; set; }
    }
}