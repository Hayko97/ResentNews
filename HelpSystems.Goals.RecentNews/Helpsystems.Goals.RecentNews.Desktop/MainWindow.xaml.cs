using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HelpSystems.Goals.RecentNews.Core.Repository;
using HelpSystems.Goals.RecentNews.Core.DataTransfer;
using HelpSystems.Goals.RecentNews.Core.DataTransfer.Models;
using HelpSystems.Goals.RecentNews.Core.DataAccess.Entities;
using Helpsystems.Goals.RecentNews.Desktop.Actions;

namespace Helpsystems.Goals.RecentNews.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ApiRepository apiRepo = ApiRepository.Instance;
        private RequestBuilder requestBuilder = RequestBuilder.Instance;
        private MessageBoxActions messageBox = MessageBoxActions.Instance;
        public MainWindow()
        {
            InitializeComponent();
            InitializeApiButtons(apiRepo.SelectAll());



        }

        private async void InitializeApiButtons(IEnumerable<Api> apis)
        {
            int index = 0;
            foreach (var item in apis)
            {
                var api = await requestBuilder.GetModel<NewsJsonModel>(item.Uri);
                Button newBtn = new Button();

                newBtn.Content = api.Source.ToUpper();
                newBtn.Name = BtnName(api.Source);
               
                var newMargin = newBtn.Margin;
                newMargin.Top= 5;
                newBtn.Margin = newMargin;
                newBtn.Tag = item;
                
                newBtn.Click += NewBtn_Click;
                buttonList.Children.Add(newBtn);
                index++;
            }
        }

        private void NewBtn_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var api = (Api)btn.Tag;
            if (api.IsActive)
                messageBox.ApiIsEnabled(Resourses.Messages.NewsDisableMessage, api);
            else
                messageBox.ApiIsEnabled(Resourses.Messages.NewsEnableMessage, api);



        }
   
        private string BtnName(string name)
        {
            char symbol = name.First(x => x == '-');
            if (symbol != null)
                return name.Replace('-', '_');
            return name;
        }


    }
}
