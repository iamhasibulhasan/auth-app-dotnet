
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AuthAppDotNet.Domain.Users;

public sealed class ApplicationUser : IdentityUser<int>
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    public string Address { get; set; }
    public int StatusId { get; set; }
    public bool IsAdmin { get; set; }
}
