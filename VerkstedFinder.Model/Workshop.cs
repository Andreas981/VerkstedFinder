using System.ComponentModel.DataAnnotations;

namespace VerkstedFinder.Model
{
    public class Workshop
    {
        [Key]
        public int Ws_id { get; set; }
        [Required]
        public string Ws_name { get; set; }
        [Required]
        public string Ws_orgnumber { get; set; }
        [Required]
        public string Ws_address { get; set; }
        [Required]
        public Poststed Ws_poststed { get; set; }
    }
}
