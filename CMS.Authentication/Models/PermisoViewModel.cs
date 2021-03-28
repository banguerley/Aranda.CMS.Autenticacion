using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMS.Authentication.Models
{
    public class PermisoViewModel
    {
        public int Id { get; set; }
        [Display(Name ="Permiso")]
        public string NomPermiso { get; set; }
    }
}