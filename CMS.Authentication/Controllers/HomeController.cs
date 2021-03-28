using AutoMapper;
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
    public class HomeController : ControllerBase
    {
        public ActionResult Index()
        {
            PermisosMenu();

            if (UsuarioActual == null)
                return RedirectToAction("Index", "Login");

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Usuario, UsuarioViewModel>();
                cfg.CreateMap<Rol, RolViewModel>();
            });

            var modelo = MapService<Usuario, UsuarioViewModel>.Map(config, UsuarioActual);
            return View(modelo);
        }

        public ActionResult About()
        {
            PermisosMenu();
            return View();
        }

        public ActionResult Noticias()
        {
            PermisosMenu();
            return View();
        }


    }
}