using Microsoft.AspNetCore.Identity;

namespace wapi.Domain.Entities.Idenity {
    public class AppUser: IdentityUser {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? Avatar { get; set; }
    }
}
