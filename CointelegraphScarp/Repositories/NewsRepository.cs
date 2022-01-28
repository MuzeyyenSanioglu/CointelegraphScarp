//using CointelegraphScarp.DataAccess;
//using CointelegraphScarp.Entities;
//using CointelegraphScarp.Settings;
//using Microsoft.Extensions.Options;
//using MongoDB.Driver;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace CointelegraphScarp.Repositories
//{
//    public class NewsRepository : INewsRepository
//    {

//        private readonly IMongoCollection<News> _collection;
//        public NewsRepository(IOptions<DatabaseSettings> settings)
//        {
//            var client = new MongoClient(settings.Value.ConnectionString);
//            var database = client.GetDatabase(settings.Value.DatabaseName);
//            _collection = database.GetCollection<News>(settings.Value.CollectionName);
//        }


//        public async Task<bool> Create(News news)
//        {
//            try
//            {
//                await _collection.InsertOneAsync(news);
//                return true;
//            }
//            catch (MongoWriteException)
//            {
//                return false;
//            }
//        }
//        public async Task<bool> CreateMany(List<News> news)
//        {
//            try
//            {
//                await _collection.InsertManyAsync(news);
//                return true;
//            }
//            catch (MongoWriteException)
//            {
//                return false;
//            }
//        }
//        public async Task<List<News>?> GetNews()
//        {
//            try
//            {
//                return await _collection.FindAsync(m => true).Result.ToListAsync();
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e);
//                throw;
//            }
//        }
//    }

//}