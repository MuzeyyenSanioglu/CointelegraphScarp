
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScarp.Bussıness.Repository.Interface;
using WebScarp.DataAccess.DataAccess.Interface;
using WebScarp.Entities.Entites;

namespace WebScarp.Bussıness.Repository
{
    public class NewsRepository : INewsRepository
    {
        private readonly INewsContext _context;
        public NewsRepository(INewsContext context)
        {
            _context = context;
        }
        public async Task<bool> Create(News news)
        {
            try
            {
                await _context.New.InsertOneAsync(news);
                return true;
            }
            catch (MongoWriteException)
            {
                return false;
            }
        }

        public async Task<bool> CreateMany(List<News> news)
        {
            try
            {
                await _context.New.InsertManyAsync(news);
                return true;
            }
            catch (MongoWriteException)
            {
                return false;
            }
        }

        public async Task<List<News>?> GetNews()
        {
            try
            {
                return await _context.New.FindAsync(m => true).Result.ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
