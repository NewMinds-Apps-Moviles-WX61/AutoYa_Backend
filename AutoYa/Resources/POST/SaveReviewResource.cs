﻿namespace AutoYa_Backend.AutoYa.Resources.POST;

public class SaveReviewResource
{
    public int Score { get; set; }
    
    // BodyInformation Attributes
    public string Text { get; set; }
    public string Date { get; set; }
    public string Time { get; set; }
    
    // Destination Attributes
    public string Issuer { get; set; }
    public string Category { get; set; }
    public int PropietaryId { get; set; }
    public int TenantId { get; set; }
}