using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VerkstedFinder.Model
{
    public class Role
    {

        [Key]
        public int RoleId { get; set; }
        [Required]
        public string Name { get; set; }

        public IList<RolePermission> RolePermissions { get; set; }


    }
}
