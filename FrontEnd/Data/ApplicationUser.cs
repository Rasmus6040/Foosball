using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace FrontEnd.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    [StringLength(500)]
    public required string Name { get; set; }
}