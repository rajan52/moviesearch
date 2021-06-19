using movieSearch.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace movieSearch.Commondal
{
    public  class CommonDal<AnyType> : IRepository<AnyType>
    {
        protected string ConnectionString = "";
        public static List<AnyType> AnyTypes = new List<AnyType>();
        public CommonDal()
        {
            
        }
        
        public virtual void Add(AnyType obj)
        {
            AnyTypes.Add(obj);
        }

        public virtual void Update(AnyType obj)
        {
            throw new NotImplementedException();
        }

        public virtual List<AnyType> Search(Func<AnyType,bool> lambda, string sortcolumn,bool isDescending)
        {
            return AnyTypes.Where(lambda).AsQueryable().OrderByDynamic<AnyType>(sortcolumn, isDescending).ToList();
        }

        public virtual void Save()
        {
            throw new NotImplementedException();
        }
    }
    static class LinqExtensions
    {
        public static IQueryable<AnyType> OrderByDynamic<AnyType>(this IQueryable<AnyType> query, string sortColumn, bool descending)
        {
            // Dynamically creates a call like this: query.OrderBy(p =&gt; p.SortColumn)
            var parameter = Expression.Parameter(typeof(AnyType), "p");

            string command = "OrderBy";

            if (descending)
            {
                command = "OrderByDescending";
            }

            Expression resultExpression = null;

            var property = typeof(AnyType).GetProperty(sortColumn);
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExpression = Expression.Lambda(propertyAccess, parameter);
            resultExpression = Expression.Call(typeof(Queryable), command, new Type[] { typeof(AnyType), property.PropertyType },
               query.Expression, Expression.Quote(orderByExpression));
            return query.Provider.CreateQuery<AnyType>(resultExpression);
        }
    }
}
