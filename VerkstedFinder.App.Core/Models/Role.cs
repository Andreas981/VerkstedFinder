using System.Collections.Generic;

namespace VerkstedFinder.App.Core.Models
{
    public class Role
    {

        public int RoleId { get; set; }
        public string Name { get; set; }

        public IList<RolePermission> RolePermissions { get; set; }


    }
}
