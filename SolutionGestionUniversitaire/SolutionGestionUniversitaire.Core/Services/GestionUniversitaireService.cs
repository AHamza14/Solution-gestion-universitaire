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
        private readonly IEtudiantRepository _etudiantRepository;

        public GestionUniversitaireService(IProfesseurRepository profRepository, IEtudiantRepository etudiantRepository)
        {
            _profRepository = profRepository;
            _etudiantRepository = etudiantRepository;
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

        // --- Etudiant ---
        public async Task AddEtudiant(Etudiant etudiant) => await _etudiantRepository.AddAsync(etudiant);

        public async Task UpdateEtudiant(Etudiant etudiant) => await _etudiantRepository.UpdateAsync(etudiant);

        public async Task DeleteEtudiant(Etudiant etudiant) => await _etudiantRepository.DeleteAsync(etudiant);

        public async Task InscrireEtudiantACours(int etudiantId, int coursId)
        {
            var etudiant = await _etudiantRepository.GetByIdWithInscriptionsAsync(etudiantId);
            if (etudiant == null) throw new Exception($"Etudiant {etudiantId} introuvable");

            var cours = new Cours("") { Id = coursId };
            etudiant.Inscrire(cours);
            await _etudiantRepository.UpdateAsync(etudiant);
        }

        public async Task DesinscrireEtudiantDeCours(int etudiantId, int coursId)
        {
            var etudiant = await _etudiantRepository.GetByIdWithInscriptionsAsync(etudiantId);
            if (etudiant == null) throw new Exception($"Etudiant {etudiantId} introuvable");

            etudiant.Desinscrire(coursId);
            await _etudiantRepository.UpdateAsync(etudiant);
        }

    }
}
