using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace StellaguardProductAssociation.Models
{
    public class ProductAssociationLogin
    {

        [Required(ErrorMessage = "User name is required")]
        public string Username { get; set; }


        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
