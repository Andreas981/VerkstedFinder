using System;

using VerkstedFinder.App.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace VerkstedFinder.App.Views
{
    public sealed partial class MapViewPage : Page
    {
        public MapViewViewModel ViewModel { get; } = new MapViewViewModel();

        public MapViewPage()
        {
            InitializeComponent();
            //ViewModel.getWorkshopsAsync();

        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await ViewModel.InitializeAsync(mapControl);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            ViewModel.Cleanup();
        }
    }
}
