using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatBox.BLL.Repository.Base
{
    interface IBaseRepository<T> where T : class
    {
        BeatBox.DAL.ORM.Context.BeatBoxContext db { get; }

        DbSet<T> dbset { get; }


    }
}
