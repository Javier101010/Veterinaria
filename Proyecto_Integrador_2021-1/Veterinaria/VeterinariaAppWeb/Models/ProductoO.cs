﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VeterinariaAppWeb.Models
{
    public class ProductoO
    {
        public int idProducto { get; set; }
        public int idProveedor { get; set; }
        public string nombre { get; set; }
        public int tipProducto { get; set; }
        public int stock { get; set; }
        public int serie { get; set; }
        public string marca { get; set; }
        public string descripcion { get; set; }
        public string descripHtml { get; set; }
        public int img1 { get; set; }
        public int img2 { get; set; }
        public int img3 { get; set; }
    }
}