using Educator.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Educator.Models;

namespace Educator.Data;

public class EducatordbContext : IdentityDbContext<EducatorUser>
{
    public EducatordbContext(DbContextOptions<EducatordbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
       
    }

    public DbSet<Educator.Models.review>? review { get; set; }
}
