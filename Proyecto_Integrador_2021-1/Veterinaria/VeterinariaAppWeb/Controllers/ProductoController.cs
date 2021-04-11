using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VeterinariaAppWeb.Models;

namespace VeterinariaAppWeb.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListarProducto()
        {
            return View();
        }

        public ActionResult IngresarProducto()
        {
            return View();
        }
        [HttpPost]
        public ActionResult IngresarProducto(ProductoO p)
        {
            return View();
        }


    }
}