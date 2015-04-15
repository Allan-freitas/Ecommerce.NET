using System;
using System.Linq;
using Ecommerce.DAO.Interfaces;
using System.Linq.Expressions;
using System.Data.Objects;

namespace Ecommerce.DAO
{
    public abstract class AbstractCRUD<T> : IBaseCRUD<T> where T : class
    {
        LojaVirtual lojaBanco = new LojaVirtual();

        public void Add(T pEntity)
        {
            lojaBanco.AddObject(pEntity.GetType().Name, pEntity);
        }

        public void Delete(T pEntity)
        {
            lojaBanco.DeleteObject(pEntity);
        }

        public void Attach(T pEntity)
        {
            lojaBanco.AttachTo(pEntity.GetType().Name, pEntity);
        }

        public void Detach(T pEntity)
        {
            throw new NotImplementedException();
        }

        public void Update(T pEntity)
        {
            lojaBanco.ApplyCurrentValues<T>(pEntity.GetType().Name, pEntity);
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> where)
        {
            return lojaBanco.CreateObjectSet<T>().Where(where);
        }

        public IQueryable<T> getAll()
        {
           return lojaBanco.CreateObjectSet<T>();
        }

        public void SaveChanges()
        {
            lojaBanco.SaveChanges();            
        }

        public ObjectResult<T> ExecuteSQL<T>(string sql, params object[] parameters) 
        {
            return lojaBanco.ExecuteStoreQuery<T>(sql, parameters);
        } 
    }
}
