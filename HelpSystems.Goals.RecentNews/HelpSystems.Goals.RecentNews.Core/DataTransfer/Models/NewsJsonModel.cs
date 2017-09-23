using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpSystems.Goals.RecentNews.Core.DataTransfer.Models
{
    public class Article
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string UrlToImage { get; set; }
        public string PublishedAt { get; set; }
    }

    public class NewsJsonModel
    {
        public string Status { get; set; }
        public string Source { get; set; }
        public string SortBy { get; set; }
        public IList<Article> Articles { get; set; }
    }

}
