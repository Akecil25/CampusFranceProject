using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusFrance.test.Models
{
    public class FormulaireData
    {
        public string Email { get; set; }
        public string MotDePasse { get; set; }
        public string ConfirmationMotDePasse { get; set; }
        public string Civilite { get; set; } // Bouton radio
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string PaysResidence { get; set; }
        public string PaysNationalite { get; set; }
        public string CodePostal { get; set; }
        public string Ville { get; set; }
        public string Telephone { get; set; }
        public string Statut { get; set; } // Bouton radio
        public string Domaineetude { get; set; } // Liste déroulante
        public string Niveauetude { get; set; } // Liste déroulante
        public string Fonction { get; set; }
        public string TypeOrganisme { get; set; } // Liste déroulante
        public string NomOrganisme { get; set; }


    }
}
