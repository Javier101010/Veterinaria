﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace VeterinariaAppWeb.Models
{
    public class Mascota
    {
        [DisplayName("CODIGO MASCOTA")]
        public int idMascota { get; set; }
        [DisplayName("NOMBRE")]
        public string nombre { get; set; }
        [DisplayName("RAZA")]
        public string raza { get; set; }
        [DisplayName("EDAD")]
        public int edad { get; set; }
        [DisplayName("COLOR")]
        public string color { get; set; }
        [DisplayName("PESO")]
        public double peso { get; set; }
        [DisplayName("TALLA")]
        public double talla { get; set; }
        [DisplayName("USUARIO")]
        public string idUsuario { get; set; }
        [DisplayName("TIPO MASCOTA")]
        public string idTipoMasc { get; set; }
        [DisplayName("ESTADO")]
        public string estado { get; set; } 
        
    }

}