//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjetoIntegrador.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class sobre
    {
        public int id_sobre { get; set; }
        public int id_usuario { get; set; }
        public System.DateTime datanascimento { get; set; }
        public string genero { get; set; }
        public string relacionamento { get; set; }
        public string biografia { get; set; }
    
        public virtual usuario usuario { get; set; }
    }
}
