using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HelpSystems.Goals.RecentNews.Core.DataTransfer
{
    class RequestExecution
    {
        private static RequestExecution _instance;
        private HttpClient client;
        
       
        private RequestExecution()
        {
            
            client = new HttpClient();
        }
        public static RequestExecution Instance()
        {
            
            if (_instance == null)
            {
                _instance = new RequestExecution();
            }

            return _instance;
        }

        public async Task<HttpResponseMessage> Get(string url)
        {
            try
            {
                var response = await client.GetAsync(url);

                return response;
            }
            catch(Exception e)
            {
                return null;
            }
            
        }
        public async Task<HttpResponseMessage> Post(string uri, string body)
        {
            try
            {
                var response = await client.PostAsync(uri, new StringContent(body));
                return response;
            }
            catch(Exception e)
            {
                return null;
            }
        }
    }
}
