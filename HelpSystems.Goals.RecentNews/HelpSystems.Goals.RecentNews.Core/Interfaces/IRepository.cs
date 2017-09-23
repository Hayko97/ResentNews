using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpSystems.Goals.RecentNews.Core.Interfaces
{
    interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> SelectAll();
        IEnumerable<TEntity> Select(Func<TEntity, bool> predicate);

        DataStatus Update(TEntity model);
        DataStatus Insert(TEntity model);

      
    } 
}
