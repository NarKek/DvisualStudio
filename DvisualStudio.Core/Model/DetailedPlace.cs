﻿using DvisualStudio.API.DTO.GooglePlaceInfoAPI;
using System.Collections.Generic;

namespace DvisualStudio.Core.Model
{
    public class DetailedPlace : Place
    {
        //public string Review { get; set; }
        //public string ReviewAuthor { get; set; }
        public IEnumerable<Review> Reviews { get; set; }
        public string PhoneNumber { get; set; }
        public string WebSite { get; set; }
        public string Author { get; set; }
        public string Comment { get; set; }
    }
}
