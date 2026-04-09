using SolutionGestionUniversitaire.SharedKernel;
using SolutionGestionUniversitaire.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolutionGestionUniversitaire.Core.Entities
{
    public class Etudiant : BaseEntity, IAggregateRoot
    {
        public Etudiant() { }

        public Etudiant(string nom, string prenom, string matricule)
        {
            Nom = nom;
            Prenom = prenom;
            Matricule = matricule;
        }

        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Matricule { get; set; }

        public virtual List<Inscription> Inscriptions
        { get; private set; } = new List<Inscription>();

        public void Inscrire(Cours cours)
        {
            if (!Inscriptions.Any(i => i.CoursId == cours.Id))
                Inscriptions.Add(new Inscription(this, cours));
        }

        public void Desinscrire(int coursId)
        {
            var inscription = Inscriptions.FirstOrDefault(i => i.CoursId == coursId);
            if (inscription != null)
                Inscriptions.Remove(inscription);
        }
    }

}
