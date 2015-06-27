using System.Collections.Generic;
using Microsoft.Data.Entity;

namespace FullStack.Data
{
    public class FullStackContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=FullStack;Trusted_Connection=True;MultipleActiveResultSets=True");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserRole>().Key(ur => new { ur.UserId, ur.RoleId});
            
            builder.Entity<User>()
                .Collection(u => u.UserRoles)
                .InverseReference(ur => ur.User)
                .ForeignKey(ur => ur.UserId);

            builder.Entity<Role>()
                .Collection(u => u.UserRoles)
                .InverseReference(ur => ur.Role)
                .ForeignKey(ur => ur.RoleId);
        }
    }

    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }

    public class UserRole
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }

    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
