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
    
    public partial class comentario
    {
        public int id_comentario { get; set; }
        public int id_post { get; set; }
        public int id_usuarioremetente { get; set; }
        public System.DateTime datacomentario { get; set; }
        public string comentariocontent { get; set; }
    
        public virtual post post { get; set; }
        public virtual usuario usuario { get; set; }
    }
}
