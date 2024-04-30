using Project.ENTITIES.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Abstracts
{
    public interface IRepository<T> where T : class, IEntity
    {
        //List Commands
        IQueryable<T> GetAll();
        IQueryable<T> GetActives();
        IQueryable<T> GetModifieds();
        IQueryable<T> GetPassives();

        //Modify Commands
        void Add(T item);
        Task AddAsync(T item);
        void AddRange(List<T> items);
        Task AddRangeAsync(List<T> items);
        Task UpdateAsync(T item);
        Task UpdateRangeAsync(List<T> items);
        void Delete(T item);
        void DeleteRange(List<T> items);
        void Destroy(T item);
        void DestroyRange(List<T> items);

        //LINQ Commands
        IQueryable<T> Where(Expression<Func<T, bool>> exp);
        bool Any(Expression<Func<T, bool>> exp);
        Task<bool> AnyAsync(Expression<Func<T, bool>> exp);
        T FirstOrDefault(Expression<Func<T, bool>> exp);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> exp);
        IQueryable<X> Select<X>(Expression<Func<T, X>> exp);

        //Find
        T Find(int id);
        Task<T> FindAsync(int id);
    }
}
