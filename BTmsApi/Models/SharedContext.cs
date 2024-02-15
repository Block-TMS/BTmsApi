using Microsoft.EntityFrameworkCore;

namespace BTmsApi.Models;

public class SharedContext : DbContext
{
    public SharedContext(DbContextOptions<SharedContext> options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; }
}
