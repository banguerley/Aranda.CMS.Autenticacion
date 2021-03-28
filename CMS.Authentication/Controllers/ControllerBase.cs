using CMS.Authentication.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Authentication.Controllers
{

    public enum PERMISOS
    {
        NOTICIAS = 1,
        USUARIOS,
        USUARIOS_FILTRO_NOMBRE,
        USUARIOS_FILTRO_ROL,
        USUARIOS_EDITAR,
        USUARIOS_CREAR,
        USUARIOS_ELIMINAR

    }

    /// <summary>
    /// Clase base de los controladores con la logica para almacenar el usuario logueado  
    /// y validación de permisos
    /// </summary>
    public class ControllerBase : Controller
    {

        public Usuario UsuarioActual
        {
            get
            {
                return (Usuario)Session["sessionUsuario"];
            }
            set
            {
                Session["sessionUsuario"] = value;
            }
        }

        /// <summary>
        /// Valida si un usuario tiene permisos sobre una función de la aplicación
        /// </summary>
        /// <param name="permiso"></param>
        /// <returns></returns>
        [NonAction]
        public Boolean TienePermisos(PERMISOS permiso)
        {
            if (UsuarioActual == null)
                return false;

            if (UsuarioActual.Rol.Permiso == null)
                return false;

            return UsuarioActual.Rol.Permiso.Any(x => x.Id == (int)permiso);

        }

        [NonAction]
        public void PermisosMenu()
        {
            ViewBag.MenuUsuarios = TienePermisos(PERMISOS.USUARIOS);
            ViewBag.MenuNoticias = TienePermisos(PERMISOS.NOTICIAS);
        }



    }
}