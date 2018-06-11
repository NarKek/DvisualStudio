using DvisualStudio.API.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DvisualStudio.API.Services
{
    public static class GetLocationByIpService
    {
        private static void GeoCoordinateWatcherPositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            var currentLatitude = e.Position.Location.Latitude;
            var currentLongitude = e.Position.Location.Longitude;
        }
        public static string GetLocation() 
        {
            GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();

            string kek = "";
            watcher.MovementThreshold = 20;

            watcher.PositionChanged += (object sender, GeoPositionChangedEventArgs<GeoCoordinate> e) => kek = $"{e.Position.Location.Latitude},{e.Position.Location.Longitude}";

            watcher.StatusChanged += (sender, e) =>
            {
                switch (e.Status)
                {
                    case GeoPositionStatus.Ready:
                        GeoCoordinate coord = watcher.Position.Location;
                        
                        watcher.Stop();
                        break;
                }
            };

            watcher.Start();
            //while (watcher.Status != GeoPositionStatus.Ready)
            //{
            //    System.Threading.Thread.Sleep(10);
            //}



            return kek;
        }
        
    }
}
