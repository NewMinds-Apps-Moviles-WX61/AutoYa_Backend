namespace AutoYa_Backend.AutoYa.Resources.POST;

public class SaveCarResource
{
    public string Plate { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public string YearManufactured { get; set; }
    public string FuelType { get; set; }
    public string Transmission { get; set; }
    public string Category { get; set; }
    public string PassengerCapacity { get; set; }
    public string Color { get; set; }
    public string Mileage { get; set; }
    public string Condition { get; set; }
    public int Price { get; set; }
    public bool? AC { get; set; }
    public bool? GPS { get; set; }
    public string Location { get; set; }
    
    
    public int PropietaryId { get; set; }
}