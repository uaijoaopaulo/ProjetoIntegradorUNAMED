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
    
    public partial class mensagem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public mensagem()
        {
            this.usuariomensagem = new HashSet<usuariomensagem>();
        }
    
        public int id_mensagem { get; set; }
        public string contentmensagem { get; set; }
        public bool visualizadomensagem { get; set; }
        public System.DateTime datamensagem { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<usuariomensagem> usuariomensagem { get; set; }
    }
}
