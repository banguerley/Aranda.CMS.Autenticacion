using CMS.Authentication.Core;
using CMS.Authentication.DAL;
using CMS.Authentication.Models;
using CMS.Authentication.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Authentication.Controllers
{
    public class RolController : Controller
    {
        #region Atributos y Propiedades

        private readonly RolManager rolManager;

        #endregion


        #region Constructor de la clase

        public RolController()
        {
            rolManager = new RolManager();
        }
        #endregion


        // GET: Rol
        public ActionResult Index()
        { 
            var lista  = MapService<Rol, RolViewModel>.MapList(rolManager.GetAll());
            return View(lista);
        }

        public ActionResult Permisos(int id)
        {
            var rol = rolManager.Get(id);

            var lista = MapService<Permiso, PermisoViewModel>.MapList(rol.Permiso.ToList());
            return View(lista);
        }
    }
}