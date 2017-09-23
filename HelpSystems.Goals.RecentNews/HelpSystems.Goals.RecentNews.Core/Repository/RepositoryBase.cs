using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpSystems.Goals.RecentNews.Core.DataAccess;
using HelpSystems.Goals.RecentNews.Core.DataAccess.Entities;
using SQLite;



namespace HelpSystems.Goals.RecentNews.Core.Repository
{
    public class RepositoryBase
    {
        protected SQLiteConnection Connection { get; set; }
        private System.Data.SQLite.SQLiteConnection n;
        protected  string DbPath 
        {
            get
            {
                string path = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString()).ToString()+"\\NewsDb.sqlite";

                return path;
            }
            
        }
        public RepositoryBase()
        {
            if (!IsDbAvailable())
            {
                CreateDb();
                Connection = new SQLiteConnection(DbPath);
                Initialize();
            }
            Connection = new SQLiteConnection(DbPath);



        }
        private bool IsDbAvailable()
        {
            try
            {
                if (!File.Exists(DbPath))
                {                  
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


        }

        private void CreateDb()
        {
            try
            {
                System.Data.SQLite.SQLiteConnection.CreateFile(DbPath);
                
            }
            catch (Exception e)
            {       
               
            }
           
        }

        private void Initialize()
        {
            try
            {
                Connection.CreateTable<Api>();
                Connection.InsertAll(InitializationInfo.Apis());
                Connection.CreateTable<News>();
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
