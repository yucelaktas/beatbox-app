using BeatBox.BLL.Repository.Base;
using BeatBox.DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeatBox.DAL.ORM.Context;
using System.Data.Entity;

namespace BeatBox.BLL.Repository.Entity
{
    public class SongDetailRepository : IBaseRepository<SongDetail>
    {
        public BeatBoxContext db
        {
            get
            {
                return new BeatBoxContext();
            }
        }

        public DbSet<SongDetail> dbset
        {
            get
            {
                return db.Set<SongDetail>();
            }
        }

        public void Insert(SongDetail entity)
        {
            dbset.Add(entity);
            db.SaveChanges();
        }
    }
}
