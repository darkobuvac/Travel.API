namespace Travel.API.Entities;

public class DestinationTrip
{
    public int DestinationId { get; set; }
    public int TripId { get; set; }
    public DateTime ArrivalDate { get; set; }
    public DateTime DepartureDate { get; set; }
}
