using SolutionGestionUniversitaire.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolutionGestionUniversitaire.Core.Entities
{
    public class Inscription : BaseEntity
    {
        public Inscription() { }

        public Inscription(Etudiant etudiant, Cours cours)
        {
            Etudiant = etudiant;
            Cours = cours;
            CoursId = cours.Id;
            EtudiantId = etudiant.Id;
            DateInscription = DateTime.Now;
        }

        public int EtudiantId { get; set; }
        public Etudiant Etudiant { get; set; }

        public int CoursId { get; set; }
        public Cours Cours { get; set; }

        public DateTime DateInscription { get; set; }
    }

}
