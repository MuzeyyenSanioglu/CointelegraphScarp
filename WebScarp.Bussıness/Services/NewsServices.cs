using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScarp.Bussıness.Repository.Interface;
using WebScarp.Bussıness.Services.Interface;
using WebScarp.Entities.Entites;

namespace WebScarp.Bussıness.Services
{
    public class NewsServices : INewsServices
    {
        private readonly INewsRepository _newsRepository;

        public NewsServices(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }
        public async Task<bool> Create(News news)
        {
            try
            {
                return await _newsRepository.Create(news);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> CreateMany(List<News> news)
        {

            try
            {
                var listofData = await _newsRepository.GetNews();
                if (listofData != null && listofData.Count() > 0)
                    news = news.Where(s => listofData.All(p => p.Head != s.Head)).ToList();
                await _newsRepository.CreateMany(news);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<List<News>?> GetAllNews()
        {
            try
            {
                return await _newsRepository.GetNews();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
