using System;
using VerkstedFinder.App.Helpers;
using VerkstedFinder.App.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace VerkstedFinder.App.Views
{
    public sealed partial class SearchViewPage : Page
    {
        public SearchViewViewModel ViewModel { get; } = new SearchViewViewModel();
        public UserSession userSession = new UserSession();


        // TODO WTS: Change the grid as appropriate to your app, adjust the column definitions on SearchViewPage.xaml.
        // For more details see the documentation at https://docs.microsoft.com/windows/communitytoolkit/controls/datagrid
        public SearchViewPage()
        {
            InitializeComponent();
            userSession.setCurrentSignInUser(new Core.Models.User
            {
                User_firstname = "Andreas",
                User_id = 123,
                User_lastname = "Mikalsen",
                User_password = "sdfsdfsdf",
                User_role = new Core.Models.Role
                {
                    RoleId = 1,
                    Name = "Admin"
                },
                User_username = "Andremi"
            });
        }
        private async void SearchViewPage_LoadedAsync(object sender, RoutedEventArgs e)
        {
          
            await ViewModel.LoadWorkshopsAsync();
            
        }
    }
}
