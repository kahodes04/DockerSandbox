using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WCBackend.Classes
{
    public class DBInstance : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
           => optionsBuilder.UseNpgsql("Host=my_host;Database=my_db;Username=my_user;Password=my_pw");
    }
}
