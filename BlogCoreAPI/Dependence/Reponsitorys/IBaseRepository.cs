using Ardalis.Specification;
using BlogCoreAPI.Model.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BlogCoreAPI.Dependence.Reponsitorys
{
    public interface IBaseRepository<T> where T : class
    {
        /* Task<T> GetByIdAsync<T>(Guid id) where T : BaseEntity;
         Task<List<T>> ListAsync<T>() where T : BaseEntity;
         Task<List<T>> ListAsync<T>(ISpecification<T> spec) where T : BaseEntity;
         Task<T> AddAsync<T>(T entity) where T : BaseEntity;
         Task<int> UpdateAsync<T>(T entity) where T : BaseEntity;
         Task DeleteAsync<T>(T entity) where T : BaseEntity;
         Task DeleteListAsync<T>(Expression<Func<T, bool>> expression) where T : BaseEntity;
         Task DeleteByIdAsync<T>(Guid id) where T : BaseEntity;
         IQueryable<T> Find<T>(Expression<Func<T, bool>> expression) where T : BaseEntity;
         Task<IQueryable<T>> ListReview<T>(ISpecification<T> spec) where T : BaseEntity;*/
        IEnumerable<T> GetAll();
        T GetByID(int ID);
        void Inser(T obj);
        void Delete(int ID);
        void Update(T obj);
        void Save();
        T Search(string a);
    }
}
