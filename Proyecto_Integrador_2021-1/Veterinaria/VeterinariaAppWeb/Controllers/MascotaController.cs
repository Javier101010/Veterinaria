using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VeterinariaAppWeb.Models;

namespace VeterinariaAppWeb.Controllers
{
    public class MascotaController : Controller
    {
        // GET: Mascota
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListarMascota()
        {
            return View();
        }

        public ActionResult IngresarMascota()
        {
            return View();
        }
        [HttpPost]
        public ActionResult IngresarMascota(MascotaO s)
        {
            return View();
        }
    }
}