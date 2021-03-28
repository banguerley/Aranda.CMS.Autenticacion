using CMS.Authentication.DAL.Entidades.Interfaces;
using CMS.Authentication.DAL.Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Authentication.DAL.Repositorio
{
    public class RepositorioBase< T, Key> : IRepositorio<T, Key>
                where T : class, IEntidad<Key>
    {
        #region Propiedades de la clase
        public DbContext Context { get; set; }

        public DbTransaction Transaction { get; set; }

        public virtual DbSet<T> Table => Context.Set<T>();


        public virtual DbConnection Connection
        {
            get
            {
                var connection = Context.Database.Connection;

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                return connection;
            }
        }

        #endregion

        #region Constructor de la clase

        public RepositorioBase(DbContext context)
        {
            Context = context;
        }

        public RepositorioBase()
        {
            Context = CMSEntities.GetInstance();
        }

        #endregion

        #region Metodos de la clase

        public void Save()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {

                throw new Exception(ex.EntityValidationErrors.ToString());
            }

        }

        public virtual IQueryable<T> GetAll()
        {
            return Table.AsNoTracking();
        }

        public virtual T Get(Key id)
        {
            var entity =  GetAll().FirstOrDefault(ExpressionForId(id)); 

            if (entity == null)
            {
                throw new Exception("No se encontró el registro");
            }

            return entity;
        }

        public virtual T Insert(T entity)
        {
            entity =  Table.Add(entity);
            Context.SaveChanges();
            return entity;
        }

        public virtual T Update(T entity)
        {
            AttachIfNot(entity);
            Context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            Context.SaveChanges();            

            return entity;
        }

        public virtual void Delete(T entity)
        {
            AttachIfNot(entity);
            Table.Remove(entity);
        }

        protected virtual Expression<Func<T, bool>> ExpressionForId(Key id)
        {
            var lambdaParam = Expression.Parameter(typeof(T));

            var lambdaBody = Expression.Equal(
                Expression.PropertyOrField(lambdaParam, "Id"),
                Expression.Constant(id, typeof(Key))
                );

            return Expression.Lambda<Func<T, bool>>(lambdaBody, lambdaParam);
        }

        protected virtual void AttachIfNot(T entity)
        {
            var entry = Context.ChangeTracker.Entries().FirstOrDefault(ent => ent.Entity == entity);
            if (entry != null)
            {
                return;
            }

            Table.Attach(entity);
        }

        #endregion
    }
}
