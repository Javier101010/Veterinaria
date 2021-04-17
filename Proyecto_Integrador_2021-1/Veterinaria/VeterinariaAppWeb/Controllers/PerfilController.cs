using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VeterinariaAppWeb.Controllers
{
    public class PerfilController : Controller
    {
        // GET: Usuario
        public ActionResult IndexAdministrador()
        {
            return View();
        }

        public ActionResult IndexTrabajador()
        {
            return View();
        }

        public ActionResult IndexUsuario()
        {
            return View();
        }

        public ActionResult Logout()
        {
            return RedirectToAction("Index");
        }
    }
}