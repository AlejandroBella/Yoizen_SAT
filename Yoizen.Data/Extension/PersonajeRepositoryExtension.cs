using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yoizen.Data.Entities;
using Yoizen.Data.Interfaces;

namespace Yoizen.Data.Extension
{
    public static class PersonajeRepositoryExtension
    {
        public static List<Personaje> GetByName(this Repository<Personaje, string> repository, string name)
        {
            return repository.GetAll().Where(x => x.Nombre.ToLower().Contains(name.ToLower())).ToList();
        }
    }
}
