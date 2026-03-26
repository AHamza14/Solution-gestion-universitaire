using SolutionGestionUniversitaire.Core.Entities;
using SolutionGestionUniversitaire.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolutionGestionUniversitaire.Core.Interfaces
{
    public interface IProfesseurRepository : IAsyncRepository<Professeur>, IRepository<Professeur>
    {
        Task<Professeur> GetByIdWithCoursAsync(int id);
        Professeur GetByIdWithCours(int id);
    }

}
