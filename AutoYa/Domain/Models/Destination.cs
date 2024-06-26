﻿namespace AutoYa_Backend.AutoYa.Domain.Models;

public class Destination
{
    public int Id { get; set; }
    public string Issuer { get; set; }
    public string Category { get; set; }
    
    public int PropietaryId { get; set; }
    public Propietary Propietary { get; set; }
    public int TenantId { get; set; }
    public Tenant Tenant { get; set; }
    public Message Message { get; set; }
    public Review Review { get; set; }
}