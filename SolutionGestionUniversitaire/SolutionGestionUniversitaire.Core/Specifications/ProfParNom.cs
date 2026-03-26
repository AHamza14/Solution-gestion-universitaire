using SolutionGestionUniversitaire.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolutionGestionUniversitaire.Core.Specifications
{
    public class ProfParNom : BaseSpecification<Professeur>
    {
        public ProfParNom(string nom)
            : base(prof => prof.Nom == nom)
        { }
    }

}
