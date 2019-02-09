using System;
using System.Collections.Generic;
using System.Text;

namespace VerkstedFinder.Model
{
    public class Role_has_Perm
    {
        public Role r_id { get; set; }
        public Permission perm_id { get; set; }
    }
}
