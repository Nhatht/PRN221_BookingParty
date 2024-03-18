using PartyRepository;

namespace PartyService;

public class BlogPostService : IBlogPostService
{
    private IBlogPostRepo _blogPostRepo;

    public BlogPostService()
    {
        _blogPostRepo = new BlogPostRepo();
    }
}