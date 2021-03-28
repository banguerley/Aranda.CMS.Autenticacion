using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Authentication.DAL.Repositorio
{
    public class UsuarioRepositorio : RepositorioBase<Usuario, Int32>
    {

        #region Constructor de la clase
        public UsuarioRepositorio(CMSEntities dbContext) : base(dbContext)
        {

        }

        public UsuarioRepositorio() : base()
        {

        }


        #endregion

        #region Metodos de la clase
        public override IQueryable<Usuario> GetAll()
        {
            return base.GetAll().AsNoTracking()
            .Include(reg => reg.Rol);         
        }

        #endregion
    }
}
