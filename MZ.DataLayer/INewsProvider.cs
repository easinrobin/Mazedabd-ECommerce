using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MZ.Models;

namespace MZ.DataLayer
{
    public interface INewsProvider
    {
        List<News> GetAllNews();
        News GetNewsById(long? id);
        long InsertNews(News news);
        bool UpdateNews(News news);
        bool DeleteNews(long id);
        List<News> GetNewsBySearchKey(string searchKey);
    }
}
