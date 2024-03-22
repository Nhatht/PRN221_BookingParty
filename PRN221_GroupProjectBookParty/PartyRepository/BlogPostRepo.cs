using BO;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PartyRepository
{
    public class BlogPostRepo : IBlogPostRepo
    {
        public async Task<bool> AddBlogPost(BlogPost BlogPost) => await BlogPostDAO.Instance.AddBlogPost(BlogPost);

        public async Task<bool> DeleteBlogPost(int id) => await BlogPostDAO.Instance.DeleteBlogPost(id);

        public async Task<bool> EditBlogPost(BlogPost BlogPost) => await BlogPostDAO.Instance.EditBlogPost(BlogPost);
        public async Task<List<BlogPost>> GetAll() => await BlogPostDAO.Instance.GetAll();

        public async Task<List<BlogPost>> GetBlogPostsListByFilter(Expression<Func<BlogPost, bool>>? filter = null)
            => await BlogPostDAO.Instance.GetBlogPostsListByFilter(filter);
        public async Task<BlogPost> GetBlogPostsByFilter(Expression<Func<BlogPost, bool>>? filter = null)
            => await BlogPostDAO.Instance.GetBlogPostsByFilter(filter);
    }
}
