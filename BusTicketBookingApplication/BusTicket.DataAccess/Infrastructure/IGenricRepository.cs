using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.DataAccess.Infrastructure
{
    public interface IGenricRepository<T> where T:class
    {
        IEnumerable<T> GetAll(string? includeProperties = null);

        T GetFirstOrDefault(Expression<Func<T,bool>> predicate, string? includeProperties = null);

        void Insert(T obj);

        void Delete(T obj);

        void DeleteRange(IEnumerable<T> obj);
    }
}
