using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.Forecast.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class, new()
    {
        DbSet<TEntity> DbSet { get; }
        
        //CRUD-Methoden
        //Create Methode
        void Add(TEntity t);
        Task AddAsync(TEntity t);


        //Read Methoden
        IQueryable<TEntity> ReadAll();
        Task<IQueryable<TEntity>> ReadAllAsync();
        TEntity ReadByKey(object key);
        Task<TEntity> ReadByKeyAsync(object key);


        //Update Methode
        void Update(TEntity t, object key);
        Task UpdateAsync(TEntity t, object key);


        //Delete Methode
        void Delete(object key);
        Task AsyncDelete(object key);






    }
}
