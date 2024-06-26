﻿namespace AutoYa_Backend.AutoYa.Domain.Models;

public class Car
{
    public int Id { get; set; }
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
    public string Status { get; set; }
    
    public int PropietaryId { get; set; }
    public Propietary Propietary { get; set; }
    public IList<CarDocumentation> CarDocumentations { get; set; }
    public IList<CarPhoto> CarPhotos { get; set; }
    public IList<Rent> Requests { get; set; }
    public IList<CarReview> CarReviews { get; set; }
}