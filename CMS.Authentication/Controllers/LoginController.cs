using CMS.Authentication.Core;
using CMS.Authentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CMS.Authentication.Controllers
{
    public class LoginController : ControllerBase
    {
        #region Atributos y Propiedades
        private readonly UsuarioManager usuarioManager;
        #endregion


        #region Constructor de la clase
        public LoginController()
        {
            usuarioManager = new UsuarioManager();
        }
        #endregion


        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LoginViewModel modelo  )
        {
            if (ModelState.IsValid)
            {
                var usuario = usuarioManager.Authenticate(modelo.Usuario, modelo.Password);

                if (usuario == null)
                {
                    ModelState.AddModelError("", "Intento de inicio de sesión no válido.");
                    return View("Index");
                }

                UsuarioActual = usuario;
                return RedirectToAction("Index", "Home");

            }
            else
            {
                return View("Index");
            }
            
        }
    }
}