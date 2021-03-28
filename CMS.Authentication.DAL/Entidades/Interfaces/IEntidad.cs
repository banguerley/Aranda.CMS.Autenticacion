using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Authentication.DAL.Entidades.Interfaces
{
    public interface IEntidad<Key>
    {
        Key Id { get; set; }
    }
}
