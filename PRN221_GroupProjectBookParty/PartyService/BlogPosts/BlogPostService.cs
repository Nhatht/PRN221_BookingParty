using BO;
using PartyRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PartyService.BlogPosts
{
    public class BlogPostService : IBlogPostService
    {
        private IBlogPostRepo _blogPostRepo = null;
        public BlogPostService()
        {
            _blogPostRepo = new BlogPostRepo();
        }

        public async Task<bool> AddBlogPost(BlogPost BlogPost) => await _blogPostRepo.AddBlogPost(BlogPost);

        public async Task<bool> DeleteBlogPost(int id) => await _blogPostRepo.DeleteBlogPost(id);

        public async Task<bool> EditBlogPost(BlogPost BlogPost) => await _blogPostRepo.EditBlogPost(BlogPost);

        public async Task<List<BlogPost>> GetAll() => await _blogPostRepo.GetAll();

        public async Task<List<BlogPost>> GetBlogPostsListByFilter(Expression<Func<BlogPost, bool>>? filter = null)
            => await _blogPostRepo.GetBlogPostsListByFilter(filter);
        public async Task<BlogPost> GetBlogPostsByFilter(Expression<Func<BlogPost, bool>>? filter = null)
            => await _blogPostRepo.GetBlogPostsByFilter(filter);
    }
}
