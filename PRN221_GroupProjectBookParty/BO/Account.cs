namespace BO;

public class Account
{
    public Account()
    {
        BlogPosts = new HashSet<BlogPost>();
        Bookings = new HashSet<Booking>();
        FeedBacks = new HashSet<FeedBack>();
        Parties = new HashSet<Party>();
    }

    public int Id { get; set; }
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string? Phone { get; set; }
    public string? Gender { get; set; }
    public string? Role { get; set; }
    public bool Status { get; set; }

    public virtual ICollection<BlogPost> BlogPosts { get; set; }
    public virtual ICollection<Booking> Bookings { get; set; }
    public virtual ICollection<FeedBack> FeedBacks { get; set; }
    public virtual ICollection<Party> Parties { get; set; }
}