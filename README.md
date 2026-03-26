# Système de Gestion Universitaire

Application web de gestion universitaire, composée d'un frontend React et d'un backend ASP.NET Core organisé selon l'architecture Clean Architecture.

---

## Table des matières

1. [Structure du projet](#structure-du-projet)
2. [Prérequis](#prérequis)
3. [Installation des dépendances](#installation-des-dépendances)
4. [Lancer l'application en local](#lancer-lapplication-en-local)
5. [Comment les deux parties se connectent](#comment-les-deux-parties-se-connectent)

---

## Structure du projet

Le dossier racine contient deux grandes parties :

```
test/
├── SolutionGestionUniversitaire/          <- Solution .NET (Backend)
│   ├── SolutionGestionUniversitaire.SharedKernel/   <- Concepts clean architecture
│   ├── SolutionGestionUniversitaire.Core/           <- Domaine et logique métier
│   ├── SolutionGestionUniversitaire.Infrastructure/ <- Accès aux données (EF Core)
│   ├── SolutionGestionUniversitaire.WebAPI/         <- API REST
│   ├── SolutionGestionUniversitaire.WindowsApp/     <- Application bureau Windows
│   └── SolutionGestionUniversitaire.ConsoleTestApp/ <- Application console de test
│
└── SolutionGestionUniversitaire.React/    <- Application React (Frontend) 
    ├── src/
    │   ├── main.jsx        <- Point d'entrée de l'application React
    │   ├── App.jsx         <- Composant principal (formulaire professeurs)
    │   ├── App.css         <- Styles du composant principal
    │   └── index.css       <- Styles globaux
    ├── index.html          <- Page HTML racine
    ├── vite.config.js      <- Configuration Vite (proxy vers le backend)
    └── package.json        <- Dépendances et scripts npm
```

### Explication des couches du backend (Clean Architecture)

L'architecture Clean Architecture divise le code en couches indépendantes, du plus central au plus externe :

| Couche | Projet | Rôle |
|--------|--------|------|
| **SharedKernel** | `...SharedKernel` | Interfaces et classes abstraites réutilisables (`BaseEntity`, `IRepository`, etc.) |
| **Core** | `...Core` | Entités métier (`Professeur`, `Cours`), interfaces de services et repositories, logique applicative |
| **Infrastructure** | `...Infrastructure` | Implémentation concrète des repositories avec Entity Framework Core, connexion à SQL Server |
| **WebAPI** | `...WebAPI` | Controllers HTTP, configuration de l'application, point d'entrée de l'API REST |


---

## Prérequis

Avant de commencer, assurez-vous d'avoir installé les outils suivants sur votre machine.

### Pour le backend (.NET)

- **.NET SDK** version 10.0 ou supérieure
  - Vérification : `dotnet --version`
  - Téléchargement : https://dotnet.microsoft.com/download
- **SQL Server Express** (base de données)

### Pour le frontend (React)

- **Node.js** version 18 ou supérieure
  - Vérification : `node --version`
  - Téléchargement : https://nodejs.org
- **npm** (inclus avec Node.js)
  - Vérification : `npm --version`

### IDE

- **Visual Studio 2022** ou **Visual Studio Code** pour éditer le code
- **SQL Server Management Studio (SSMS)** pour visualiser la base de données

---

## Installation des dépendances

### 1. Installer les dépendances du frontend

Ouvrez un terminal et placez-vous dans le dossier du frontend :

```bash
cd SolutionGestionUniversitaire.React
npm install
```

Cette commande lit le fichier `package.json` et télécharge toutes les bibliothèques nécessaires (React, Vite, etc.) dans un dossier `node_modules/`.

### 2. Restaurer les packages NuGet du backend

Placez-vous dans le dossier du backend :

```bash
cd SolutionGestionUniversitaire
dotnet restore
```

Cette commande télécharge toutes les bibliothèques .NET déclarées dans les fichiers `.csproj` (Entity Framework Core, etc.).

### 3. Configurer la base de données

#### a) Vérifier la chaîne de connexion

Ouvrez le fichier `SolutionGestionUniversitaire.WebAPI/appsettings.json`. Vous devriez voir quelque chose comme :

```json
"ConnectionStrings": {
  "DefaultConnection": "Data Source=...;Database=...;Integrated Security=True;..."
}
```

Remplacez "Data Source" et "Database".

#### b) Créer la base de données avec les migrations EF Core

Depuis le dossier `SolutionGestionUniversitaire`, exécutez :

```bash
dotnet ef database update --project SolutionGestionUniversitaire.Infrastructure --startup-project SolutionGestionUniversitaire.WebAPI
```

Cette commande crée automatiquement la base de données `SystemeSGUDB` dans SQL Server avec les tables `Professeurs` et `Cours`.

> Si la commande `dotnet ef` n'est pas reconnue, installez l'outil EF Core :
> ```bash
> dotnet tool install --global dotnet-ef
> ```

---

## Lancer l'application en local

Il faut démarrer les deux parties séparément, dans deux terminaux différents.

### Terminal 1 — Lancer le backend

```bash
cd SolutionGestionUniversitaire
dotnet run --project SolutionGestionUniversitaire.WebAPI
```

Le backend démarre et écoute sur :
- **HTTP** : `http://localhost:xxxx`
- **HTTPS** : `https://localhost:xxxx`
- **IIS Express (HTTPS)** : `https://localhost:xxxxx`

Vous pouvez vérifier que l'API fonctionne en ouvrant dans votre navigateur :
`http://localhost:xxxx/WeatherForecast`

### Terminal 2 — Lancer le frontend

```bash
cd SolutionGestionUniversitaire.React
npm run dev
```

Vite démarre un serveur de développement. Ouvrez votre navigateur à l'adresse affichée dans le terminal (généralement `http://localhost:xxxx`).

Vous devriez voir le formulaire d'ajout de professeur.

---

## Comment les deux parties se connectent

### Le problème : origines différentes

Pendant le développement, le frontend tourne sur `http://localhost:xxxx` et le backend sur `https://localhost:xxxxx`. Les navigateurs bloquent par défaut les requêtes entre deux origines différentes (c'est la politique CORS).

### La solution : le proxy Vite

Le fichier `vite.config.js` configure un **proxy** qui intercepte les appels de l'interface et les redirige automatiquement vers le backend :

```js
// vite.config.js
server: {
  proxy: {
    '/api': {
      target: 'https://localhost:44307',
      changeOrigin: true,
      secure: false,
    }
  }
}
```

**Ce que ca veut dire en pratique :**

```
Navigateur
    |
    | POST /api/Professeur/AjouterProf
    v
Serveur Vite (localhost:5173)
    |
    | Proxy : redirige vers https://localhost:44307
    v
Backend ASP.NET Core (localhost:44307)
    |
    | Insère en base de données via EF Core
    v
SQL Server (SystemeSGUDB)
```

### Exemple de flux complet

1. L'étudiant remplit le formulaire dans le navigateur (nom et département d'un professeur).
2. `App.jsx` envoie une requête **POST** vers `/api/Professeur/AjouterProf` avec les données en JSON.
3. Vite intercepte la requête et la redirige vers `https://localhost:xxxx/api/Professeur/AjouterProf`.
4. Le **ProfesseurController** du backend reçoit la requête et appelle le service `IGestionUniversitaireService`.
5. Le service appelle le repository `IProfesseurRepository`, qui utilise **Entity Framework Core** pour insérer le professeur dans la table `Professeurs` de SQL Server.
6. Le backend retourne une réponse `200 OK`.
7. Le frontend affiche un message de succès à l'utilisateur.

---

## Résumé des commandes utiles

| Action | Commande |
|--------|----------|
| Installer les dépendances frontend | `npm install` (dans `...React/`) |
| Lancer le frontend | `npm run dev` (dans `...React/`) |
| Restaurer les packages .NET | `dotnet restore` (dans `SolutionGestionUniversitaire/`) |
| Lancer le backend | `dotnet run --project SolutionGestionUniversitaire.WebAPI` |
| Appliquer les migrations EF Core | `dotnet ef database update --project ...Infrastructure --startup-project ...WebAPI` |
| Construire le frontend pour la production | `npm run build` (dans `...React/`) |
