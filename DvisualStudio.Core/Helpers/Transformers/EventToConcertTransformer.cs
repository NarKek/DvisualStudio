using DvisualStudio.API.DTO;
using DvisualStudio.API.DTO.ConcertInfo;
using DvisualStudio.Core.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvisualStudio.Core.Helpers.Transformers
{
    public class EventToConcertTransformer
    {
        public DateTime ConvertTimestamp(int ts)
        {
            DateTime dt = new DateTime(1970, 1, 1);
            dt = dt.AddSeconds(ts);
            return dt;
        }

        public Location ConvertStringToLocation(string str)
        {
            string[] strs = str.Split(':');
            if (strs.Length != 2)
            {
                strs = str.Split(',');
            }
            if (str == "")
            {
                strs = new string[2];
                strs[0] = "0";
                strs[1] = "0";
            }
            Location location = new Location()
            {
                Latitude = double.Parse(strs[0], CultureInfo.InvariantCulture),
                Longitude = double.Parse(strs[1], CultureInfo.InvariantCulture)
            };
            return location;
        }

        public Concert Transfrom(Event e)
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
    }
}
