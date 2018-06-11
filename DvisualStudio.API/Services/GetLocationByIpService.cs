using DvisualStudio.API.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DvisualStudio.API.Services
{
    public class GetLocationByIpService
    {
        public GeoCoordinate Coordinate { get; set; }
      
        public void CalculateLocation() 
        {
            GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();

            watcher.PositionChanged += (object sender, GeoPositionChangedEventArgs<GeoCoordinate> e) => Coordinate = e.Position.Location;

            watcher.StatusChanged += (sender, e) =>
            {
                switch (e.Status)
                {
                    case GeoPositionStatus.Ready:
                        Coordinate = watcher.Position.Location;
                        watcher.Stop();
                        break;
                }
            };

            watcher.Start();

            while (Coordinate == null)
            {
            }
        }
        public string GetLocation()
        {
            CalculateLocation();
            return Coordinate.Latitude.ToString(CultureInfo.InvariantCulture) + "," + Coordinate.Longitude.ToString(CultureInfo.InvariantCulture);
        }
    }
}
