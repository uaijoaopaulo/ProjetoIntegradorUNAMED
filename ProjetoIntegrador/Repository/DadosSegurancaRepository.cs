using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoIntegrador.Model;

namespace ProjetoIntegrador.Repository
{
    public class DadosSegurancaRepository : BaseRepository
    {
        public dadosseguranca GetOne(int id)
        {
            try
            {
                return DataModel.dadosseguranca.First(e => e.id_usuario == id);
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public void Salvar(dadosseguranca Dados)
        {
            DataModel.Entry(Dados).State = Dados.id_dadosseguranca == 0 ?
                System.Data.Entity.EntityState.Added : System.Data.Entity.EntityState.Modified;
            DataModel.SaveChanges();
        }
    }
}