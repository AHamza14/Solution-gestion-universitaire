using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolutionGestionUniversitaire.Infrastructure
{
    public class SolutionGestionUniversitaireContextFactory : IDesignTimeDbContextFactory<SolutionGestionUniversitaireContext>

    {
        public SolutionGestionUniversitaireContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new
            DbContextOptionsBuilder<SolutionGestionUniversitaireContext>();
            optionsBuilder.UseSqlServer(@"Data Source=HAMZAX1\SQLEXPRESS;Database=SystemeSGUDB;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Application Name=""SQL Server Management Studio"";Command Timeout=0")
;
            return new SolutionGestionUniversitaireContext(optionsBuilder.Options);
        }
    }

}
