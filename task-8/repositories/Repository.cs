using System;
using System.Collections.Generic;
using System.Linq;
using GenericRepository;

namespace InMemoryRepository
{

    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly List<T> _items = new List<T>();
        public void Add(T entity)
        {
            var index = _items.FindIndex(e => e.Equals(entity));
            if (index != -1)
            {
                throw new InvalidOperationException("Entity already exists.");
            }
            _items.Add(entity);
            Console.WriteLine($"------------{typeof(T).Name} added.------------");
        }
        public IEnumerable<T> GetAll()
        {
            return _items;
        }
        public T GetById(int id)
        {
            var entity = _items.FirstOrDefault(
                e => e.GetType().GetProperty("RollNo")?.GetValue(e, null)?.Equals(id) == true
            ) ??
                throw new KeyNotFoundException($"Entity with the specified ID not found.");

            return entity;
        }
        public void Update(T entity)
        {
            var index = _items.FindIndex(e => e.Equals(entity));
            if (index == -1)
            {
                throw new KeyNotFoundException("Entity not found.");
            }
            _items[index] = entity;

            Console.WriteLine($"------------{typeof(T).Name} updated.------------");
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                _items.Remove(entity);
                Console.WriteLine($"------------{typeof(T).Name} with ID {id} removed.------------");
            }
            else
            {
                throw new KeyNotFoundException("Entity not found.");
            }
        }
    }
}
