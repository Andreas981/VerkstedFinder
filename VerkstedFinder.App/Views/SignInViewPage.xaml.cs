using System;
using System.Threading.Tasks;
using VerkstedFinder.App.Core.Models;
using VerkstedFinder.App.Helpers;
using VerkstedFinder.App.ViewModels;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace VerkstedFinder.App.Views
{
    public sealed partial class SignInViewPage : Page
    {
        public SignInViewViewModel ViewModel { get; } = new SignInViewViewModel();
        public UserSession userSession = new UserSession();

        public SignInViewPage()
        {
            InitializeComponent();

            if(userSession.getCurrentSignInUser() != null)
            {
                MessageBox.Text = "You are already signed in";
                signin_password.Visibility = Visibility.Collapsed;
                signin_username.Visibility = Visibility.Collapsed;
                MessageBox.Foreground = new SolidColorBrush(Colors.Green);
                signin_button.Click += new RoutedEventHandler(Signout_buttonClick);
                signin_button.Content = "Sign out";
            }
            
        }

        public async void onButtonCLickEvent(object sender, RoutedEventArgs e)
        {
            //userSession.setCurrentSignInUser(null);
            //await ViewModel.signInAsync(signin_username.Text, signin_password.Text);

            userSession.setCurrentSignInUser(new User
            {
                User_firstname = "Andreas",
                User_id = 1,
                User_lastname = "Mikalsen",
                User_password = "qwerty",
                User_role = new Role {
                    RoleId = 1,
                    Name = "Admin"
                },
                User_username = "andremi"
            });

            if(userSession.getCurrentSignInUser() == null)
            {
                MessageBox.Text = "Sorry, could not sign in. Try again.";
                MessageBox.Foreground = new SolidColorBrush(Colors.Red);
                userSession.setCurrentSignInUser(null);
            }
            else
            {
                MessageBox.Text = "Sign in successfull";
                MessageBox.Foreground = new SolidColorBrush(Colors.Green);
                this.Frame.Navigate(typeof(MainPage));
            }
        }

        public void Signout_buttonClick(object sender, RoutedEventArgs e)
        {
            userSession.setCurrentSignInUser(null);
            this.Frame.Navigate(typeof(SignInViewPage));
        }
    }
}
