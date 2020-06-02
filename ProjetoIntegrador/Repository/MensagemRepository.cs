using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoIntegrador.Model;

namespace ProjetoIntegrador.Repository
{
    public class MensagemRepository : BaseRepository
    {
        public mensagem GetOne(int id)
        {
            try
            {
                return DataModel.mensagem.First(e => e.id_mensagem == id);
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
    }
}