using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
using HelpSystems.Goals.RecentNews.Core.DataAccess.Entities;
using HelpSystems.Goals.RecentNews.Core.DataTransfer.Models;

namespace HelpSystems.Goals.RecentNews.Library
{
    public static class NotificationManager
    {
        public static void SendNewNotification(Article model)
        {
            string xml = $@"
<toast launch=""app-defined-string"">
  <visual>
    <binding template=""ToastGeneric"">
      <text>"+model.Title+@"</text>
      <text>"+model.Description+@"</text>
      
      <image src="""+model.UrlToImage+@""" />
      
    </binding>
  </visual>
  <actions>
    <action activationType=""foreground"" content=""Close"" arguments=""reviews"" />
    <action activationType=""protocol"" content=""Go to Page"" arguments=""microsoft-edge:"+model.Url+@""" />
  </actions>
     </toast>";



            XmlDocument doc = new XmlDocument();

            doc.LoadXml(xml);



            ToastNotification toast = new ToastNotification(doc);

            toast.Tag = "RecentNews";

            toast.Group = "group";



            ToastNotificationManager.CreateToastNotifier("ToastDesktop").Show(toast);
        }
    }
}
