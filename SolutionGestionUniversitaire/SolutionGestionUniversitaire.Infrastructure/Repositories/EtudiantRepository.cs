using Microsoft.EntityFrameworkCore;
using SolutionGestionUniversitaire.Core.Entities;
using SolutionGestionUniversitaire.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolutionGestionUniversitaire.Infrastructure.Repositories
{
    public class EtudiantRepository : EfRepository<Etudiant>, IEtudiantRepository
    {
        public EtudiantRepository(SolutionGestionUniversitaireContext context) : base(context) { }

        public Task<Etudiant> GetByIdWithInscriptionsAsync(int id)
        {
            return _SGUContext.Etudiants
                .Include(e => e.Inscriptions)
                    .ThenInclude(i => i.Cours)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public Etudiant GetByIdWithInscriptions(int id)
        {
            return _SGUContext.Etudiants
                .Include(e => e.Inscriptions)
                    .ThenInclude(i => i.Cours)
                .FirstOrDefault(e => e.Id == id);
        }
    }

}
