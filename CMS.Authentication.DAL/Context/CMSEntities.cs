using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Authentication.DAL
{
    public partial class CMSEntities : DbContext
    {
        private static CMSEntities instance = null;

        public static CMSEntities GetInstance()
        {
            if (instance == null)
                instance = new CMSEntities();

            return instance;
        }

        
    }
}
