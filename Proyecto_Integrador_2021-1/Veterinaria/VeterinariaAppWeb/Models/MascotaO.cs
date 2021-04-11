using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VeterinariaAppWeb.Models
{
    public class MascotaO
    {
        public int idMascota { get; set; }
        public string nombre { get; set; }
        public string raza { get; set; }
        public int edad { get; set; }
        public string color { get; set; }
        public int idUsuario { get; set; }
        public int idTipoMasc { get; set; }
        public string estado { get; set; }
        public double peso { get; set; }
        public double talla { get; set; }

    }
}