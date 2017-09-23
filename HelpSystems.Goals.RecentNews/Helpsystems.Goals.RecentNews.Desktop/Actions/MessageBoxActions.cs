using HelpSystems.Goals.RecentNews.Core.DataAccess.Entities;
using HelpSystems.Goals.RecentNews.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Helpsystems.Goals.RecentNews.Desktop.Actions
{
     class MessageBoxActions
    {
        private static MessageBoxActions instance;
        public static MessageBoxActions Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MessageBoxActions();
                }
                return instance;
            }
        }
        private MessageBoxActions()
        {
        }
        private ApiRepository apiRepo = ApiRepository.Instance;
        public  void ApiIsEnabled(string message,Api model)
        {
            MessageBoxResult result = MessageBox.Show(message,Resourses.Constants.AplicationName , MessageBoxButton.OKCancel);
            switch (result)
            {
                case MessageBoxResult.OK:
                    model.IsActive = !model.IsActive;
                    apiRepo.Update(model);
                    break;
                case MessageBoxResult.Cancel:

                    break;

            }
        }
    }
}
