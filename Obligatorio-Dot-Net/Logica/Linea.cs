//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core
{
    using System;
    using System.Collections.Generic;
    
    public partial class Linea
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Linea()
        {
            this.Cantidad = 1;
            this.Monto = 0m;
        }
    
        public int Id { get; set; }
        public int FacturaId { get; set; }
        public short Cantidad { get; set; }
        public decimal Monto { get; set; }
    
        public virtual Articulo Articulo { get; set; }
        public virtual Factura Factura { get; set; }
    }
}