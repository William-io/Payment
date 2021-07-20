using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PaymentAPI.Repository
{
    public interface IRepository<T>
    {
        //Classe generica onde vai conte a assinatura dos métodos
        IQueryable<T> Get();
        Task<T> GetById(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }

}