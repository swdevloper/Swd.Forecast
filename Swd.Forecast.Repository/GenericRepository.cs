using Microsoft.EntityFrameworkCore;
using Serilog;
using Swd.Forecast.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Swd.Forecast.Repository
{
    public class GenericRepository<TEntity, TModel> : IGenericRepository<TEntity>
        where TEntity : class, new()
        where TModel : DbContext, new()
    {

        //Constants
        const string PROPERTY_CREATED = "Created";
        const string PROPERTY_CREATEDBY = "CreatedBy";
        const string PROPERTY_UPDATED = "Updated";
        const string PROPERTY_UPDATEDBY = "UpdatedBy";



        //Member
        private DbContext _dbContext;
        private DbSet<TEntity> _dbSet;


        //Properties
        public DbSet<TEntity> DbSet
        {
            get {return _dbSet;}
        } 


        //Constructors
        public GenericRepository()
        {
            Init(new TModel());

        }

        public GenericRepository(DbContext dbContext)
        {
            Init(dbContext);

        }


        //Methoden
        void Init(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();  
        }




        public void Add(TEntity t)
        {
            try
            {
                Log.Debug(string.Format("{0}: Entity adding", MethodBase.GetCurrentMethod().Name));
                _dbSet.Add(t);
                Log.Debug(string.Format("{0}: Entity added", MethodBase.GetCurrentMethod().Name));
                EntityHelper.SetOjectProperty(PROPERTY_CREATED, DateTime.Now, t);
                EntityHelper.SetOjectProperty(PROPERTY_CREATEDBY, System.Security.Principal.WindowsIdentity.GetCurrent().Name, t);
                _dbContext.SaveChanges();
                Log.Debug(string.Format("{0}: Entity saved", MethodBase.GetCurrentMethod().Name));
            }
            catch (Exception ex)
            {
                Log.Error(ex, string.Format("{0}: Error {1}", MethodBase.GetCurrentMethod().Name,ex.Message));
            }
        }

        public async Task AddAsync(TEntity t)
        {
            try
            {
                Log.Debug(string.Format("{0}: Entity adding", MethodBase.GetCurrentMethod().Name));
                await _dbSet.AddAsync(t);
                Log.Debug(string.Format("{0}: Entity added", MethodBase.GetCurrentMethod().Name));
                EntityHelper.SetOjectProperty(PROPERTY_CREATED, DateTime.Now, t);
                EntityHelper.SetOjectProperty(PROPERTY_CREATEDBY, System.Security.Principal.WindowsIdentity.GetCurrent().Name, t);
                await _dbContext.SaveChangesAsync();
                Log.Debug(string.Format("{0}: Entity saved", MethodBase.GetCurrentMethod().Name));
            }
            catch (Exception ex )
            {
                Log.Error(ex, string.Format("{0}: Error {1}", MethodBase.GetCurrentMethod().Name, ex.Message));
            }

        }



        public async Task AsyncDelete(object key)
        {
            try
            {
                TEntity t = await _dbSet.FindAsync(key);
                if (t != null)
                {
                    _dbSet.Remove(t);
                    await _dbContext.SaveChangesAsync();
                    Log.Debug(string.Format("{0}: Entity {1} deleted", MethodBase.GetCurrentMethod().Name, key));
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, string.Format("{0}: Error {1}", MethodBase.GetCurrentMethod().Name, ex.Message));
            }

        }

        public void Delete(object key)
        {
            try
            {
                TEntity t = _dbSet.Find(key);
                if (t != null)
                {
                    _dbSet.Remove(t);
                    _dbContext.SaveChanges();
                    Log.Debug(string.Format("{0}: Entity {1} deleted", MethodBase.GetCurrentMethod().Name, key));
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, string.Format("{0}: Error {1}", MethodBase.GetCurrentMethod().Name, ex.Message));
            }
  
        }



        public IQueryable<TEntity> ReadAll()
        {
            try
            {
                return _dbSet.AsQueryable();
            }
            catch (Exception ex)
            {
                Log.Error(ex, string.Format("{0}: Error {1}", MethodBase.GetCurrentMethod().Name, ex.Message));
                return null;
            }
            
        }

        public async Task<IQueryable<TEntity>> ReadAllAsync()
        {
            try
            {
                return _dbSet.AsQueryable();
            }
            catch (Exception ex) 
            {
                Log.Error(ex, string.Format("{0}: Error {1}", MethodBase.GetCurrentMethod().Name, ex.Message));
                return null;
            }
       
        }



        public TEntity ReadByKey(object key)
        {
            try
            {
                return _dbSet.Find(key);
            }
            catch (Exception ex)
            {
                Log.Error(ex, string.Format("{0}: Error {1}", MethodBase.GetCurrentMethod().Name, ex.Message));
                return null;
            }
       
        }

        public async Task<TEntity> ReadByKeyAsync(object key)
        {
            try
            {
                return await _dbSet.FindAsync(key);
            }
            catch (Exception ex)
            {
                Log.Error(ex, string.Format("{0}: Error {1}", MethodBase.GetCurrentMethod().Name, ex.Message));
                return null;
            }
        
        }



        public void Update(TEntity t, object key)
        {
            try
            {
                TEntity existingItem = _dbSet.Find(key);
                if (existingItem != null)
                {
                    _dbContext.Entry(existingItem).CurrentValues.SetValues(t);
                    EntityHelper.SetOjectProperty(PROPERTY_UPDATED, DateTime.Now, t);
                    EntityHelper.SetOjectProperty(PROPERTY_UPDATEDBY, System.Security.Principal.WindowsIdentity.GetCurrent().Name, t);
                    _dbContext.SaveChanges();
                    _dbContext.Entry(existingItem).Reload();
                    Log.Debug(string.Format("{0}: Entity {1} deleted", MethodBase.GetCurrentMethod().Name, key));
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, string.Format("{0}: Error {1}", MethodBase.GetCurrentMethod().Name, ex.Message));
            }


        }

        public async Task UpdateAsync(TEntity t, object key)
        {
            try
            {
                TEntity existingItem = await _dbSet.FindAsync(key);
                if (existingItem != null)
                {
                    _dbContext.Entry(existingItem).CurrentValues.SetValues(t);
                    EntityHelper.SetOjectProperty(PROPERTY_UPDATED, DateTime.Now, t);
                    EntityHelper.SetOjectProperty(PROPERTY_UPDATEDBY, System.Security.Principal.WindowsIdentity.GetCurrent().Name, t);
                    await _dbContext.SaveChangesAsync();
                    await _dbContext.Entry(existingItem).ReloadAsync();
                    Log.Debug(string.Format("{0}: Entity {1} deleted", MethodBase.GetCurrentMethod().Name, key));
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, string.Format("{0}: Error {1}", MethodBase.GetCurrentMethod().Name, ex.Message));
            }

        }
    }
}
