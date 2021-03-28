using CMS.Authentication.DAL;
using CMS.Authentication.DAL.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Authentication.Core
{
    public class RolManager
    {
        #region Atributos y Propiedades

        private readonly RolRepositorio rolRepositorio;

        #endregion

        #region Constructor de la clase
        public RolManager()
        {
            rolRepositorio = new RolRepositorio();
        }
        #endregion

        #region Metodos de la clase

        public List<Rol> GetAll()
        {
            return rolRepositorio.GetAll().ToList();
        }

        public Rol Get(int id)
        {
            return rolRepositorio.Get(id);
        }


        #endregion

    }
}
