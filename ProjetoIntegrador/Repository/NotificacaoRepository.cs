using ProjetoIntegrador.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoIntegrador.Repository
{
    public class NotificacaoRepository : BaseRepository
    {
        public List<notificacao> GetAll(int idusuarioserecebeu)
        {
            return DataModel.notificacao.Where(e => e.usuario_id_usuario == idusuarioserecebeu).ToList();
        }

        public notificacao GetOne(int id, int idseguindo)
        {
            try
            {
                return DataModel.notificacao.First(e => e.id_usuario == id && e.usuario_id_usuario == idseguindo);
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
    }
}