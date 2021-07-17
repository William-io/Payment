using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace PaymentAPI.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbContext _context;

        /**
        Injetando uma instancia do DbContext
        */
        public Repository(DbContext context)
        {
            _context = context;
        }

        public IQueryable<T> Get()
        {
            return _context.Set<T>().AsNoTracking();
             //Faz o rastreamento se por acaso o update for necessario ser executado caso o SaveChanges seja chamado.
            //Como estou buscando as entidades desabilito o rastreamento com AsNoTracking e ganho a performance de uma linha de código.
        }
        public T GetById(Expression<Func<T, bool>> predicate)
        {
            /** SingleOrDefault
            Retorna um item que corresponde a um filtro específico ou lança um
            exceção, ou retorna o valor padrão para o tipo, se houver
            não exatamente uma correspondência.
            */
            return _context.Set<T>().SingleOrDefault(predicate);
            //Uma expressão lambida que vai comprar um ID de uma entidade.
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            /*Recebo a entidade e defino a entidade como modificada.
            Então informo ao contexto que essa entidade foi modificada.
            */
            _context.Set<T>().Update(entity);

            //E uso o update para atualizar as entidades que estão no contexto.
        }
    }

}