using System.Device.Location;
using System.Globalization;

namespace DvisualStudio.API.Services
{
    public class GetLocationService
    {
        private GeoCoordinate _coordinate;

        private void CalculateLocation()
        {
            var _watcher = new GeoCoordinateWatcher();
            _watcher.StatusChanged += (object sender, GeoPositionStatusChangedEventArgs e) =>
            {
                switch (e.Status)
                {
                    case GeoPositionStatus.Ready:
                        _coordinate = _watcher.Position.Location;
                        _watcher.Stop();
                        break;
                }
            };
            _watcher.Start();
            while (_coordinate == null)
            {

            }
        }

        public string GetLocation()
        {
            CalculateLocation();
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

            //GeoCoordinate Coordinate = new GeoCoordinate()
            //{
            //    Longitude = 55.7783492,
            //    Latitude = 37.7327935
            //};

            return _coordinate.Latitude.ToString(CultureInfo.InvariantCulture) + "," + _coordinate.Longitude.ToString(CultureInfo.InvariantCulture);
        }
    }
}
