namespace Travel.API.Entities;

public class Location
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public int CountryId { get; set; }
    public virtual Country Country { get; set; }
    public virtual ICollection<Destination> Destinations { get; set; }
}
