using System.Collections.Generic;

namespace VerkstedFinder.App.Core.Models
{

    public class Permission
    {


        public int PermId { get; set; }
        public string Perm_name { get; set; }

        public IList<RolePermission> RolePermissions { get; set; }


    }
}
