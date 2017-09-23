using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpSystems.Goals.RecentNews.Core.DataAccess.Entities
{
    public class Api:ModelBase
    {
        
        public string Uri { get; set; }
        public bool IsActive { get; set; }

    }
  
}
