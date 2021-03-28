using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMS.Authentication.Models
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Usuario")]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Nombres Completos")]
        public string NombreCompleto { get; set; }
        [Required]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }
        [Required]
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Edad")]
        public int Edad { get; set; }
        [Required]
        [Display(Name ="Rol")]
        public int IdRol { get; set; }
        public RolViewModel Rol { get; set; }

    }
}