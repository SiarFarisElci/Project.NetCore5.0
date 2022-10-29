using Project.ENTITIES.CoreInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ManagerServices.Abstracts
{
    public interface IManager<T> where T : IEntity
    {

        //List Commad

        List<T> GetAll();
        List<T> GetActives();
        List<T> GetUpdated();

        List<T> GetDeleted();

        //Modify Command

        void Add(T item);

        void AddRange(List<T> list);

        void Delete(T item);

        void DeleteRange(List<T> list);

        void Update(T item);
        void UpdateRange(List<T> list);

        void Destroy(T item);

        void DestroyRange(List<T> list);


        //Linq Command


        List<T> Where(Expression<Func<T, bool>> exp);

        T FirstOrDefault(Expression<Func<T, bool>> exp);

        object Select(Expression<Func<T, object>> exp);

        IQueryable<X> SelectViaClass<X>(Expression<Func<T, X>> exp);

        bool Any(Expression<Func<T, bool>> exp);

        //Find Commad

        T Find(int id);



        //Get Last Data

        List<T> GetLastDatas(int number);

        //Get FirstData

        List<T> GetFirstDatas(int number);

    }
}
