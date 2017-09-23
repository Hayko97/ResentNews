using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpSystems.Goals.RecentNews.Core.DataAccess;
using HelpSystems.Goals.RecentNews.Core.DataAccess.Entities;
using HelpSystems.Goals.RecentNews.Core.Interfaces;

namespace HelpSystems.Goals.RecentNews.Core.Repository
{
    public class ApiRepository :RepositoryBase, IRepository<Api>
    {
       
        private static ApiRepository instance;
        public static ApiRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ApiRepository();
                }
                return instance;
            }
        }
        private ApiRepository()
        {           
        }

        public IEnumerable<Api> SelectAll()
        {
            try
            {
                var apiList = Connection.Table<Api>().ToList();
                return apiList;
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public IEnumerable<Api> Select(Func<Api, bool> predicate)
        {
            try
            {
                var apiList = Connection.Table<Api>().Where(predicate);
                return apiList;
            }
            catch (Exception)
            {
                Console.WriteLine();
                throw;
            }
        }

        public DataStatus Update(Api model)
        {
            try
            {
                Connection.Update(model);
                return DataStatus.Success;
            }
            catch (Exception e)
            {
                return DataStatus.Faiiled;
            }

        }

        public DataStatus Insert(Api model)
        {
            throw new NotImplementedException();
        }

   
        public bool IsActive(int id)
        {
            var api = Connection.Table<Api>().First(x => x.Id == id);
            if (api.IsActive)
                return true;

            return false;
        }
    }
}
