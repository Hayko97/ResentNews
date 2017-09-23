using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpSystems.Goals.RecentNews.Common
{
    public static class Log
    {

        public static void Write(Exception ex)
        {
            StreamWriter sw;
            try
            {
                sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\Log_.txt", true);
                sw.WriteLine(DateTime.Now + " " + ex.Source.Trim() + "; " + ex.Message.Trim());
                sw.Flush();
                sw.Close();
            }
            catch(Exception)
            {
                
            }

        }
        public static void Write(string message)
        {
            StreamWriter sw;
            try
            {
                sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\Log_.txt", true);
                sw.WriteLine(DateTime.Now + ": " + message);
                sw.Flush();
                sw.Close();
            }
            catch(Exception)
            {

            }

        }
    }
}
