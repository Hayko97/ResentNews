using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;


using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
using HelpSystems.Goals.RecentNews.Common;
using HelpSystems.Goals.RecentNews.Core;
using HelpSystems.Goals.RecentNews.Core.DataAccess;
using HelpSystems.Goals.RecentNews.Core.DataAccess.Entities;
using HelpSystems.Goals.RecentNews.Core.DataTransfer;
using HelpSystems.Goals.RecentNews.Core.DataTransfer.Models;
using HelpSystems.Goals.RecentNews.Core.Repository;
using HelpSystems.Goals.RecentNews.Library;
using System.IO;

namespace HelpSystems.Goals.RecentNews
{
    public partial class Service1 : ServiceBase
    {

        private Timer _timer;
        private ApiRepository apiRepo = ApiRepository.Instance;
        private NewsRepository newsRepo = NewsRepository.Instance;
        private RequestBuilder request = RequestBuilder.Instance;
        public Service1()
        {
            InitializeComponent();
        }
        public void OnDebug()
        {
            OnStart(null);
        }
        protected override void OnStart(string[] args)
        {

#if DEBUG
            Log.Write("Service started");
         
            SendNewsNotification(null, null);
#else
            Log.Write("Info - Service Started");
            _timer = new Timer(3000);
            _timer.Elapsed += SendNewsNotification;
            _timer.Start(); 
#endif
        }
        private async void SendNewsNotification(object sender, ElapsedEventArgs e)
        {
            var apis = apiRepo.SelectAll();
            foreach (var item in apis)
            {
                if (item.IsActive)
                {
                    var resentNews = await request.GetModel<NewsJsonModel>(item.Uri);
                    var article = GetResentNew(resentNews);
                    if (article != null)
                    {
                       NotificationManager.SendNewNotification(article);
                       
                    }
                                

                }
            }


        }

        private Article GetResentNew(NewsJsonModel model)
        {
            var earliest =  model.Articles.OrderByDescending(x => x.PublishedAt).FirstOrDefault();
            var result = newsRepo.IsAvailable(earliest.Url);
            switch (result)
            {
                    case DataStatus.Exists:
                        return null;
                    case DataStatus.NotExists:
                        var news = new News
                        {
                            Link = earliest.Url,
                            PublishDate = earliest.PublishedAt,
                            AddedDate = DateTime.Now
                        };

                        newsRepo.Insert(news);
                        return earliest;
                default:
                    return null;

            }

        }

        protected override void OnStop()
        {
        }
    }
}
