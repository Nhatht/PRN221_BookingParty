namespace BO;

public class Booking
{
    public int Id { get; set; }
    public int GuestId { get; set; }
    public int PartyId { get; set; }
    public decimal TotalPrice { get; set; }
    public int NumberOfPeople { get; set; }
    public string? Inquiry { get; set; }
    public DateTime StartDate { get; set; }
    public bool Status { get; set; }

    public virtual Account Guest { get; set; } = null!;
    public virtual Party Party { get; set; } = null!;
}