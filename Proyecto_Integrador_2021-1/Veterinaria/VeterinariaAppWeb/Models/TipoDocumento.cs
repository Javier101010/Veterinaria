using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace VeterinariaAppWeb.Models
{
    public class TipoDocumento
    {
        [DisplayName("ID ROL")]
        public int idTipoDoc { get; set; }
        [DisplayName("DESCRIPCION")]
        public string descripcion { get; set; }
        [DisplayName("ESTADO")]
        public string estado { get; set; }
    }
}