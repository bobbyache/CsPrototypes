using Dapper;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace SqlLite.Tests.DAL
{
    public interface IEntityRepository<TEntity> where TEntity : class, new()
    {
        bool DeleteOne(TEntity entity);
        TEntity GetOne(long id);
        long InsertOne(TEntity entity);
        bool UpdateOne(TEntity entity);
    }

    public abstract class EntityRepository<TEntity> : IEntityRepository<TEntity>
    where TEntity : class, new()
    {
        private readonly IConnectionManager connectionManager;

        public EntityRepository(string connnectionString)
        {
            this.connectionManager = new ConnectionManager(connnectionString);
        }

        public EntityRepository(IConnectionManager connectionManager)
        {
            this.connectionManager = connectionManager;
        }

        protected List<TEntity> GetMany<TCriteria>(TCriteria criteria, string sql)
        {
            using (var conn = connectionManager.GetConnection())
            {
                conn.Open();
                
                using (var result = conn.QueryMultiple(
                    sql,
                    criteria,
                    commandType: System.Data.CommandType.Text
                ))
                {
                    return result.Read<TEntity>().ToList();
                }
            }
        }

        protected TEntity GetOne<TCriteria>(TCriteria criteria, string sql)
        {
            using (var conn = connectionManager.GetConnection())
            {
                conn.Open();

                using (var result = conn.QuerySingle(
                    sql,
                    criteria,
                    commandType: System.Data.CommandType.Text
                ))
                {
                    return result.Read<TEntity>().FirstOrDefault();
                }
            }
        }

        public TEntity GetOne(long id)
        {
            using (var conn = connectionManager.GetConnection())
            {
                conn.Open();

                return conn.Get<TEntity>(id);
            }
        }

        public long InsertOne(TEntity entity)
        {
            using (var conn = connectionManager.GetConnection())
            {
                conn.Open();
                return conn.Insert<TEntity>(entity);
            }
        }

        public bool DeleteOne(TEntity entity)
        {
            using (var conn = connectionManager.GetConnection())
            {
                conn.Open();
                return conn.Delete<TEntity>(entity);
            }
        }

        public bool UpdateOne(TEntity entity)
        {
            using (var conn = connectionManager.GetConnection())
            {
                conn.Open();
                return conn.Update<TEntity>(entity);
            }
        }
    }
}
