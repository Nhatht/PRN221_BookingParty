using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PartyService.BlogPosts
{
    public interface IBlogPostService
    {
        Task<List<BlogPost>> GetAll();
        Task<bool> AddBlogPost(BlogPost BlogPost);
        Task<bool> DeleteBlogPost(int id);
        Task<bool> EditBlogPost(BlogPost BlogPost);
        Task<List<BlogPost>> GetBlogPostsListByFilter(Expression<Func<BlogPost, bool>>? filter = null);
        Task<BlogPost> GetBlogPostsByFilter(Expression<Func<BlogPost, bool>>? filter = null);
    }
}
