using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        //TEntity rep our product
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery,
            ISpecification<TEntity> spec)
        {
            var query = inputQuery;

            if(spec.Criteria != null)
            {
                //we are saying: get me a product where the product is whatsoever we 
                //specify in this criteria. So its basically a lambda expression 
                query = query.Where(spec.Criteria);
            }

            //This takes our two includes query in product repository and aggregates them and passes it into query
            query = spec.Includes.Aggregate(query,(current, include)=>current.Include(include));

            return query;
        }
    }
}
