using BO.enums;
using BO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PartyService.ViewModel;
using PartyService;
using System.Text.Json;

namespace PRN221_GroupProjectBookParty.Pages.Host.BlogPosts
{
    public class AddModel : PageModel
    {
        [BindProperty]
        public AddBlogModel AddBlogModelRequest { get; set; }

        [BindProperty]
        public string Tags { get; set; }

        private readonly IBlogPostService blogService;

        public AddModel(IBlogPostService blog) => blogService = blog;
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            var blog = new BlogPost()
            {
                Heading = AddBlogModelRequest.Heading,
                Content = AddBlogModelRequest.Content,
                PageTitle = AddBlogModelRequest.PageTitle,
                ShortDescription = AddBlogModelRequest.ShortDescription,
                ImageUrl = AddBlogModelRequest.ImageUrl,
                PublishedDate = AddBlogModelRequest.PublishedDate,
                AccountId = 2,
                Visible = AddBlogModelRequest.Visible,
            };
            await blogService.AddBlogPost(blog);

            var noti = new Notification
            {
                Type = NotificationType.Success,
                Message = "New Blog Post Created !"
            };
            TempData["Notification"] = JsonSerializer.Serialize(noti);
            return RedirectToPage("/Host/BlogPosts/List");
        }
    }
}
