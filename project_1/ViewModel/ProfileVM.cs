using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace project_1.ViewModel
{
    public class ProfileVM
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birth { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }
}