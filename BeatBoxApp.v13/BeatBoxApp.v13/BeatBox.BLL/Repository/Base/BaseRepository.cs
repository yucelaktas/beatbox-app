using BeatBox.DAL.ORM.Context;
using BeatBox.DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace BeatBox.BLL.Repository.Base
{
    public class BaseRepository<T> where T : BaseEntity
    {
        BeatBoxContext db;
        protected DbSet<T> dbset;
        public BaseRepository()
        {
            db = new BeatBoxContext();
            dbset = db.Set<T>();
        }

        public int Save()
        {
            return db.SaveChanges();
        }


        #region Insert
        public virtual int Insert(T entity)
        {
            try
            {
                entity.InsertDate = DateTime.Now;
                entity.IsActive = true;
                entity.IsDeleted = false;
                dbset.Add(entity);
                return Save();
            }
            catch
            {
                return 0;
            }
        }

        public virtual int InsertRange(ICollection<T> entities)
        {
            try
            {
                foreach (var entity in entities)
                {
                    entity.InsertDate = DateTime.Now;
                    entity.IsActive = true;
                    entity.IsDeleted = false;
                }
                return Save();
            }
            catch
            {
                return 0;
            }
        }
        #endregion

        #region Delete
        public int Delete(int? id)
        {
            T entity = dbset.Find(id);

            if (entity != null)
            {
                entity.IsActive = false;
                entity.IsDeleted = true;
                return Save();
            }
            return 0;
        }

        public int SuperDelete(int? id)
        {
            T entity = dbset.Find(id);

            if (entity != null)
            {
                dbset.Remove(entity);
                return Save();
            }
            return 0;
        }
        #endregion

        #region Update
        public int Update(T newEntity)
        {
            T oldEntity = dbset.Find(newEntity.Id);

            if (oldEntity != null)
            {
                try
                {
                    newEntity.IsActive = oldEntity.IsActive;
                    newEntity.IsDeleted = oldEntity.IsDeleted;
                    newEntity.InsertDate = oldEntity.InsertDate;
                    newEntity.UpdateDate = DateTime.Now;
                    db.Entry(oldEntity).CurrentValues.SetValues(newEntity);
                    return Save();
                }
                catch
                {
                    return 0;
                }
            }
            return 0;
        }


        public int UpdateIsActive(int? id,bool IsActive=true,bool IsDeleted= false )
        {
            T entity = dbset.Find(id);
            if (entity!=null)
            {
                entity.IsActive = IsActive;
                entity.IsDeleted = IsDeleted;
                return Save();
            }
            return 0;
            
        }
        #endregion

        #region Get
        public List<T> GetAll()
        {
            return dbset.ToList();
        }

        public T SelectById(int id)
        {
            return dbset.FirstOrDefault(x => x.Id == id);
        }
        public List<T> GetByActiveState(bool isActive = true)
        {
            return dbset.Where(x => x.IsActive == isActive).ToList();
        }

        public List<T> GetByState(bool isActive, bool? isDeleted = false)
        {
            if (isActive == true && isDeleted == true)
                return null;

            return dbset.Where(x => x.IsActive == isActive && x.IsDeleted == isDeleted).ToList();
        }

        public List<T> GetByCondination(Expression<Func<T, bool>> predicate)
        {
            return dbset
                .Where(x => x.IsActive == true && x.IsDeleted == false)
                .Where(predicate).ToList();
        }

        public List<T> GetByCondination(Expression<Func<T, bool>> predicate, bool? isActive = true, bool? isDeleted = false)
        {
            if (isActive == true && isDeleted == true)
                return null;

            else if (isActive == true && isDeleted == false)
                return GetByCondination(predicate);

            return dbset
                .Where(x => x.IsActive == isActive && x.IsDeleted == isDeleted)
                .Where(predicate).ToList();

        }

        public T GetFirstByCondination(Expression<Func<T, bool>> predicate)
        {
            return dbset.FirstOrDefault(predicate);
        } 
        #endregion

    }
}
