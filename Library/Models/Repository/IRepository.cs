using Library.Models.LibraryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.Repository
{
    public interface IRepository<T> where T : BaseModel
    {
        IQueryable<T> GetAll();
        T Get(Guid id);
        IQueryable<T> GetQueryable(Guid id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
