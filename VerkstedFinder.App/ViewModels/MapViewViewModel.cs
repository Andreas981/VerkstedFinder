using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VerkstedFinder.App.Core.Models;
using VerkstedFinder.App.DataAccess;
using VerkstedFinder.App.Helpers;
using VerkstedFinder.App.Services;

using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls.Maps;

namespace VerkstedFinder.App.ViewModels
{
    public class MapViewViewModel : Observable
    {
        // TODO WTS: Set your preferred default zoom level
        private const double DefaultZoomLevel = 10;

        private readonly LocationService _locationService;

        // TODO WTS: Set your preferred default location if a geolock can't be found.
        private readonly BasicGeoposition _defaultPosition = new BasicGeoposition()
        {
            Latitude = 59.284073,
            Longitude = 11.109403
        };

        private double _zoomLevel;

        public double ZoomLevel
        {
            get { return _zoomLevel; }
            set { Set(ref _zoomLevel, value); }
        }

        private Geopoint _center;

        public Geopoint Center
        {
            get { return _center; }
            set { Set(ref _center, value); }
        }

        public MapViewViewModel()
        {
            _locationService = new LocationService();
            Center = new Geopoint(_defaultPosition);
            ZoomLevel = DefaultZoomLevel;
        }

        public async Task InitializeAsync(MapControl map)
        {
            if (_locationService != null)
            {
                _locationService.PositionChanged += LocationService_PositionChanged;

                var initializationSuccessful = await _locationService.InitializeAsync();

                if (initializationSuccessful)
                {
                    await _locationService.StartListeningAsync();
                }

                if (initializationSuccessful && _locationService.CurrentPosition != null)
                {
                    Center = _locationService.CurrentPosition.Coordinate.Point;
                }
                else
                {
                    Center = new Geopoint(_defaultPosition);
                }
            }

            if (map != null)
            {
                // TODO WTS: Set your map service token. If you don't have one, request from https://www.bingmapsportal.com/
                // map.MapServiceToken = string.Empty;
                //AddMapIcon(map, Center, "");
                AddMapIcon(map, new Geopoint(new BasicGeoposition
                {
                    Latitude = 59.434610,
                    Longitude = 10.668490
                }), "MOSS AUTOSERVICE AS");
                AddMapIcon(map, new Geopoint(new BasicGeoposition
                {
                    Latitude = 59.420120,
                    Longitude = 10.699440
                }), "Moss To-Takt Skadesenter");

                AddMapIcon(map, new Geopoint(new BasicGeoposition
                {
                    Latitude = 59.123840,
                    Longitude = 11.384290
                }), "OSKAR L. HANSEN AS");
                AddMapIcon(map, new Geopoint(new BasicGeoposition
                {
                    Latitude = 59.121860,
                    Longitude = 11.303650
                }), "HALDEN BILSENTER AS");
                AddMapIcon(map, new Geopoint(new BasicGeoposition
                {
                    Latitude = 59.133740,
                    Longitude = 11.376670
                }), "GLENNE BIL A/S");

                /*await getWorkshopsAsync();

                for (int i = 0; i < 10; i++)
                {
                    var coordinate = await coordinatesDataAccess.GetCoordinatesAsync(Workshops[i].Ws_address);
                    String[] latLng = coordinate.Split(",");
                    var position = new Geopoint(new BasicGeoposition()
                    {
                        Latitude = Convert.ToDouble(latLng[0]),
                        Longitude = Convert.ToDouble(latLng[1])
                    });
                    AddMapIcon(map, position, Workshops[i].Ws_name);
                    //Coordinates.Add(coordinate);
                }*/

            }
        }

        private void LocationService_PositionChanged(object sender, Geoposition geoposition)
        {
            if (geoposition != null)
            {
                Center = geoposition.Coordinate.Point;
            }
        }

        private void AddMapIcon(MapControl map, Geopoint position, string title)
        {
            var mapIcon = new MapIcon()
            {
                Location = position,
                NormalizedAnchorPoint = new Point(0.5, 1.0),
                Title = title,
                Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/map.png")),
                ZIndex = 0
            };
            map.MapElements.Add(mapIcon);
        }

        public void Cleanup()
        {
            if (_locationService != null)
            {
                _locationService.PositionChanged -= LocationService_PositionChanged;
                _locationService.StopListening();
            }
        }

        public ObservableCollection<Workshop> Workshops { get; set; } = new ObservableCollection<Workshop>();
        private Workshops workshopsDataAccess = new Workshops();

        public async Task getWorkshopsAsync()
        {
            var workshops = await workshopsDataAccess.GetWorkshopsAsync();

            foreach(Workshop workshop in workshops)
            {
                Workshops.Add(workshop);
            }

        }

        public ObservableCollection<String> Coordinates { get; set; } = new ObservableCollection<string>();
        private Coordinates coordinatesDataAccess = new Coordinates();

        public async Task getCoordinatesAsync()
        {
            for(int i = 0; i < 10; i++)
            {
                var coordinate = await coordinatesDataAccess.GetCoordinatesAsync(Workshops[i].Ws_address);
                Coordinates.Add(coordinate);
            }

            foreach(String s in Coordinates)
            {
                String[] latLng = s.Split(",");
                var position = new BasicGeoposition()
                {
                    Latitude = s[0],
                    Longitude = s[1]
                };
            }

        }

    }
}
