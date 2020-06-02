using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoIntegrador.Model;

namespace ProjetoIntegrador.Repository
{
    public class UsuarioMensagemRepository : BaseRepository
    {
        public List<usuariomensagem> GetAll(int idusuarioseenviou, int idusuarioserecebeu)
        {
            return DataModel.usuariomensagem.Where(e => (e.id_usuarioremetente == idusuarioseenviou) || (e.id_usuariodestinatario == idusuarioserecebeu)).ToList();
        }
        public usuariomensagem getOne(int idmensagem)
        {
            try
            {
                return DataModel.usuariomensagem.First(e => e.id_mensagem == idmensagem);
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
    }
}