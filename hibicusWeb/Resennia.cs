//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace hibicusWeb
{
    using System;
    using System.Collections.Generic;
    
    public partial class Resennia
    {
        public int id_Resenia { get; set; }
        public string cotenido { get; set; }
        public int id_Cliente { get; set; }
        public int puntuacion { get; set; }
        public System.DateTime fecha { get; set; }
    
        public virtual Usuario Usuario { get; set; }
    }
}
