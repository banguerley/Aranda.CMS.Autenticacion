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

        public Usuario Get(String usuario, String password)
        {
            return usuarioRepositorio.GetAll().Where(x => x.Nombre == usuario && x.Password == password).FirstOrDefault();
        }
        #endregion

    }
}
