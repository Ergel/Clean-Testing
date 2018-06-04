namespace Giraffenpark.Authentication.Domain
{
    public class Benutzer
    {
        public long BenutzerID { get; set; }

        public string Benutzername { get; set; }

        public string Vorname { get; set; }

        public string Nachname { get; set; }

        public string Passwort { get; set; }
    }
}
