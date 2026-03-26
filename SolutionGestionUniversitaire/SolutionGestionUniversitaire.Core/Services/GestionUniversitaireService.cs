using SolutionGestionUniversitaire.Core.Entities;
using SolutionGestionUniversitaire.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolutionGestionUniversitaire.Core.Services
{
    public class GestionUniversitaireService : IGestionUniversitaireService
    {
        private readonly IProfesseurRepository _profRepository;

        public GestionUniversitaireService(IProfesseurRepository profRepository)
        {
            _profRepository = profRepository;
        }
        public async Task AddProfesseur(Professeur prof)
        {
            await _profRepository.AddAsync(prof);
        }

        public async Task UpdateProfesseur(Professeur prof)
        {
            await _profRepository.UpdateAsync(prof);
        }

        public async Task DeleteProfesseur(Professeur prof)
        {
            await _profRepository.DeleteAsync(prof);
        }


    }
}
