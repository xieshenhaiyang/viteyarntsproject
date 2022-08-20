using Blog.Entity;
using Blog.IRepository;
using Blog.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service
{
    public class BolgNewsService : BaseService<BlogNews>, IBolgNewsService
    {
        public BolgNewsService(IBaseRepository<BlogNews> baseRepository) : base(baseRepository)
        {

        }

         
    }
}
