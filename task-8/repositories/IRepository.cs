using System.Collections.Generic;
using Models;

namespace GenericRepository
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        T GetById(int id);
        void Update(T entity);
        void Delete(int id);
        IEnumerable<T> GetAll();
    }

}