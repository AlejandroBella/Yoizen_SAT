using Yoizen.Data.Entities;
using Yoizen.Data.Interfaces;

namespace Yoizen.Data
{
    public class PersonajeRepository : Repository<Personaje, Guid>
    {
        public PersonajeRepository(DataStore data) : base(data)
        {
        }

        public override bool Add(Personaje entity)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Personaje entity)
        {
            throw new NotImplementedException();
        }

        public override Personaje Get(Guid id)
        {
            return data.Personajes.FirstOrDefault(x => x.Id == id);
        }

        public override IEnumerable<Personaje> GetAll()
        {
            return data.Personajes;
        }

        public override bool Update(Personaje entity)
        {
            throw new NotImplementedException();
        }
    }
}