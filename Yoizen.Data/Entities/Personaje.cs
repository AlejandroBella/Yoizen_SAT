using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoizen.Data
    .Entities
{
    public class Personaje
    {       
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Imagen { get; set; }
        public string Historia { get; set; }
        public string Estado { get; set; }
        public string Ocupacion { get; set; }
        public string Genero { get; set; }
    }
}
