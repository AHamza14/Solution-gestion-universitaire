using SolutionGestionUniversitaire.Core.Entities;
using SolutionGestionUniversitaire.Core.Interfaces;

namespace SolutionGestionUniversitaire.WindowsApp
{
    public partial class AjouterProfForm : Form
    {
        private IGestionUniversitaireService _gestionUniversitaireService;

        public AjouterProfForm(IGestionUniversitaireService gestionUniversitaireService)
        {
            _gestionUniversitaireService = gestionUniversitaireService;
            InitializeComponent();
        }

        public AjouterProfForm()
        {
            InitializeComponent();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            Professeur unProf = new Professeur();
            unProf.Nom = txtBoxNom.Text;
            unProf.Departement = txtBoxDepartement.Text;

            _gestionUniversitaireService.AddProfesseur(unProf);

            this.Close();

        }
    }
}
