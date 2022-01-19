using CointelegraphScarp.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CointelegraphScarp.DataAccess
{
    public  class NewsContext
    {
        private string ConnectionString;
        private string DatabaseName;
       public NewsContext(string ConnectionString, string DatabaseName)
        {
            var client = new MongoClient(ConnectionString);
            var database = client.GetDatabase(DatabaseName);
        }
       public  IMongoCollection<News> New { get; set; }
    }
}
