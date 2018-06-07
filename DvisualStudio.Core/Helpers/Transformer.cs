using DvisualStudio.API.DTO;
using DvisualStudio.API.DTO.ConcertInfo;
using DvisualStudio.API.DTO.GooglePlaceInfoAPI;
using DvisualStudio.Core.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvisualStudio.Core.Helpers.Transformers
{
    public static class Transformer
    {
        private static DateTime ConvertTimestamp(int ts)
        {
            DateTime dt = new DateTime(1970, 1, 1);
            dt = dt.AddSeconds(ts);
            return dt;
        }

        private static Location ConvertStringToLocation(string str)
        {
            string[] strs = str.Split(':');
            if (strs.Length != 2)
            {
                strs = str.Split(',');
            }
            if (str == "")
            {
                return null;
            }
            Location location = new Location()
            {
                Latitude = double.Parse(strs[0], CultureInfo.InvariantCulture),
                Longitude = double.Parse(strs[1], CultureInfo.InvariantCulture)
            };
            return location;
        }

        public static Concert TransformEventToConcert(Event e)
        {
            return new Concert()
            {
                Title = e.Title,
                Date = ConvertTimestamp(e.Timestamp),
                Genres = e.Genres.Genre,
                Description = e.Description,
                Url = e.Url,
                ClubName = e.Club.Name,
                ClubAdress = e.Club.Adress,
                ClubLocation = ConvertStringToLocation(e.Club.Location),
                ClubTelephone = e.Club.Telephone,
                Afisha = e.Images.Afisha,
                SmallAfisha = e.Images.SmallAfisha
            };
        }

        public static Place TransformGooglePlaceToPlace(GooglePlace gp)
        {
            Place place = new Place()
            {
                Id = gp.PlaceId,
                Name = gp.Name,
                Categories = gp.Categories,
                Rating = gp.Rating,
                Location = gp.Geometry.Location.Latitude.ToString() + " " + gp.Geometry.Location.Longitude.ToString(),
                Address = gp.Address,
                Icon = gp.Icon,
                OpenNow = gp.OpenHours.OpenNow.ToString(),
                PriceLevel = gp.PriceLevel.ToString()
            };
            return place;
        }

        public static DetailedPlace TransformGoogleDetailedPlaceToPlace(DetailedGooglePlace dgp, Place place)
        {
            DetailedPlace detPlace = new DetailedPlace()
            {
                Id = dgp.PlaceId,
                Name = dgp.Name,
                Categories = dgp.Categories,
                Rating = dgp.Rating,
                Location = dgp.Geometry.Location.Latitude.ToString() + " " + dgp.Geometry.Location.Longitude.ToString(),
                Address = dgp.Address,
                Icon = place.Icon,
                OpenNow = dgp.OpenHours.OpenNow.ToString(),
                PriceLevel = place.PriceLevel.ToString(),
                Reviews = dgp.Reviews,
                PhoneNumber = dgp.PhoneNumber,
                WebSite = dgp.WebSite
            };
            return detPlace;
        }
    }
}
