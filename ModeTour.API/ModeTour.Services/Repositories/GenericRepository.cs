using ModeTour.Commons;
using QTS.Services.Interfaces;
using System.Data;

namespace ModeTour.Services.Repositories
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        public AppDbContext Context;
        public DatabaseClient database { get; set; }
        public GenericRepository(AppDbContext context)
        {
            this.Context = context;
            database = new DatabaseClient(GlobalData.connectionStrModeWeb3);

        }
        /// <summary>
        /// Fucntion to ensure all query use same transaction
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        protected virtual HttpResult Process(TEntity entity)
        {
            try
            {
                using (var tran = database.BeginTransaction())
                {
                    tran.Commit();
                    return new HttpResult(MessageCode.Success);
                }
            }
            catch (Exception ex)
            {
                return new HttpResult(MessageCode.Error, Functions.ToString(ex.Message));
            }
        }

        protected virtual Task<MessageCode> ProcessData(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> Select()
        {
            return Context.Set<TEntity>().AsQueryable();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().AsEnumerable();
        }

        public IEnumerable<TEntity> Where(Func<TEntity, bool> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public TEntity GetSingle(Func<TEntity, bool> predicate)
        {
            return Context.Set<TEntity>().Single(predicate);
        }

        public TEntity GetFirst(Func<TEntity, bool> predicate)
        {
            return Context.Set<TEntity>().First(predicate);
        }

        public void Add(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentException("object is null");

            Context.Set<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentException("object is null");

            Context.Set<TEntity>().Remove(entity);
        }

        public void Attach(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentException("object is null");

            Context.Set<TEntity>().Attach(entity);
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                Context.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
