﻿namespace AutoYa_Backend.AutoYa.Domain.Models;

public class CarReview
{
    public int Id { get; set; }
    public int Score { get; set; }
    
    public int CarId { get; set; }
    public int TenantId { get; set; }
    public int BodyInformationId { get; set; }
}