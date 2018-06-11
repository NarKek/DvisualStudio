using DvisualStudio.API.DTO;
using DvisualStudio.API.DTO.ConcertInfo;
using DvisualStudio.API.DTO.GooglePlaceInfoAPI;
using DvisualStudio.API.DTO.GooglePlacesTextSearchAPI;
using DvisualStudio.API.Interfaces;
using DvisualStudio.API.Services;
using DvisualStudio.Core.Interfaces;
using DvisualStudio.Core.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace DvisualStudio.Core.Helpers.Transformers
{
    public class GoogleTransformer : ITransformer
    {
        private DateTime ConvertTimestampToDateTime(int ts)
        {
            DateTime dt = new DateTime(1970, 1, 1);
            dt = dt.AddSeconds(ts);
            return dt;
        }

        private Location ConvertStringToLocation(string str)
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

        public Concert TransfromJsonEventToConcert(Event e)
        {
            Concert concert = new Concert()
            {
                Name = e.Title,
                Date = ConvertTimestampToDateTime(e.Timestamp),
                Categories = e.Genres.Genre,
                Description = e.Description,
                Url = e.Url,
                ClubName = e.Club.Name,
                Address = e.Club.Adress,
                ClubLocation = ConvertStringToLocation(e.Club.Location),
                ClubTelephone = e.Club.Telephone,
                Icon = e.Images.Afisha,
                SmallAfisha = e.Images.SmallAfisha
            };
            concert.Category = concert.Categories.FirstOrDefault();
            return concert;
        }

        public Place TransformTextPlaceToPlace(GoogleTextSearchPlace gtp)
        {
            IPhotosService photoService = new GooglePhotosService();

            Place place = new Place()
            {
                Id = gtp.PlaceId,
                Name = gtp.Name,
                Categories = gtp.Categories,
                Rating = gtp.Rating,
                Location = gtp.Geometry.Location.Latitude.ToString() + " " + gtp.Geometry.Location.Longitude.ToString(),
                Address = gtp.Address ?? "",
                Icon = gtp.Icon ?? "",
                OpenNow = gtp.OpenHours?.OpenNow ?? false
            };

            if (gtp.GooglePhotos == null)
            {
                place.PhotoReference = place.Icon;
                place.Photo = place.Icon;
            }
            else
            {
                place.PhotoReference = gtp.GooglePhotos[0].PhotoReference;
                place.Photo = photoService.GetImageByReference(place.PhotoReference, "100", "80");
            }
            return place;
        }

        public Place TransformAPINerabyPlaceToPlace(GooglePlace gp)
        {
            IPhotosService photoService = new GooglePhotosService();

            var gplace = gp;
            Place place = new Place()
            {
                Id = gp.PlaceId,
                Name = gp.Name,
                Categories = gp.Categories ?? new List<string>(),
                Rating = gp.Rating,
                Location = gp.Geometry.Location.Latitude.ToString() + " " + gp.Geometry.Location.Longitude.ToString(),
                Address = gp.Address ?? "",
                Icon = gp.Icon,
                OpenNow = gp.OpenHours?.OpenNow ?? false
            };
            if (gp.GooglePhotos == null)
            {
                place.PhotoReference = place.Icon;
                place.Photo = place.Icon;
            }
            else
            {
                place.PhotoReference = gp.GooglePhotos[0].PhotoReference;
                place.Photo = photoService.GetImageByReference(place.PhotoReference, "100", "80");
            }

            if (gp.PriceLevel.ToString() != "")
            {
                place.PriceLevel = gp.PriceLevel.ToString();
            }
            else
            {
                place.PriceLevel = "5";
            }

            switch (place.PriceLevel)
            {
                case "0":
                    place.PriceString = "free";
                    break;
                case "1":
                    place.PriceString = "cheap";
                    break;
                case "2":
                    place.PriceString = "moderate";
                    break;
                case "3":
                    place.PriceString = "expensive";
                    break;
                case "4":
                    place.PriceString = "very expensive";
                    break;
                case "5":
                    place.PriceString = "unknown";
                    break;
            }
            return place;
        }

        public DetailedPlace TransformDetailedPlaceToPlace(DetailedGooglePlace dgp, Place place)
        {
            IPhotosService photo = new GooglePhotosService();
            DetailedPlace detPlace = new DetailedPlace()
            {
                Id = dgp.PlaceId,
                Name = dgp.Name,
                Categories = dgp.Categories,
                Rating = dgp.Rating,
                Location = dgp.Geometry.Location.Latitude.ToString() + " " + dgp.Geometry.Location.Longitude.ToString(),
                Address = place.Address,
                Icon = place.Icon,
                OpenNow = dgp.OpenHours?.OpenNow ?? false,
                PriceLevel = place.PriceLevel,
                PriceString = place.PriceString,
                Reviews = dgp.Reviews,
                PhoneNumber = dgp.PhoneNumber,
                WebSite = dgp.WebSite,
                Photo = photo.GetImageByReference(place.PhotoReference, "184", "400")
            };

            if (detPlace.Reviews != null)
            {
                detPlace.Author = detPlace.Reviews.FirstOrDefault().ReviewAuthor;
                detPlace.Comment = detPlace.Reviews.FirstOrDefault().ReviewText;
            }
            return detPlace;
        }
    }
}
