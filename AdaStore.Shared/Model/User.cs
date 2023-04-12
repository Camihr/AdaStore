using AdaStore.Shared.Enums;
using Microsoft.AspNetCore.Identity;

namespace AdaStore.Shared.Model
{
    public class User : IdentityUser<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string NickName { get; set; }
        public string Document { get; set; }
        public string Password { get; set; }
        public Profiles Profile { get; set; }
    }
}
