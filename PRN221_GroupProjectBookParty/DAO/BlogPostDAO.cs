using BO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class BlogPostDAO
    {
        private static BlogPostDAO instance = null;
        private readonly BookingPartyContext dbContext = null;
        public BlogPostDAO()
        {
            if(dbContext == null)
            {
                dbContext = new BookingPartyContext();
            }
        }
        public static BlogPostDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BlogPostDAO();
                }
                return instance;
            }
        }
        public async Task<List<BlogPost>> GetAll() => await dbContext.BlogPosts.AsNoTracking().Include(x => x.Account).AsNoTracking().ToListAsync();
        public async Task<bool> AddBlogPost(BlogPost BlogPost)
        {
            try
            {
                await dbContext.BlogPosts.AddAsync(BlogPost);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> DeleteBlogPost(int id)
        {
            BlogPost BlogPost =await  GetBlogPostById(id);
            try
            {
                dbContext.BlogPosts.Remove(BlogPost);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task <BlogPost> GetBlogPostById(int id)
        {
            return await dbContext.BlogPosts.AsNoTracking().FirstOrDefaultAsync (x => x.Id == id);
        }

        public async Task<bool> EditBlogPost(BlogPost BlogPost)
        {
           
            try
            {
                dbContext.BlogPosts.Update(BlogPost);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<BlogPost>> GetBlogPostsListByFilter(Expression<Func<BlogPost, bool>>? filter = null)
        {
            IQueryable<BlogPost> query = dbContext.BlogPosts;
            if (filter != null)
            {
                query = query.Include(x => x.Account).Where(filter);
            }
            return await query.ToListAsync();
        }

        public async Task<BlogPost> GetBlogPostsByFilter(Expression<Func<BlogPost, bool>>? filter = null)
        {
            IQueryable<BlogPost> query = dbContext.BlogPosts;
            if (filter != null)
            {
                query = query.AsNoTracking().Include(x => x.Account).AsNoTracking().Where(filter);
            }
            return await query.FirstOrDefaultAsync();
        }
    }
}

