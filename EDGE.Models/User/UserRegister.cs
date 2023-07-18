// Register model 
// Reference ElevenNote UserRegisterModel

using System.ComponentModel.DataAnnotations;
namespace EDGE.Models.User;

public class UserRegister
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    [MinLength(4)]
    public string Username { get; set; } = string.Empty;

    [Required]
    [MinLength(4)]
    public string Password { get; set; } = string.Empty;

    [Compare(nameof(Password))]
    public string ConfirmPassword { get; set; } = string.Empty;

}