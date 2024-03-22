using BO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PartyService.BlogPosts;
using PartyService.ViewModel;
using System.Text.Json;

namespace PRN221_GroupProjectBookParty.Pages.Host.BlogPosts
{
    public class ListModel : PageModel
    {
        private readonly IBlogPostService blogService;
        public List<BlogPost> Blogs { get; set; }
        public ListModel(IBlogPostService blog) => blogService = blog;
        public async Task OnGet()
        {
            var noti = (string)TempData["Notification"];
            if (noti != null)
            {
                ViewData["Notification"] = JsonSerializer.Deserialize<Notification>(noti);
            }
            Blogs = await blogService.GetAll();
        }
    }
}
