using BO;
using PartyRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        private readonly IBlogPostRepo _repo = null;

        public async Task<bool> AddBlogPost(BlogPost BlogPost) => await _repo.AddBlogPost(BlogPost);

        public async Task<bool> DeleteBlogPost(int id) => await _repo.DeleteBlogPost(id);

        public async Task<bool> EditBlogPost(BlogPost BlogPost) => await _repo.EditBlogPost(BlogPost);

        public async Task<List<BlogPost>> GetAll() => await _repo.GetAll();

        public async Task<List<BlogPost>> GetBlogPostsListByFilter(Expression<Func<BlogPost, bool>>? filter = null)
            => await _repo.GetBlogPostsListByFilter(filter);
        public async Task<BlogPost> GetBlogPostsByFilter(Expression<Func<BlogPost, bool>>? filter = null)
            => await _repo.GetBlogPostsByFilter(filter);
    }
}
