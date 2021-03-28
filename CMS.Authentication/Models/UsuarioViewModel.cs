using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.Authentication.Models
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public string NombreCompleto { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public int Edad { get; set; }

        public RolViewModel Rol { get; set; }

    }
}