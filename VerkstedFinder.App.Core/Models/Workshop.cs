
namespace VerkstedFinder.App.Core.Models
{
    public class Workshop
    {
        public int Ws_id { get; set; }
        public string Ws_name { get; set; }
        public string Ws_orgnumber { get; set; }
        public string Ws_address { get; set; }
        public Poststed Postnr1 { get; set; }
    }
}
