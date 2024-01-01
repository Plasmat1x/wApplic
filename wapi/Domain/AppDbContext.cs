using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using wapi.Domain.Entities;
using wapi.Domain.Entities.Idenity;

namespace wapi.Domain {
    public class AppDbContext: IdentityDbContext<AppUser> {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {

        }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);

            #region Identity
            builder.Entity<AppUser>(ent => {
                ent.HasData(new AppUser {
                    Id = "b97ed420-63cd-43cd-814f-2bee8c0f46d4",
                    UserName = "Plasmat1x",
                    NormalizedUserName = "PLASMAT1X",
                    Email = "plasmat1xdev@gmail.com",
                    NormalizedEmail = "PLASMAT1XDEV@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "hackOFF1"),
                    SecurityStamp = string.Empty
                });

                ent.HasData(new AppUser {
                    Id = "5fe1d4fc-d6ea-43c7-a1f4-73d2f83032bd",
                    UserName = "User",
                    NormalizedUserName = "USER",
                    Email = "User@gmail.com",
                    NormalizedEmail = "USER@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "hackOFF1"),
                    SecurityStamp = string.Empty
                });
            });

            builder.Entity<IdentityRole>(ent => {
                ent.HasData(new IdentityRole {
                    Id = "087bb1c2-109b-427d-be77-e0799bf27af0",
                    Name = "admin",
                    NormalizedName = "ADMIN"
                });

                ent.HasData(new IdentityRole {
                    Id = "a061da55-fea2-4bb9-b5b9-e5d358587138",
                    Name = "user",
                    NormalizedName = "USER"
                });
            });

            builder.Entity<IdentityUserRole<string>>(ent => {
                ent.HasData(new IdentityUserRole<string> {
                    RoleId = "087bb1c2-109b-427d-be77-e0799bf27af0",
                    UserId = "b97ed420-63cd-43cd-814f-2bee8c0f46d4"
                },
                new IdentityUserRole<string> {
                    RoleId = "a061da55-fea2-4bb9-b5b9-e5d358587138",
                    UserId = "b97ed420-63cd-43cd-814f-2bee8c0f46d4"
                });

                ent.HasData(new IdentityUserRole<string> {
                    RoleId = "a061da55-fea2-4bb9-b5b9-e5d358587138",
                    UserId = "5fe1d4fc-d6ea-43c7-a1f4-73d2f83032bd"
                });

            });
            #endregion

            builder.Entity<Image>(ent => {
                ent.HasKey(x => x.Id);
                ent
                .HasOne<Article>(img => img.Article)
                .WithMany(arti => arti.Images)
                .HasForeignKey(img => img.ArticleId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            /* // Alt
            builder.Entity<Article>(ent => {
                ent.HasKey(x => x.Id);
                ent
                .HasMany<Image>(arti => arti.Images)
                .WithOne(img => img.Article)
                .HasForeignKey(img => img.ArticleId);
                .OnDelete(DeleteBehavior.Cascade);
            });
            */

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}
