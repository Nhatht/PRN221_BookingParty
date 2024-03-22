using BO.enums;
using BO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PartyService.ViewModel;
using PartyService;
using System.Text.Json;

namespace PRN221_GroupProjectBookParty.Pages.Host.BlogPosts
{
    public class EditModel : PageModel
    {
        private readonly IBlogPostService blogService;
        [BindProperty]
        public BlogPost BlogPost { get; set; }
        [BindProperty]
        public string Tags { get; set; }
        public EditModel(IBlogPostService blog) => blogService = blog;
        public async Task OnGet(int id)
        {
            BlogPost = await blogService.GetBlogPostsByFilter(x => x.Id == id);
        }

        public async Task<IActionResult> OnPostEdit()
        {
            try
            {
                BlogPost.AccountId = BlogPost.AccountId;
                await blogService.EditBlogPost(BlogPost);
               
                ViewData["Notification"] = new Notification
                {
                    Message = "Record Updated Successfully !",
                    Type = NotificationType.Success
                };
            }
            catch (Exception ex)
            {
                ViewData["Notification"] = new Notification
                {
                    Message = "Something Went Wrong !" + ex,
                    Type = NotificationType.Error
                };
            }

            return Page();
        }

        public async Task<IActionResult> OnPostDelete()
        {
            var blog = await blogService.DeleteBlogPost(BlogPost.Id);
            if (blog)
            {
                var notification = new Notification
                {
                    Type = NotificationType.Success,
                    Message = "Blog was deleted successfully!"
                };

                TempData["Notification"] = JsonSerializer.Serialize(notification);

                return RedirectToPage("/Host/BlogPosts/List");
            }
            return Page();
        }
    }
}
