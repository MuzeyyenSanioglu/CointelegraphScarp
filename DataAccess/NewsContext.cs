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
        private readonly MongoClient _client;
        private readonly IMongoDatabase   _database;
        public  IMongoCollection<News> New { get; set; }
        public NewsContext(string ConnectionString, string DatabaseName,string CollectionName)
        {
            var _client = new MongoClient(ConnectionString);
            var _database = _client.GetDatabase(DatabaseName);

            New = _database.GetCollection<News>(CollectionName);
        }
        
        public IMongoClient Client => _client;
        public IMongoDatabase Database => _database;    
    }
}
