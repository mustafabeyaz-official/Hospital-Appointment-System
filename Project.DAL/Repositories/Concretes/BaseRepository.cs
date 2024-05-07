using Microsoft.EntityFrameworkCore;
using Project.DAL.Context;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Concretes
{
    public class BaseRepository<T> : IRepository<T> where T : class, IEntity
    {
        MyContext _db;
        public BaseRepository(MyContext db)
        {
            _db = db;
        }

        //List Methods
        public IQueryable<T> GetAll()
        {
            return _db.Set<T>().AsQueryable();
        }

        public IQueryable<T> GetActives()
        {
            return Where(x => x.Status != ENTITIES.Enums.DataStatus.Deleted);
        }

        public IQueryable<T> GetModifieds()
        {
            return Where(x => x.Status == ENTITIES.Enums.DataStatus.Updated);
        }

        public IQueryable<T> GetPassives()
        {
            return Where(x => x.Status == ENTITIES.Enums.DataStatus.Deleted);
        }

        //Modify Methods
        public void Add(T item)
        {
            _db.Set<T>().Add(item);
            _db.SaveChanges();
        }

        public async Task AddAsync(T item)
        {
            await _db.Set<T>().AddAsync(item);
            await _db.SaveChangesAsync();
        }

        public void AddRange(List<T> items)
        {
            _db.Set<T>().AddRange(items);
            _db.SaveChanges();
        }

        public async Task AddRangeAsync(List<T> items)
        {
            await _db.Set<T>().AddRangeAsync(items);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(T item)
        {
            item.Status = ENTITIES.Enums.DataStatus.Updated;
            item.ModifiedDate = DateTime.Now;
            T original =  Find(item.ID);
            _db.Entry(original).CurrentValues.SetValues(item);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateRangeAsync(List<T> items)
        {
            foreach (T item in items)
            {
                await UpdateAsync(item);
            }
        }

        public void Delete(T item)
        {
            item.Status = ENTITIES.Enums.DataStatus.Deleted;
            item.DeletedDate = DateTime.Now;
            _db.SaveChanges();
        }

        public void DeleteRange(List<T> items)
        {
            foreach(T item in items)
            {
                Delete(item);
            }
        }

        public void Destroy(T item)
        {
            _db.Set<T>().Remove(item);
            _db.SaveChanges();
        }

        public void DestroyRange(List<T> items)
        {
            _db.Set<T>().RemoveRange(items);
            _db.SaveChanges();
        }

        //LINQ Methods
        public IQueryable<T> Where(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().Where(exp);
        }

        public bool Any (Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().Any(exp);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> exp)
        {
            return await _db.Set<T>().AnyAsync(exp);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().FirstOrDefault(exp)!;
        }

        public IQueryable<X> Select<X>(Expression<Func<T, X>> exp)
        {
            return _db.Set<T>().Select(exp);
        }

        //Find Methods
        public T Find(int id)
        {
            return _db.Set<T>().Find(id)!;
        }
    }
}
