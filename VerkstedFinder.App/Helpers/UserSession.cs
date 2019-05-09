using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerkstedFinder.App.Core.Models;

namespace VerkstedFinder.App.Helpers
{
    public class UserSession
    {
        public static User currentLoggedInUser { get; set; } = null;

        public void setCurrentSignInUser(User user)
        {
            currentLoggedInUser = user;
        }

        public User getCurrentSignInUser()
        {
            if (currentLoggedInUser == null)
                return null;
            return currentLoggedInUser;
        }


    }
}
