namespace BO;

public class Party
{
    public Party()
    {
        Bookings = new HashSet<Booking>();
        FeedBacks = new HashSet<FeedBack>();
    }

    public int Id { get; set; }
    public int HostId { get; set; }
    public string? Description { get; set; }
    public string Name { get; set; } = null!;
    public string City { get; set; } = null!;
    public decimal Price { get; set; }
    public string? Theme { get; set; }
    public string? Package { get; set; }
    public int MaxPeople { get; set; }
    public string ImageUrl { get; set; } = null!;
    public int Request { get; set; }
    public bool Status { get; set; }

    public virtual Account Host { get; set; } = null!;
    public virtual ICollection<Booking> Bookings { get; set; }
    public virtual ICollection<FeedBack> FeedBacks { get; set; }
}