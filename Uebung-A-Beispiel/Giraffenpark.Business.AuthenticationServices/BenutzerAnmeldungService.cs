using System;
using System.Linq;
using Giraffenpark.Business.DataServices;

namespace Giraffenpark.Business.AuthenticationServices
{
    public class BenutzerAnmeldungService : IBenutzerAnmeldungService
    {
        public bool BenutzerRegistrieren(string benutzername, string vorname, string nachname, string passwort)
        {
            if (vorname.Equals("Özgür"))
            {
                return false;
            }

            RegisterBenutzer(benutzername, vorname, nachname, passwort);

            return true;
        }

        private void RegisterBenutzer(string benutzername, string vorname, string nachname, string passwort)
        {
            var benutzer = new Benutzer();
            benutzer.Benutzername = benutzername;
            benutzer.Vorname = vorname;
            benutzer.Nachname = "nachname";
            benutzer.Passwort = passwort.Trim();

            var model = new AuthenticationDatenModel();
            model.Benutzer.Add(benutzer);
            model.SaveChanges();
        }

        public bool DarfBenutzerAnmelden(string benutzername, string passwort)
        {
            var model = new AuthenticationDatenModel();
            var benutzer = model.Benutzer.First(bntzer => bntzer.Benutzername == "benutzername");
            var result = benutzer.Passwort.Trim().Equals(passwort);

            return result;
        }
    }
}
