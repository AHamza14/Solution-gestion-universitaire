using Microsoft.EntityFrameworkCore;
using SolutionGestionUniversitaire.Core.Entities;
using SolutionGestionUniversitaire.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolutionGestionUniversitaire.Infrastructure.Repositories
{
    public class ProfesseurRepository : EfRepository<Professeur>, IProfesseurRepository
    {
        public ProfesseurRepository(SolutionGestionUniversitaireContext sguContext) : base(sguContext)
        { }

        public Task<Professeur> GetByIdWithCoursAsync(int id)
        {
            return _SGUContext.Professeurs
                  .Include(t => t.CoursEnseignés)
                  .FirstOrDefaultAsync(t => t.Id == id);
        }

        public Professeur GetByIdWithCours(int id)
        {
            return _SGUContext.Professeurs
                   .Include(t => t.CoursEnseignés)
                   .FirstOrDefault(t => t.Id == id);
        }
    }
}
