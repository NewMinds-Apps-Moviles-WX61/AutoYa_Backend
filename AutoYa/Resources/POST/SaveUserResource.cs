namespace AutoYa_Backend.AutoYa.Resources.POST;

public class SaveUserResource
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public string DNI { get; set; }
    public string? PhotoURL { get; set; }
    public string Type { get; set; }
}