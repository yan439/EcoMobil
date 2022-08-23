// Yannick

using EcoMobil.Models.BDD;
using EcoMobil.Models.ManagementService;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EcoMobil.Models.Services
{
    public class DalMessage
    {
        private BddContext _bddContext;

        public DalMessage()
        {
            _bddContext = new BddContext();
        }

        public void AjouterMessage(string Date, string Heure, string Destinataire, string ObjetDuMessage, string CorpsDuMessage, string EtatCoteExpediteur, string EtatCoteDestinataire, int IdExpediteur)
        {
            Message message = new Message
            {
                Date = Date,
                Heure = Heure,
                Destinataire = Destinataire,
                ObjetDuMessage = ObjetDuMessage,
                CorpsDuMessage = CorpsDuMessage,
                EtatCoteExpediteur = EtatCoteExpediteur,
                EtatCoteDestinataire = EtatCoteDestinataire,
                UtilisateurId = IdExpediteur
            };

            _bddContext.Messages.Add(message);
            _bddContext.SaveChanges();
        }

        public List<Message> ObtenirTousLesMessages()
        {
            return _bddContext.Messages.Include(m => m.Utilisateur).ToList();
        }

        public Message ObtenirMessage(int id)
        {
            return this._bddContext.Messages.FirstOrDefault(m => m.Id == id);
        }

        public void ModifierMessage(Message message)
        {
            _bddContext.Messages.Update(message);
            _bddContext.SaveChanges();
        }

        public void SupprimerMessage(int id)
        {
            Message message = _bddContext.Messages.Find(id);

            if (message != null)
            {
                _bddContext.Messages.Remove(message);
                _bddContext.SaveChanges();
            }
        }
    }
}
