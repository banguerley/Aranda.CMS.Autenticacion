using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Authentication.DAL.Repositorio
{
    public class RolRepositorio : RepositorioBase<Rol, int>
    {

        #region Constructor de la clase
        public RolRepositorio(CMSEntities dbContext) : base(dbContext)
        {

        }

        public RolRepositorio(): base()
        {

        }
        #endregion

        #region Metodos de la clase

        public override IQueryable<Rol> GetAll()
        {
            return base.GetAll().Include( x=> x.Permiso);
        }
        #endregion
    }
}
