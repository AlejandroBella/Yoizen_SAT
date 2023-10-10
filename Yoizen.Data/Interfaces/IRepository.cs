using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoizen.Data.Interfaces
{
    public abstract class Repository<T,I> where T : class
    {
       protected DataStore data;
       public abstract T Get(I id);
       public abstract IEnumerable<T> GetAll();
       public abstract bool Add(T entity);
       public abstract bool Update(T entity);
       public abstract bool Delete(T entity);

        public Repository(DataStore data)
        {
            this.data = data;
        }
    }
}
