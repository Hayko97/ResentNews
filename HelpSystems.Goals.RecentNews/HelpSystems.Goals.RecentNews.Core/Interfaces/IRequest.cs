using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpSystems.Goals.RecentNews.Core.Interfaces
{
    public interface IRequest
    {
        //TModel Where<TModel>(Func<TModel,bool> model) where TModel : class;

        IEnumerable<TModel> GetList<TModel>(string url) where TModel : class;
        Task<TModel> GetModel<TModel>(string url) where TModel : class;

        Task<TDeserialize> GetModel<TSerialize, TDeserialize>(string url,TSerialize model) where TSerialize : class where TDeserialize : class;
        IEnumerable<TDeserialize> GetList<TSerialize,TDeserialize>(string url, TSerialize model) where TSerialize : class where TDeserialize : class;

    }
}
