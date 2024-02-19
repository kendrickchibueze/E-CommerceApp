﻿using Core.Specifications;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Infrastructure.Interfaces
{
    public interface IRepository<T>
    {
        T Add(T obj);

        Task<T> AddAsync(T obj);

        //added
        T FindById(int id);
        Task<IReadOnlyList<T>> ListAllAsync();

        IEnumerable<T> Find(ISpecification<T> specification = null);
        bool Contains(ISpecification<T> specification = null);
        int Count(ISpecification<T> specification = null);
        Task<T> GetEntityWithSpec(ISpecification<T> spec);
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
        Task<int> CountAsync(ISpecification<T> spec);

        //----

        void AddRange(IEnumerable<T> records);

        Task AddRangeAsync(IEnumerable<T> records);

        long Count(Expression<Func<T, bool>> predicate = null);

        Task<long> CountAsync(Expression<Func<T, bool>> predicate = null);

        Task<decimal> SumAsync(Expression<Func<T, decimal>> predicate);

        Task<int> SumAsync(Expression<Func<T, int>> predicate);

        Task<long> SumAsync(Expression<Func<T, long>> predicate);

        bool Delete(Expression<Func<T, bool>> predicate);

        bool Delete(T obj);

        //check here
        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IQueryable<T>> include = null);

        Task DeleteAsync(Expression<Func<T, bool>> predicate);

        Task DeleteAsync(T obj);

        bool DeleteById(object id);

        Task DeleteByIdAsync(object id);

        bool DeleteRange(Expression<Func<T, bool>> predicate);

        bool DeleteRange(IEnumerable<T> records);

        Task DeleteRangeAsync(Expression<Func<T, bool>> predicate);

        Task DeleteRangeAsync(IEnumerable<T> records);

        void Dispose();

        IEnumerable<T> GetAll(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params string[] includeProperties);

        Task<IEnumerable<T>> GetAllAsync(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);


        IEnumerable<T> GetBy(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, int? skip = null, int? take = null, params string[] includeProperties);

        //Task<PagedList<T>> GetPagedItems(RequestParameters parameters, Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);

        Task<IEnumerable<T>> GetByAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, int? skip = null, int? take = null, params string[] includeProperties);
        Task<IEnumerable<T>> GetByAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, int? skip = null, int? take = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        Task<T> GetSingleByAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, int? skip = null, int? take = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool tracking = false);


        Task<T> LastAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool disableTracking = true);
        T GetById(object id);

        /* Task<T> GetByIdAsync(object id);*/
        Task<T> GetByIdAsync(string id);



        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate = null);

        bool Any(Expression<Func<T, bool>> predicate = null);

        IQueryable<T> GetQueryable(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, int? skip = null, int? take = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);

        T GetSingleBy(Expression<Func<T, bool>> predicate);

        Task<T> GetSingleByAsync(Expression<Func<T, bool>> predicate);

        int Save();

        Task<int> SaveAsync();

        T Update(T obj);

        Task<T> UpdateAsync(T obj);
        Task UpdateRangeAsync(IEnumerable<T> records);
        void UpdateRange(IEnumerable<T> records);
    }
}
