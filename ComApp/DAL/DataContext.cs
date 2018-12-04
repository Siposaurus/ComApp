using ComApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web.Hosting;

namespace ComApp.DAL
{
    public class DataContext
    {
        private ComAppDatabaseEntities database = new ComAppDatabaseEntities();

        public List<ComData> Upload()
        {
            string path = ConfigurationManager.AppSettings["CSVFileLocation"];
            List<ComData> data = new List<ComData>();
            using (var reader = new StreamReader(HostingEnvironment.ApplicationPhysicalPath + path, System.Text.Encoding.Default))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    ComData item = new ComData(values[0], values[1], values[2], values[3], values[4]);
                    data.Add(item);
                }
            }
            return data;
        }

        public List<ComData> Save(List<ComData> data)
        {
            foreach (var item in data)
            {
                database.ComData.Add(item);
                database.SaveChanges();
            }
            data.Clear();
            return database.ComData.ToList();
        }

        public List<ComData> ComData()
        {
            return database.ComData.ToList();
        }

    }
}