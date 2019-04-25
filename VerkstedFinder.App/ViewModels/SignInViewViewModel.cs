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
        public IList<User> Users { get; set; } = new List<User>();

        public SignInViewViewModel()
        {
        }

        public async Task<Boolean> signInAsync(string username, string password)
        {
            if(username != "" && password != "")
            {
                await LoadUsersAsync();
                var usernameReuslt = from s in Users
                             where s.User_username == username
                             select s;
                if(usernameReuslt == null)
                {
                    return false;
                }
                var passwordResult = from s in Users
                                     where s.User_username == username
                                     select s.User_password;
                if (passwordResult.Equals(password))
                    return true;
            }
            return false;
        }

        private async Task LoadUsersAsync()
        {
            var users = await userDataAccess.GetUsersAsync();
            //for (int i = 0; i < 1000; i++)
            //    Poststeds.Add(poststeds[i]);

            foreach (User user in users)
            {
                Users.Add(user);
            }

        }

    }
}
