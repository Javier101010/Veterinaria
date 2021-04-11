using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VeterinariaAppWeb.Models;

namespace VeterinariaAppWeb.Controllers
{
    public class ServicioController : Controller
    {
        // GET: Servicio
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListarServicio()
        {
            return View();
        }

        public ActionResult IngresarServicio()
        {
            return View();
        }
        [HttpPost]
        public ActionResult IngresarServicio(ServicioO s)
        {
            return View();
        }
    }
}