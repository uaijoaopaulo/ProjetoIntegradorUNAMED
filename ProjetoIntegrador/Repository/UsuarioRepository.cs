using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoIntegrador.Model;

namespace ProjetoIntegrador.Repository
{
    public class UsuarioRepository : BaseRepository
    {
        public List<usuario> GetAll(string name, string nick, string email)
        {
            return DataModel.usuario.Where(e => e.nomeusuario.Contains(name) || e.nicknameusuario.Contains(nick) || e.emailusuario.Contains(email)).ToList();
        }

        public usuario GetOne(int id)
        {
            try
            {
                return DataModel.usuario.First(e => e.id_usuario == id);
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
        public usuario GetUsuario(string email, string usuarionick)
        {
            try
            {
                return DataModel.usuario.First(e => e.emailusuario == email || e.nicknameusuario == ("@" + usuarionick));
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
        public List<usuario> GetAll()
        {
            return DataModel.usuario.ToList();
        }

        public void Salvar(usuario Usuario)
        {
            DataModel.Entry(Usuario).State = Usuario.id_usuario == 0 ?
                System.Data.Entity.EntityState.Added : System.Data.Entity.EntityState.Modified;
            DataModel.SaveChanges();
        }
    }
}