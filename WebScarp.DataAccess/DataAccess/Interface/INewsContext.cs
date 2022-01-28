using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScarp.Entities.Entites;

namespace WebScarp.DataAccess.DataAccess.Interface
{
    public interface INewsContext
    {
        public IMongoCollection<News> New { get; set; }
    }
}

