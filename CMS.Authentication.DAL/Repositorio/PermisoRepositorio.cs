using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Authentication.DAL.Repositorio
{
    public class PermisoRepositorio : RepositorioBase<Permiso, Int32>
    {
        public PermisoRepositorio(CMSEntities dbContext) : base(dbContext)
        {

        }

        public PermisoRepositorio():base()
        {

        }
    }
}
