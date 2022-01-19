using CointelegraphScarp.DataAccess;
using CointelegraphScarp.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CointelegraphScarp.Repositories
{
    public class NewsRepository
    {

        private readonly NewsContext _context;

        public NewsRepository(NewsContext context)
        {
            _context = context;
        }

        public async Task Create(News news)
        {
            await _context.New.InsertOneAsync(news);
        }
        public async Task<IEnumerable<News>> GetNews()
        {
            return await _context.New.Find(p => true).ToListAsync();
        }
    }

}