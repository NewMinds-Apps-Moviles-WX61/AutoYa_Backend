using System.ComponentModel.DataAnnotations;

namespace AutoYa_Backend.AutoYa.Resources.POST;

public class LoginResource
{
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}