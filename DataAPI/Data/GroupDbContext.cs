using DataAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAPI.Data
{
    public class GroupDbContext : DbContext
    {
        public GroupDbContext(DbContextOptions<GroupDbContext> options) : base(options)
        {
        }
        public DbSet<GroupEntity> Groups { get; set; }
        public DbSet<PersonEntity> Persons { get; set; }
    }
}
