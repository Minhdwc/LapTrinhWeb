using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace project_1.ViewModel
{
    public class RegisterVM
    {
        [Required(ErrorMessage ="UserName cannot be blank.")]
        public string UserName {  get; set; }
        [Required(ErrorMessage ="Password cannot be blank.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Comfirm Password cannot be blank.")]
        [Compare("Password", ErrorMessage = "Password and Comfirm Password is not same")]
        public string ComfirmPass {  get; set; }
        [Required(ErrorMessage ="Email cannot blank.")]
        [EmailAddress(ErrorMessage ="Invalid Email")]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birth {  get; set; }
        public string Address {  get; set; }
        public string City { get; set; }
    }
}