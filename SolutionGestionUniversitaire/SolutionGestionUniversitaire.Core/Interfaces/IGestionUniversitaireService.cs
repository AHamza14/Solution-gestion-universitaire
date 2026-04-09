using SolutionGestionUniversitaire.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolutionGestionUniversitaire.Core.Interfaces
{
    public  interface IGestionUniversitaireService
    {
        Task AddProfesseur(Professeur prof);
        Task UpdateProfesseur(Professeur prof);
        Task DeleteProfesseur(Professeur prof);

        // Etudiant
        Task AddEtudiant(Etudiant etudiant);
        Task UpdateEtudiant(Etudiant etudiant);
        Task DeleteEtudiant(Etudiant etudiant);

        // Inscription (many-to-many)
        Task InscrireEtudiantACours(int etudiantId, int coursId);
        Task DesinscrireEtudiantDeCours(int etudiantId, int coursId);
    }
}
