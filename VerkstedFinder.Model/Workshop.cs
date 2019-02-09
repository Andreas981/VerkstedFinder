using System;
using System.Collections.Generic;
using System.Text;

namespace VerkstedFinder.Model
{
    public class Workshop
    {
        public int ws_id { get; set; }
        public string ws_string { get; set; }
        public string ws_name { get; set; }
        public string ws_address { get; set; }
        public Poststed postnr { get; set; }
    }
}
