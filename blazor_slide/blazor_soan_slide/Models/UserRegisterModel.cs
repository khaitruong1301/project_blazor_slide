using System.ComponentModel.DataAnnotations;
namespace blazor_soan_slide.Models;
class UserRegisterModel
{
    [Required(ErrorMessage = "UserName is required")]
    [StringLength(50, ErrorMessage = "UserName cannot exceed 50 characters")]
    public string UserName { get; set; }
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Password is required")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long")]
    public string Password { get; set; }
    [Required(ErrorMessage = "Fullname is required")]
    public string Fullname { get; set; }
    [Required(ErrorMessage = "Gender is required")]
    [RegularExpression("Male|Female", ErrorMessage = "Gender must be Male, Female, or Other")]
    public string Gender { get; set; }
    [Phone(ErrorMessage = "Invalid Phone Number")]
    public string Phone { get; set; }
    [Required(ErrorMessage = "Country is required")]
    public string Country { get; set; }
}






