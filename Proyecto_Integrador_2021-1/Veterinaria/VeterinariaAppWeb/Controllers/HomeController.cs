using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VeterinariaAppWeb.Controllers
{
    public class HomeController : Controller
    {

        SqlConnection cn = new SqlConnection(ConfigurationManager
                            .ConnectionStrings["cnx"].ConnectionString);

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string idUsu, string password)
        {
            if (idUsu == "administrador@gmail.com" && password == "administrador")
            {
                return RedirectToAction("IndexAdministrador", "Perfil");
            }
            else if (idUsu == "trabajador@gmail.com" && password == "trabajador")
            {
                return RedirectToAction("IndexTrabajador", "Perfil");
            }
            else
            {
                return RedirectToAction("IndexUsuario", "Perfil");
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


    }
}