using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FirstProjectAsp.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public int StudentNumber { get; set; }
        public string? Adress { get; set; }
        public string? Faculty { get; set; }
        public string? Department { get; set; }
    }
}
