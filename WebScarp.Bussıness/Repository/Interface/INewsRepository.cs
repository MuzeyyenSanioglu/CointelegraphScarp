using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScarp.Entities.Entites;

namespace WebScarp.Bussıness.Repository.Interface
{
    public  interface INewsRepository
    {
        Task<bool> Create(News news);
        Task<bool> CreateMany(List<News> news);
        Task<List<News>?> GetNews();
    }
}
