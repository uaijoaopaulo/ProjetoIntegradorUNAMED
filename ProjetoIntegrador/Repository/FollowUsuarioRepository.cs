using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoIntegrador.Model;

namespace ProjetoIntegrador.Repository
{
    public class FollowUsuarioRepository : BaseRepository
    {
        public List<followusuario> GetAllById(int idusuario)
        {
            return DataModel.followusuario.Where(e => e.id_usuario == idusuario).ToList();
        }

        public List<followusuario> GetAllSeguido(int idusuario)
        {
            return DataModel.followusuario.Where(e => e.usuario_id_usuario == idusuario).ToList();
        }

        public followusuario GetOne(int id, int idseguindo)
        {
            try
            {
                return DataModel.followusuario.First(e => e.id_usuario == id && e.usuario_id_usuario == idseguindo);
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public void Delete(followusuario follow)
        {
            DataModel.followusuario.Remove(follow);
            DataModel.SaveChanges();
        }

        public void Salvar(followusuario follow)
        {
            DataModel.Entry(follow).State = System.Data.Entity.EntityState.Added;
            DataModel.SaveChanges();
        }
    }
}