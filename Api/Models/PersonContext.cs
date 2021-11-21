using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Api.Models

{
    public class PersonContext : DbContext
    {
        public PersonContext(DbContextOptions<PersonContext> options)
            : base(options)
        {
        }

        public DbSet<PersonItem> PersonItems { get; set; } = null;
    }
}
