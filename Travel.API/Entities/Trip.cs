namespace Travel.API.Entities;

public class Trip
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public virtual User User { get; set; }
    public virtual ICollection<Destination> Destinations { get; set; }
}
