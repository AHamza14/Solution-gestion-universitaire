using SolutionGestionUniversitaire.Core.Entities;
using SolutionGestionUniversitaire.Core.Interfaces;
using SolutionGestionUniversitaire.Core.Services;
using SolutionGestionUniversitaire.Core.Specifications;
using SolutionGestionUniversitaire.Infrastructure;
using SolutionGestionUniversitaire.Infrastructure.Repositories;
using SolutionGestionUniversitaire.SharedKernel.Interfaces;

//Test1();

//await Test2(1);

//await Test3("ahmed");

await Test4("Kamal", "Math");
static async Task Test4(string nom, string departement)
{
    using (SolutionGestionUniversitaireContext context = new SolutionGestionUniversitaireContext())
    {
        IProfesseurRepository profRepository = new ProfesseurRepository(context);
        IGestionUniversitaireService service = new GestionUniversitaireService(profRepository);
        Professeur prof = new Professeur(nom, departement);
        await service.AddProfesseur(prof);
    }

}


static async Task Test3(string nom)
{
    using (SolutionGestionUniversitaireContext context = new SolutionGestionUniversitaireContext())
    {
        //chercher le prof par numéro
        ProfParNom spec = new ProfParNom(nom);
        IProfesseurRepository profRepository = new ProfesseurRepository(context);

        List<Professeur> profs = (List<Professeur>)await profRepository.ListAsync(spec);
        Professeur prof = profs.FirstOrDefault();

        if (prof != null)
            System.Console.WriteLine(prof.Nom + ": " + prof.Departement);
        else System.Console.WriteLine("Client introuvable");
    }

}


static async Task Test2(int id)
{
    using (SolutionGestionUniversitaireContext context = new SolutionGestionUniversitaireContext())
    {
        IAsyncRepository<Professeur> ar = new EfRepository<Professeur>(context);
        Professeur prof = await ar.GetByIdAsync(id);
        if (prof != null)
            System.Console.WriteLine(prof.Nom + ": " + prof.Departement);
        else System.Console.WriteLine("Client introuvable");
    }
}

static void Test1()
{
    var context = new SolutionGestionUniversitaireContext();

    //ajouter un prof
    Cours cours = new Cours("Culture Digitale");
    context.Add(cours);

    Professeur prof = new Professeur("Hamza", "Informatique");
    prof.AddCours(cours);
    context.Add(prof);

    context.SaveChanges();
}
