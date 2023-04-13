using AdaStore.Shared.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdaStore.Shared.Models
{
    public class User : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Document { get; set; }
        public Profiles Profile { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }

        [NotMapped]
        public string Password { get; set; }
    }
}
