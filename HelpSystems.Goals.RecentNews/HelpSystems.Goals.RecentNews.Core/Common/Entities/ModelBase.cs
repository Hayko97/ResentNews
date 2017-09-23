using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpSystems.Goals.RecentNews.Core.DataAccess.Entities
{
    public class ModelBase
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
    public static class InitializationInfo
    {
        public static List<Api> Apis()
        {
            var apiList = new List<Api>
            {
                new Api()
                {
                    Uri = "https://newsapi.org/v1/articles?source=abc-news-au&sortBy=top&apiKey=28ca7f58acc54d99acfbac46b4942156",
                    IsActive = true
                },new Api()
                {
                    Uri = "https://newsapi.org/v1/articles?source=al-jazeera-english&sortBy=top&apiKey=28ca7f58acc54d99acfbac46b4942156",
                    IsActive = false
                },new Api()
                {
                    Uri = "https://newsapi.org/v1/articles?source=ars-technica&sortBy=top&apiKey=28ca7f58acc54d99acfbac46b4942156",
                    IsActive = false
                },new Api()
                {
                    Uri = "https://newsapi.org/v1/articles?source=associated-press&sortBy=top&apiKey=28ca7f58acc54d99acfbac46b4942156",
                    IsActive = false
                }
            };
            return apiList;
        }
    }
}
