import { useState } from 'react'
import './App.css'

function App() {
  const [nom, setNom] = useState('')
  const [departement, setDepartement] = useState('')
  const [message, setMessage] = useState(null)
  const [erreur, setErreur] = useState(null)
  const [chargement, setChargement] = useState(false)

  const ajouterProfesseur = async (e) => {
    e.preventDefault()
    setMessage(null)
    setErreur(null)
    setChargement(true)

    try {
      const reponse = await fetch('/api/Professeur/AjouterProf', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({ nom, departement }),
      })

      if (!reponse.ok) {
        throw new Error(`Erreur serveur : ${reponse.status}`)
      }

      setMessage('Professeur ajouté avec succès.')
      setNom('')
      setDepartement('')
    } catch (err) {
      setErreur(err.message || 'Une erreur est survenue.')
    } finally {
      setChargement(false)
    }
  }

  return (
    <div className="container">
      <h1>Gestion Universitaire</h1>
      <div className="card">
        <h2>Ajouter un Professeur</h2>
        <form onSubmit={ajouterProfesseur}>
          <div className="champ">
            <label htmlFor="nom">Nom</label>
            <input
              id="nom"
              type="text"
              placeholder="Nom du professeur"
              value={nom}
              onChange={(e) => setNom(e.target.value)}
              required
            />
          </div>
          <div className="champ">
            <label htmlFor="departement">Département</label>
            <input
              id="departement"
              type="text"
              placeholder="Département"
              value={departement}
              onChange={(e) => setDepartement(e.target.value)}
              required
            />
          </div>
          {message && <p className="succes">{message}</p>}
          {erreur && <p className="erreur">{erreur}</p>}
          <button type="submit" disabled={chargement}>
            {chargement ? 'Ajout en cours...' : 'Ajouter'}
          </button>
        </form>
      </div>
    </div>
  )
}

export default App
