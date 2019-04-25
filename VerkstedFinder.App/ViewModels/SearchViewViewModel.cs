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
        private Poststeds postsedDataAccess = new Poststeds();

        /*public ObservableCollection<Poststed> Source
        {
            get
            {
                // TODO WTS: Replace this with your actual data
                ObservableCollection<Poststed> poststed = PoststedDataService.AllOrdersAsync().Result;
                return poststed;
                //return PoststedDataService.GetGridSampleData();
            }
        }*/
        internal async Task LoadWorkshopsAsync()
        {
            await LoadPoststedsAsyns();
            var workshops = await workshopsDataAccess.GetWorkshopsAsync();

            for (int i = 0; i < workshops.Length; i++)
            {
                Poststed postnumber = workshops[i].Ws_poststed;
                Workshops.Add(new Workshop
                {
                    Ws_address = workshops[i].Ws_address,
                    Ws_id = workshops[i].Ws_id,
                    Ws_name = workshops[i].Ws_name,
                    Ws_orgnumber = workshops[i].Ws_orgnumber,
                    Ws_poststed = Poststeds[0]
                });
                
            }
                
        }
        private async Task LoadPoststedsAsyns()
        {
            var poststeds = await postsedDataAccess.GetPoststedsAsync();
            foreach (Poststed poststed in poststeds)
            {
                Poststeds.Add(poststed);
            }
        }
    }
}
