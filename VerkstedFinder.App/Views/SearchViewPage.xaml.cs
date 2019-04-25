using System;

using VerkstedFinder.App.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace VerkstedFinder.App.Views
{
    public sealed partial class SearchViewPage : Page
    {
        public SearchViewViewModel ViewModel { get; } = new SearchViewViewModel();

        // TODO WTS: Change the grid as appropriate to your app, adjust the column definitions on SearchViewPage.xaml.
        // For more details see the documentation at https://docs.microsoft.com/windows/communitytoolkit/controls/datagrid
        public SearchViewPage()
        {
            InitializeComponent();
        }
        private async void SearchViewPage_LoadedAsync(object sender, RoutedEventArgs e)
        {
          
            await ViewModel.LoadPoststedsAsync();
            
        }
    }
}
