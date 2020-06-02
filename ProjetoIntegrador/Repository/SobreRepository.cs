using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoIntegrador.Model;

namespace ProjetoIntegrador.Repository
{
    public class SobreRepository : BaseRepository
    {
        public sobre GetOne(int id)
        {
            try
            {
                return DataModel.sobre.First(e => e.id_usuario == id);
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
        public void Salvar(sobre Sobre)
        {
            DataModel.Entry(Sobre).State = Sobre.id_sobre == 0 ?
                System.Data.Entity.EntityState.Added : System.Data.Entity.EntityState.Modified;
            DataModel.SaveChanges();
        }
    }
}