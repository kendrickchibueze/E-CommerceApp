using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification()
        {
        }


        //the criteria is where we want to get a product with a specific id
        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
            
        }

        public Expression<Func<T, bool>> Criteria {get;}

        public List<Expression<Func<T, object>>> Includes { get; } =
            new List<Expression<Func<T, object>>>();


        
        //we create a method that would allow us add include statements to our 
        //includes list
        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            
            Includes.Add(includeExpression);    
        }
    }
}
