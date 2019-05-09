using VerkstedFinder.App.Helpers;
using VerkstedFinder.App.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
namespace VerkstedFinder.App.Views
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; } = new MainViewModel();
        public UserSession userSession = new UserSession();

        public MainPage()
        {
            InitializeComponent();
            if(userSession.getCurrentSignInUser() != null)
            {
                BeforeSignIn.Visibility = Visibility.Collapsed;
                AfterSignIn.Visibility = Visibility.Visible;
            }
        }
    }
}
