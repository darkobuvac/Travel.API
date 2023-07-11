namespace Travel.API.Entities;

public class Country
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }

    public virtual ICollection<Location> Locations { get; set; }
}
