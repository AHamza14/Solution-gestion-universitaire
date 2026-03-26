using SolutionGestionUniversitaire.SharedKernel;
using SolutionGestionUniversitaire.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolutionGestionUniversitaire.Core.Entities
{
    public class Professeur : BaseEntity, IAggregateRoot
    {
        public Professeur()
        {
            
        }

        public Professeur(string nom, string departement)
        {
            Nom = nom;
            Departement = departement;
        }

        public string Nom { get; set; }
        public string Departement { get; set; }

        public virtual List<Cours> CoursEnseignés { get; private set; } = new List<Cours>();

        public void AddCours(Cours cours)
        {
            CoursEnseignés.Add(cours);
        }

        public void RemoveCompte(Cours cours)
        {
            CoursEnseignés.Remove(cours);
        }

    }
}
