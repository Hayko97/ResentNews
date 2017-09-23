using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpSystems.Goals.RecentNews.Core.DataAccess.Entities;
using HelpSystems.Goals.RecentNews.Core.Interfaces;

namespace HelpSystems.Goals.RecentNews.Core.Repository
{
    public class NewsRepository:RepositoryBase,IRepository<News>
    {
        private static NewsRepository instance;
        public static NewsRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NewsRepository();
                }
                return instance;
            }
        }
        private NewsRepository()
        {
        }


        public IEnumerable<News> SelectAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<News> Select(Func<News, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public DataStatus Update(News model)
        {
            throw new NotImplementedException();
        }

        public DataStatus Insert(News model)
        {
            try
            {
                Connection.Insert(model);
                return DataStatus.Success;
            }
            catch (Exception )
            {
                return DataStatus.Faiiled;
            }
        }

        public DataStatus IsAvailable(string link)
        {
            var news = Connection.Table<News>().Where(x => x.Link == link).FirstOrDefault();
            if(news == null)
                return DataStatus.NotExists;

            return DataStatus.Exists;
        }

    }
}
