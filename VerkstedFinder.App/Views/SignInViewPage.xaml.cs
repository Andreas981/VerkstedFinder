using System;
using System.Threading.Tasks;
using VerkstedFinder.App.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace VerkstedFinder.App.Views
{
    public sealed partial class SignInViewPage : Page
    {
        public SignInViewViewModel ViewModel { get; } = new SignInViewViewModel();

        public SignInViewPage()
        {
            InitializeComponent();
        }

        public void onButtonCLickEvent(object sender, RoutedEventArgs e)
        {
            Boolean signIn = ViewModel.signInAsync(signin_username.Text, signin_password.Text).Result;
          
        }
    }
}
