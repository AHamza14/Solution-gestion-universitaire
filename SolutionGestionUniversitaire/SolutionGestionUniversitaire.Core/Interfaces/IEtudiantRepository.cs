using SolutionGestionUniversitaire.Core.Entities;
using SolutionGestionUniversitaire.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolutionGestionUniversitaire.Core.Interfaces
{
    public interface IEtudiantRepository : IAsyncRepository<Etudiant>, IRepository<Etudiant>
    {
        Task<Etudiant> GetByIdWithInscriptionsAsync(int id);
        Etudiant GetByIdWithInscriptions(int id);

       

    }

}
