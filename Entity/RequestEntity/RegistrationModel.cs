using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entity.RequestEntity
{
    public class RegistrationModel
    {
        [Required(ErrorMessage = "TName is required")]
        public string employee_name { get; set; }


        [Required(ErrorMessage = "Address is required")]
        public string address { get; set; }


        [Required(ErrorMessage = "NID is required")]
        public string nid { get; set; }

        [Required(ErrorMessage = "The email address is required")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string email { get; set; }


        [Required(ErrorMessage = "Contact no is required")]
        public string contact_1 { get; set; }


        [Required(ErrorMessage = "Contact person no is required")]
        public string con_person_no { get; set; }


        [Required(ErrorMessage = "Contact person name is required")]
        public string contact_persion { get; set; }


        [Required(ErrorMessage = "User Name is required")]
        public string userName { get; set; }


        [Required(ErrorMessage = "Password is required")]
        public string password { get; set; }
    }
}
