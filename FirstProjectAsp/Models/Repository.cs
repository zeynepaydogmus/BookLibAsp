﻿using FirstProjectAsp.Utility;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FirstProjectAsp.Models
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _applicationDbContext;
        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            this.dbSet = _applicationDbContext.Set<T>();
            _applicationDbContext.Books.Include(k => k.BookGenre);
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void btwDelete(IEnumerable<T> entities)
        {
           dbSet.RemoveRange(entities);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public T Get(Expression<Func<T, bool>> filter,string? includeProps = null)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            if (!string.IsNullOrEmpty(includeProps))
            {
                foreach (var includeProp in includeProps.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.FirstOrDefault();

        }

        public IEnumerable<T> GetAll(string? includeProps =  null)
        {
            IQueryable<T> query = dbSet;
            if (!string.IsNullOrEmpty(includeProps))
            {
                foreach(var includeProp in includeProps.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
                { 
                    query = query.Include(includeProp);
                }
            }
            return query.ToList();
        }
    }
}
