using Microsoft.EntityFrameworkCore;
using Project.DAL.Context;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.CoreInterfaces;
using Project.ENTITIES.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Concrates
{
    public class BaseRepository<T> : IRepository<T> where T : class , IEntity
    {
        protected MyContext _db;

        protected DbSet<T> _dbSet;

        public BaseRepository(MyContext db)
        {
            _db = db;
            _dbSet = _db.Set<T>();
        }

        protected void Save()
        {
            _db.SaveChanges();
        }

        public void Add(T item)
        {
            _dbSet.Add(item);
            Save();
        }

        public void AddRange(List<T> list)
        {
            _dbSet.AddRange(list);
            Save();
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return _dbSet.Any(exp);
        }

        public void Delete(T item)
        {
            item.DeletedDate = DateTime.Now;
            item.Status = DataStatus.Deleted;
            Save();
        }

        public void DeleteRange(List<T> list)
        {
            foreach (T item in list)
            {
                Delete(item);
            }
        }

        public void Destroy(T item)
        {
            _dbSet.Remove(item);
            Save();
        }

        public void DestroyRange(List<T> list)
        {
            _dbSet.RemoveRange(list);
            Save();
        }

        public T Find(int id)
        {
            return _dbSet.Find(id);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> exp)
        {
            return _dbSet.FirstOrDefault(exp);
        }

        public List<T> GetActives()
        {
            return Where(x => x.Status != DataStatus.Deleted);
        }

        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public List<T> GetDeleted()
        {
            return Where(x => x.Status == DataStatus.Deleted);
        }

        public List<T> GetFirstDatas(int number)
        {
            return _dbSet.OrderBy(x => x.CreatedDate).Take(number).ToList();
        }

        public List<T> GetLastDatas(int number)
        {
            return _dbSet.OrderByDescending(x => x.CreatedDate).Take(number).ToList();
        }

        public List<T> GetUpdated()
        {
            return Where(x => x.Status == DataStatus.Updated);
        }

        public object Select(Expression<Func<T, object>> exp)
        {
            return _dbSet.Select(exp).ToList();
        }

        public IQueryable<X> SelectViaClass<X>(Expression<Func<T, X>> exp)
        {
            return _dbSet.Select(exp);
        }

        public void Update(T item)
        {
            item.ModifiedDate = DateTime.Now;
            item.Status = DataStatus.Updated;

            T guncellenecek = Find(item.ID);

            _db.Entry(guncellenecek).CurrentValues.SetValues(item);
            Save();
        }

        public void UpdateRange(List<T> list)
        {
            foreach (T item in list)
            {
                Update(item);
            }
        }

        public List<T> Where(Expression<Func<T, bool>> exp)
        {
            return _dbSet.Where(exp).ToList();
        }

    }
}
