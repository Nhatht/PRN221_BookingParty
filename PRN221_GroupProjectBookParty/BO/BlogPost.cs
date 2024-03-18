namespace BO;

public class BlogPost
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public string Heading { get; set; } = null!;
    public string PageTitle { get; set; } = null!;
    public string Content { get; set; } = null!;
    public string ShortDescription { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public DateTime PublishedDate { get; set; }
    public bool Visible { get; set; }

    public virtual Account Account { get; set; } = null!;
}