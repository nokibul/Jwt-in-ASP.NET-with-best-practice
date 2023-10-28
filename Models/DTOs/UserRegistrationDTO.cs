using System.ComponentModel.DataAnnotations;
namespace Agency.Models.DTOs;
public class UserRegistrationDTO
{
    [MaxLength(255)]
    public string FirstName { get; set; }

    [MaxLength(255)]
    public string LastName { get; set; }

    [Required]
    [MaxLength(255)]
    public string UserName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [MaxLength(255)]
    public string ContactNo { get; set; }

    [MaxLength(255)]
    public string Location { get; set; }

    [Required]
    [MaxLength(255)]
    public string Gender { get; set; }

    [MaxLength(255)]
    public string About { get; set; }

    [MaxLength(255)]
    public string ProfileImage { get; set; }

    [MaxLength(255)]
    public string Password { get; set; }

    [MaxLength(255)]
    public string Language { get; set; }
}
