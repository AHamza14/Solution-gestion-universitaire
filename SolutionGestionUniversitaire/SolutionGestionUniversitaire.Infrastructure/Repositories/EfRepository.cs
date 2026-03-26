using Microsoft.EntityFrameworkCore;
using SolutionGestionUniversitaire.SharedKernel;
using SolutionGestionUniversitaire.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolutionGestionUniversitaire.Infrastructure.Repositories
{
    public class EfRepository<T> : IAsyncRepository<T>, IRepository<T> where T :
                    BaseEntity, IAggregateRoot

    {
        protected readonly SolutionGestionUniversitaireContext _SGUContext;

        public EfRepository(SolutionGestionUniversitaireContext SGUContext)
        {
            _SGUContext = SGUContext;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await
             _SGUContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _SGUContext.Set<T>().ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _SGUContext.Set<T>().AddAsync(entity);
            await _SGUContext.SaveChangesAsync();
            return entity;

        }

        public async Task UpdateAsync(T entity)
        {
            _SGUContext.Entry(entity).State = EntityState.Modified;
            await _SGUContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _SGUContext.Set<T>().Remove(entity);
            await _SGUContext.SaveChangesAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return
            SpecificationEvaluator<T>.GetQuery(
              _SGUContext.Set<T>().AsQueryable(), spec);
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<T> ListAll()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<T> List(ISpecification<T> spec)
        {
            throw new NotImplementedException();
        }

        public T Add(T entity)
        {
            throw new NotImplementedException();
        }

        public int Update(T entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public int Count(ISpecification<T> spec)
        {
            throw new NotImplementedException();
        }
    }
}
