//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VeterinariaAppWeb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_producto
    {
        public int id_product { get; set; }
        public Nullable<int> id_proveedor { get; set; }
        public string nom_producto { get; set; }
        public Nullable<int> id_tipo_produc { get; set; }
        public Nullable<int> stock { get; set; }
        public string serie { get; set; }
        public string marca { get; set; }
        public string descripcion { get; set; }
        public string descripcion_html { get; set; }
        public string imagen1 { get; set; }
        public string imagen2 { get; set; }
        public string imagen3 { get; set; }
        public Nullable<double> precio { get; set; }
    
        public virtual tb_proveedor tb_proveedor { get; set; }
        public virtual tb_tipo_producto tb_tipo_producto { get; set; }
    }
}