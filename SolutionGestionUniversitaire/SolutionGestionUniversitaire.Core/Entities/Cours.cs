using SolutionGestionUniversitaire.SharedKernel;
using SolutionGestionUniversitaire.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolutionGestionUniversitaire.Core.Entities
{
    public class Cours : BaseEntity, IAggregateRoot
    {
        public Cours(string titre)
        {
            Titre = titre;
        }

        public virtual List<Inscription> Inscriptions { get; private set; } = new List<Inscription>();

        public string Titre { get; set; }
    }
}
