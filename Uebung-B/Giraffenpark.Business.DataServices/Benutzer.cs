using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Giraffenpark.Business.DataServices
{
    [Table("Benutzer")]
    public partial class Benutzer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 0)]
        public long BenutzerID { get; set; }

        [Column(Order = 1)]
        [StringLength(50)]
        public string Vorname { get; set; }

        [Column(Order = 2)]
        [StringLength(50)]
        public string Nachname { get; set; }

        [Column(Order = 3)]
        [StringLength(10)]
        public string Passwort { get; set; }

        [Column(Order = 4)]
        [StringLength(50)]
        public string Benutzername { get; set; }
    }
}
