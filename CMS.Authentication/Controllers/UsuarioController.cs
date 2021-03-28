using AutoMapper;
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
    public class UsuarioController : ControllerBase
    {

        #region Atributos y Propiedades

        private readonly UsuarioManager usuarioManager;
        private readonly RolManager rolManager;

        #endregion


        #region Constructor de la clase

        public UsuarioController()
        {
            usuarioManager = new UsuarioManager();
            rolManager = new RolManager();
        }
        #endregion

        // GET: Usuario
        public ActionResult Index(int? id)
        {
            PermisosMenu();

            if (UsuarioActual == null)
                return RedirectToAction("Index", "Login");

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Usuario, UsuarioViewModel>();
                cfg.CreateMap<Rol, RolViewModel>();
            });

            ViewBag.PermisoFiltrarRol = TienePermisos(PERMISOS.USUARIOS_FILTRO_ROL);
            ViewBag.PermisoEditar = TienePermisos(PERMISOS.USUARIOS_EDITAR);
            ViewBag.ListaRoles = new SelectList(rolManager.GetAll(), "Id", "NombreRol", "Id");
            
            var lista = MapService<Usuario, UsuarioViewModel>.MapList(config, usuarioManager.GetAll(id));
            return View(lista);
        }

        

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            PermisosMenu();

            var usuario = usuarioManager.Get(id);

            if (usuario == null)
                return View("Index");

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Usuario, UsuarioViewModel>();
                cfg.CreateMap<Rol, RolViewModel>();
            });
            ViewBag.ListaRoles = new SelectList(rolManager.GetAll(), "Id", "NombreRol", "Id");

            return View(MapService<Usuario, UsuarioViewModel>.Map(config, usuario));
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UsuarioViewModel modelo)
        {
            try
            {

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<UsuarioViewModel, Usuario>();
                   // cfg.CreateMap<Rol, RolViewModel>();
                });

                var usuario = MapService<UsuarioViewModel, Usuario>.Map(config, modelo);
                usuarioManager.Update(usuario);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.ListaRoles = new SelectList(rolManager.GetAll(), "Id", "NombreRol", "Id");
                return View();
            }
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
