using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoIntegrador.Model;

namespace ProjetoIntegrador.Repository
{
    public class PostRepository : BaseRepository
    {
        public void Salvar(post Post)
        {
            DataModel.Entry(Post).State = Post.id_post == 0 ?
                System.Data.Entity.EntityState.Added : System.Data.Entity.EntityState.Modified;
            DataModel.SaveChanges();
        }
        public List<post> GetAllById(int idusuario)
        {
            return DataModel.post.Where(e => e.id_usuario == idusuario).ToList();
        }

        public List<post> GetAllByLocation(double latitude, double longitude, double metros)
        {
            double medidaLat = (metros * 9) * 0.000001;
            double medidaLon = (metros * 9.4) * 0.000001;
            double latitudemenos = (latitude - medidaLat);
            double latitudemais = (latitude + medidaLat);
            double longitudemenos = (longitude - medidaLon);
            double longitudemais = (longitude + medidaLon);
            return DataModel.post.Where(e => e.lat >= latitudemenos && e.lat <= latitudemais
            && e.lon >= longitudemenos && e.lon <= longitudemais).ToList();
        }

        public post GetOne(int id)
        {
            try
            {
                return DataModel.post.First(e => e.id_post == id);
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public void Delete(int id)
        {
            post Post = GetOne(id);
            DataModel.post.Remove(Post);
            DataModel.SaveChanges();
        }
    }
}