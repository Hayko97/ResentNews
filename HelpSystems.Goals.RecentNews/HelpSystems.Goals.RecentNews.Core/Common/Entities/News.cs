using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpSystems.Goals.RecentNews.Core.DataAccess.Entities
{
    public class News: ModelBase
    {
        [Indexed]       
        public int ApiId { get; set; }
        public string Link { get; set; }
        public string PublishDate { get; set; }
        public DateTime AddedDate { get; set; }

    }
}
