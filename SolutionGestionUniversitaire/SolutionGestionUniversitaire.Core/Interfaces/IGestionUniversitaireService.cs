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

    }
}
