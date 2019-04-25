using System;
using System.Collections.ObjectModel;

using VerkstedFinder.App.Core.Models;
using VerkstedFinder.App.Core.Services;
using VerkstedFinder.App.Helpers;
using VerkstedFinder.App.DataAccess;
using System.Threading.Tasks;

namespace VerkstedFinder.App.ViewModels
{
    public class SearchViewViewModel : Observable
    {
        public ObservableCollection<Workshop> Workshops { get; set; } = new ObservableCollection<Workshop>();
        public ObservableCollection<Poststed> Poststeds { get; set; } = new ObservableCollection<Poststed>();
        private Workshops workshopsDataAccess = new Workshops();

        public ObservableCollection<Poststed> Source
        {
            get
            {
                // TODO WTS: Replace this with your actual data
                ObservableCollection<Poststed> poststed = PoststedDataService.AllOrdersAsync().Result;
                return poststed;
                //return PoststedDataService.GetGridSampleData();
            }
        }
        internal async Task LoadPoststedsAsync()
        {
            var workshops = await workshopsDataAccess.GetWorkshopsAsync();
            Poststeds = new ObservableCollection<Poststed>();
            //for (int i = 0; i < 1000; i++)
            //    Poststeds.Add(poststeds[i]);

            foreach (Workshop workshop in workshops)
            {
              
                Workshops.Add(workshop);
            }
                
        }
    }
}
