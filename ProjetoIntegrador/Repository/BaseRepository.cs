using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoIntegrador.Model;

namespace ProjetoIntegrador.Repository
{
    public class BaseRepository
    {
        private bancodedadosEntities _DataModel;
        public bancodedadosEntities DataModel
        {
            get
            {
                if (_DataModel == null)
                {
                    _DataModel = new bancodedadosEntities();
                }
                return _DataModel;
            }
        }
    }
}