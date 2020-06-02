using ProjetoIntegrador.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ProjetoIntegrador.Repository
{
    public class ComentarioRepository : BaseRepository
    {
        public List<comentario> GetAllById(int idpost)
        {
            return DataModel.comentario.Where(e => e.id_post == idpost).ToList();
        }

        public List<comentario> GetAllByIdPerfil(int id)
        {
            return DataModel.comentario.Where(e => e.id_usuarioremetente == id).ToList();
        }

        public void Salvar(comentario Comentario)
        {
            DataModel.Entry(Comentario).State = Comentario.id_comentario == 0 ?
                System.Data.Entity.EntityState.Added : System.Data.Entity.EntityState.Modified;
            DataModel.SaveChanges();
        }

        public comentario GetOne(int id)
        {
            return DataModel.comentario.First(e => e.id_comentario == id);
        }

        public void Delete(int id)
        {
            comentario Comentario = GetOne(id);
            DataModel.comentario.Remove(Comentario);
            DataModel.SaveChanges();
        }
    }
}