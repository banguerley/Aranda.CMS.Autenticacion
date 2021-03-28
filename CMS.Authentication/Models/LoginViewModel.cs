using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMS.Authentication.Models
{
    public class LoginViewModel
    {
        
        [Display(Name ="Usuario")]
        [Required(ErrorMessage = "El usuario es requerido")]
        public String Usuario { get; set; }

        [Display(Name ="Contraseña")]
        [Required(ErrorMessage = "La contraseña es requerida")]
        public String Password { get; set; }

    }
}