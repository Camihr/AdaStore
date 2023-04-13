using AdaStore.Shared.Enums;
using Microsoft.AspNetCore.Identity;

namespace AdaStore.Shared.Models
{
    public class User : IdentityUser<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Document { get; set; }
        public string Password { get; set; }
        public Profiles Profile { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
