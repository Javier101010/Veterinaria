using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VeterinariaAppWeb.Models
{
    public class Servicio
    {
        public int idServicio { get; set; }
        public string nombre { get; set; }
        public double precio { get; set; }
        public string descripcion { get; set; }
        public string horario { get; set; }
        public string fechaServicio { get; set; }
    }
}