using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScarp.Entities.Entites;

namespace WebScarp.Bussıness.Services.Interface
{
    public  interface INewsServices
    {
        public Task<List<News>?> GetAllNews();
        public Task<bool> CreateMany(List<News> news);
        public Task<bool> Create(News news);
    }
}
