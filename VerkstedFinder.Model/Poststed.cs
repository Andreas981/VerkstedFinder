using System.ComponentModel.DataAnnotations;

namespace VerkstedFinder.Model
{
    public class Poststed
    {
        [Key]
        public int Postnr { get; set; }
        [Required]
        public string PoststedName { get; set; }
    }
}
