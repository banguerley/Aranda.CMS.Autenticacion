using CMS.Authentication.DAL;
using CMS.Authentication.DAL.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Authentication.Core
{
    public class UsuarioManager
    {
        #region Atributos y Propiedades de la clase

        readonly UsuarioRepositorio usuarioRepositorio;

        #endregion

        #region Constructor de la clase
        public UsuarioManager()
        {
            usuarioRepositorio = new UsuarioRepositorio();
        }
        #endregion

        #region Metodos de la clase

        /// <summary>
        /// Valida la autenticación de un usuario en el sistema
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Usuario Authenticate(String usuario, String password)
        {
            return usuarioRepositorio.GetAll().Where(x => x.Nombre == usuario && x.Password == password).FirstOrDefault();
        }

        /// <summary>
        /// Ontiene la información de un usuario registrado en el sistema
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Usuario Get(int id)
        {
            return usuarioRepositorio.Get(id);
        }

        public Boolean Create(Usuario usuario)
        {
            usuarioRepositorio.Insert(usuario); 
            return true;
        }

        public Boolean Update(Usuario usuario)
        {
            var actualUsuario = usuarioRepositorio.Get(usuario.Id);
            
            actualUsuario.Nombre = usuario.Nombre;
            actualUsuario.Password = usuario.Password;
            actualUsuario.NombreCompleto = usuario.NombreCompleto;
            actualUsuario.Direccion = usuario.Direccion;
            actualUsuario.Telefono = usuario.Telefono;
            actualUsuario.Email = usuario.Email;
            actualUsuario.Edad = usuario.Edad;
            actualUsuario.IdRol = usuario.IdRol;

            usuarioRepositorio.Update(actualUsuario);
            return true;
        }       

        /// <summary>
        /// Obtiene el listado de usuarios registrados en el sistema
        /// </summary>
        /// <returns></returns>
        public List<Usuario> GetAll()
        {
            return usuarioRepositorio.GetAll().ToList();
        }

        public List<Usuario> GetAll(int? idRol)
        {
            if (idRol != null && idRol > 0)
                return usuarioRepositorio.GetAll().Where(x => x.IdRol == idRol).ToList();
            return usuarioRepositorio.GetAll().ToList();
        }
        #endregion

    }
}
