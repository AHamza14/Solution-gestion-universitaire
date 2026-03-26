using Microsoft.EntityFrameworkCore;
using SolutionGestionUniversitaire.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolutionGestionUniversitaire.Infrastructure
{
    public class SolutionGestionUniversitaireContext : DbContext
    {
        public DbSet<Professeur> Professeurs { get; set; }
        public DbSet<Cours> Cours { get; set; }

        public SolutionGestionUniversitaireContext(DbContextOptions options) :
                             base(options)
        { }

        public SolutionGestionUniversitaireContext() : base(new
               DbContextOptionsBuilder<SolutionGestionUniversitaireContext>()

               .UseSqlServer(@"Data Source=HAMZAX1\SQLEXPRESS;Database=SystemeSGUDB;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Application Name=""SQL Server Management Studio"";Command Timeout=0")
              .Options)
        { }

    }
}
