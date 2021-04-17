using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VeterinariaAppWeb.Models;

namespace VeterinariaAppWeb.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListarServicio()
        {
            return View();
        }

        public ActionResult RegistrarUsuario()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegistrarUsuario(UsuarioO u)
        {
            return View();
        }
    }
}