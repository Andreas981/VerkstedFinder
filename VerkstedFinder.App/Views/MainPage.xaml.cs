using System;

using VerkstedFinder.App.ViewModels;

using Windows.UI.Xaml.Controls;

namespace VerkstedFinder.App.Views
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; } = new MainViewModel();

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
