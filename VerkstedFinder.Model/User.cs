using System.ComponentModel.DataAnnotations;

namespace VerkstedFinder.Model
{
    public class User
    {
        [Key]
        public int User_id { get; set; }
        [Required]
        public string User_firstname{ get; set; }
        [Required]
        public string User_lastname { get; set; }
        [Required]
        public string User_username { get; set; }
        [Required]
        public string User_password { get; set; }
        [Required]
        public Role User_role { get; set; }
        //Comment
    }
}
