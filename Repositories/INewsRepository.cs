using CointelegraphScarp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CointelegraphScarp.Repositories
{
    public  interface INewsRepository
    {
        Task<bool> Create(News news);
        Task<bool> CreateMany(List<News> news);
        Task<List<News>?> GetNews();


    }
}
