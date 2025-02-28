using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CapaDatos
{
    internal class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlServer("Server=DESKTOP-PKV8IPB\\SQLEXPRESS;Database=CintaRosa;Trusted_Connection=True;TrustServerCertificate=True;")
            .Options;
            return new AppDbContext(optionsBuilder);
        }
    }
}
