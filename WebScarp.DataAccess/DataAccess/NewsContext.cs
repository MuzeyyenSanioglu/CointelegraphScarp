using MongoDB.Driver;
using WebScarp.Common.Settings.Interface;
using WebScarp.DataAccess.DataAccess.Interface;
using WebScarp.Entities.Entites;

namespace WebScarp.DataAccess.DataAccess
{
    public class NewsContext : INewsContext
    {
        #region Field
        private readonly IDatabaseSettings _settings;
        private readonly MongoClient _client;
        private readonly IMongoDatabase _database;
        #endregion


        public NewsContext(IDatabaseSettings settings)
        {
            _settings = settings;
            _client = new MongoClient(settings.ConnectionString);
            _database = _client.GetDatabase(settings.DatabaseName);

            New = _database.GetCollection<News>(settings.CollectionName);
        }
        public IMongoCollection<News> New { get; set; } = null!;
    }
}
