using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using VerkstedFinder.App.Core.Models;
using VerkstedFinder.App.DataAccess;
using VerkstedFinder.App.Helpers;

namespace VerkstedFinder.App.ViewModels
{
    public class SignInViewViewModel : Observable
    {

        private Users userDataAccess = new Users();
        public UserSession userSession = new UserSession();

        public SignInViewViewModel()
        {
        }

        public async Task signInAsync(string username, string password)
        {
            User[] users = await userDataAccess.GetUsersAsync();
            var foundUser = users.FirstOrDefault(u => u.User_username == username);

            if (foundUser == null)
            {
                userSession.setCurrentSignInUser(null);
                return;
            }

            if (foundUser.User_username == username && foundUser.User_password == password)
            {
                userSession.setCurrentSignInUser(foundUser);
            }
        }

    }
}
