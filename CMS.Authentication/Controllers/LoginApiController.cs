using CMS.Authentication.Core;
using CMS.Authentication.DAL;
using CMS.Authentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CMS.Authentication.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/login")]
    public class LoginApiController : ApiController
    {
        #region Atributos y Propiedades

        readonly UsuarioManager usuarioManager;
        #endregion


        #region Constructor de la clase
        public LoginApiController()
        {
            usuarioManager = new UsuarioManager();
        }
        #endregion
        [HttpPost]
        [Route("authenticate")]
        public IHttpActionResult Authenticate(LoginViewModel request)
        {
            if (request == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var usuario = usuarioManager.Authenticate(request.Usuario, request.Password);

            if (usuario != null)
            {
                return  Ok(usuario);
            }

            return Unauthorized();
               

        }
       
    }
}
