using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace VeterinariaAppWeb.Models
{
    public class Rol
    {
        [DisplayName("ID ROL")]
        public int idRol { get; set; }
        [DisplayName("DESCRIPCION")]
        public string descripcion { get; set; }
        [DisplayName("TIPO")]
        public string tipo { get; set; }
    }
}