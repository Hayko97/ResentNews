
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpSystems.Goals.RecentNews.Core.Interfaces;


namespace HelpSystems.Goals.RecentNews.Core.DataTransfer
{
    public class RequestBuilder : IRequest
    {
        private RequestExecution request = RequestExecution.Instance();

        private static RequestBuilder instance;
        public static RequestBuilder Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RequestBuilder();
                }
                return instance;
            }
        }
        private RequestBuilder()
        {
        }
        public IEnumerable<TModel> GetList<TModel>(string url) where TModel : class
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TDeserialize> GetList<TSerialize, TDeserialize>(string url,TSerialize model)
            where TSerialize : class
            where TDeserialize : class
        {
            throw new NotImplementedException();
        }

        public async Task<TModel> GetModel<TModel>(string url) where TModel : class
        {
            var response = await request.Get(url);

            string stringBody = await response.Content.ReadAsStringAsync();

            TModel deserializedModel = JsonConvert.DeserializeObject<TModel>(stringBody);
            return deserializedModel;
        }

        public async Task<TDeserialize> GetModel<TSerialize, TDeserialize>(string url, TSerialize model)
            where TSerialize : class
            where TDeserialize : class
        {
            string body = JsonConvert.SerializeObject(model);
            var response = await request.Post(url,body);

            string stringBody = await response.Content.ReadAsStringAsync();

            TDeserialize deserializedModel = JsonConvert.DeserializeObject<TDeserialize>(stringBody);
            return deserializedModel;
        }
    }
}
