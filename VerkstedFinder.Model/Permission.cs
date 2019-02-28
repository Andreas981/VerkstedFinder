using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VerkstedFinder.Model
{

    public class Permission
    {


        [Key]
        public int PermId { get; set; }
        [Required]
        public string Perm_name { get; set; }

        public IList<RolePermission> RolePermissions { get; set; }





        public static void Main(string[] args)
        {

        }


    }
}
