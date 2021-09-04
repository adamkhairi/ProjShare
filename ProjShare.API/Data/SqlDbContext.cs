using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProjShare.Shared.Models;

namespace ProjShare.API.Data
{
    public class SqlDbContext : ApiAuthorizationDbContext<AppUser>
    {
        public SqlDbContext(DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
    }
}