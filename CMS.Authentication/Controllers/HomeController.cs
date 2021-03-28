﻿using AutoMapper;
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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var usuario = (Usuario)Session["datacontainer"];

            if (usuario == null)
                return RedirectToAction("Index", "Login");

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Usuario, UsuarioViewModel>();
                cfg.CreateMap<Rol, RolViewModel>();
            });

            var modelo = MapService<Usuario, UsuarioViewModel>.Map(config, usuario);
            return View(modelo);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
       
    }
}