using Project.BLL.ManagerServices.Abstracts;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ManagerServices.Concretes
{
    public class BaseManager<T> : IManager<T> where T : class, IEntity
    {
        protected IRepository<T> _repository;
        public BaseManager(IRepository<T> repository)
        {
            _repository = repository;
        }

        //List Methods
        public IQueryable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public IQueryable<T> GetActives()
        {
            return _repository.GetActives();
        }

        public IQueryable<T> GetModifieds()
        {
            return _repository.GetModifieds();
        }

        public IQueryable<T> GetPassives()
        {
            return _repository.GetPassives();
        }

        //Modify Methods
        public void Add(T item)
        {
            _repository.Add(item);
        }

        public async Task AddAsync(T item)
        {
            await _repository.AddAsync(item);
        }

        public void AddRange(List<T> items)
        {
            _repository.AddRange(items);
        }

        public async Task AddRangeAsync(List<T> items)
        {
            await _repository.AddRangeAsync(items);
        }

        public async Task UpdateAsync(T item)
        {
            await _repository.UpdateAsync(item);
        }

        public async Task UpdateRangeAsync(List<T> items)
        {
            await _repository.UpdateRangeAsync(items);
        }

        public void Delete(T item)
        {
            _repository.Delete(item);
        }

        public void DeleteRange(List<T> items)
        {
            _repository.DeleteRange(items);
        }

        public void Destroy(T item)
        {
            _repository.Destroy(item);
        }

        public void DestroyRange(List<T> items)
        {
            _repository.DestroyRange(items);
        }

        //LINQ Methods
        public IQueryable<T> Where(Expression<Func<T, bool>> exp)
        {
            return _repository.Where(exp);
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return _repository.Any(exp);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> exp)
        {
            return await _repository.AnyAsync(exp);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> exp)
        {
            return _repository.FirstOrDefault(exp);
        }

        public IQueryable<X> Select<X>(Expression<Func<T, X>> exp)
        {
            return _repository.Select(exp);
        }

        //Find Methods
        public T Find(int id)
        {
            return _repository.Find(id);
        }
    }
}
