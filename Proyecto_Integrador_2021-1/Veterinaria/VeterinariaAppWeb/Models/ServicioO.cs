using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VeterinariaAppWeb.Models
{
    public class ServicioO
    {
        public int idServicio { get; set; }
        public string nombre { get; set; }
        public double precio { get; set; }
        public string descripcion { get; set; }
        public DateTime horario { get; set; }
        public DateTime fechaServicio { get; set; }
    }
}