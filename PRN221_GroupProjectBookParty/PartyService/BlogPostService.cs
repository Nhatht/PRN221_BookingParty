using PartyRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyService
{
    public class BlogPostService : IBlogPostService
    {
        private IBlogPostRepo _blogPostRepo = null;
        public BlogPostService()
        {
            _blogPostRepo = new BlogPostRepo();
        }
    }
}
