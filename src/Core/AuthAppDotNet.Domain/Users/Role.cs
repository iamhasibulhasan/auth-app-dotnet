using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AuthAppDotNet.Domain.Users;

public sealed class Role : IdentityRole<int>
{
    [MaxLength(500)]
    public string Description { get; set; }
}
