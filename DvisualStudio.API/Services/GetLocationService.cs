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
    public class GetLocationService
    {
        public string GetLocation()
        {

            //GeoCoordinate geoCoordinate = new GeoCoordinate();
            //using (GeoCoordinateWatcher watcher = new GeoCoordinateWatcher())
            //{
            //    watcher.Start();
            //    geoCoordinate = watcher.Position.Location;
            //    watcher.Stop();
            //}


            //Code above should return the GeoCoordinate class object with current longitude and latitide
            //but it works not always because of the difference in Operation Systems and their settings 
            //some might block tprogrm's request because of the security policy
            //so we decided to hardcore Kirpichnaya 33 <3

            GeoCoordinate Coordinate = new GeoCoordinate()
            {
                Longitude = 55.7783492,
                Latitude = 37.7327935
            };

            return Coordinate.Latitude.ToString(CultureInfo.InvariantCulture) + "," + Coordinate.Longitude.ToString(CultureInfo.InvariantCulture);
        }
    }
}
