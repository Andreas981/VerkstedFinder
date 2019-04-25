namespace VerkstedFinder.App.Core.Models
{
    public class RolePermission
    {
        public int RoleId { get; set; }
        public Role Role { get; set; }

        public int PermId { get; set; }
        public Permission Permission { get; set; }


    }
}
