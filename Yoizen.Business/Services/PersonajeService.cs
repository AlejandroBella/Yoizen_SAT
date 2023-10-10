using Yoizen.Data.Entities;
using Yoizen.Data.Interfaces;
using Yoizen.Data.Extension;
using Yoizen.Business.Entities;

namespace Yoizen.Business.Services
{
    public class PersonajeService
    {
        private readonly Repository<Personaje, Guid> personajeRepo;   

        public PersonajeService(Repository<Personaje,Guid> personajeRepository)
        {
            this.personajeRepo = personajeRepository;     
        }

        public PagedDocs<Personaje> GetByName(string name, PagingParameters pageParams)
        {           
            var dataList = personajeRepo.GetByName(name);
            var result = PaginationService<Personaje>.GetPages(dataList, pageParams);        


            return result;
       
        }

        
    }
}
