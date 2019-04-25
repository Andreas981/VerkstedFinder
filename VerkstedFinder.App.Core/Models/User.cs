
namespace VerkstedFinder.App.Core.Models
{
    public class User
    {
        public int User_id { get; set; }
        public string User_firstname{ get; set; }
        public string User_lastname { get; set; }
        public string User_username { get; set; }
        public string User_password { get; set; }
        public Role User_role { get; set; }
        //Comment
    }
}
