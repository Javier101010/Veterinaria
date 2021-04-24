using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace VeterinariaAppWeb.Models
{
    public class Usuario
    {
        [DisplayName("CODIGO USUARIO")]
        public int idUsuario { get; set; }
        [DisplayName("ROL")]
        public string idRol { get; set; }
        [DisplayName("NOMBRE")]
        public string nombre { get; set; }
        [DisplayName("APELLIDO PATERNO")]
        public string apePaterno { get; set; }
        [DisplayName("APELLIDO MATERNO")]
        public string apeMaterno { get; set; }
        [DisplayName("TIPO DOCUMENTO")]
        public string idTipoDoc { get; set; }
        [DisplayName("NUMERO DOCUMENTO")]
        public string numeroDoc { get; set; }
        [DisplayName("TELEFONO")]
        public string telefono { get; set; }
        [DisplayName("DIRECCION")]
        public string direccion { get; set; }
        [DisplayName("CORREO")]
        public string correo { get; set; }
        [DisplayName("CONTRASEÑA")]
        public string contraseña { get; set; }
        [DisplayName("ESTADO")]
        public string estado { get; set; }
        [DisplayName("FOTO")]
        public string foto { get; set; }
    }
}