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
    
    public partial class followusuario
    {
        public int id_usuario { get; set; }
        public int usuario_id_usuario { get; set; }
        public System.DateTime datafollow { get; set; }
    
        public virtual usuario usuario { get; set; }
        public virtual usuario usuario1 { get; set; }
    }
}