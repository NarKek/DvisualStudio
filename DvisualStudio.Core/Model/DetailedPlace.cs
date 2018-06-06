using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvisualStudio.Core.Model
{
    public class DetailedPlace : Place
    {
        public string Review { get; set; }
        public string ReviewAuthor { get; set; }
        public string PhoneNumber { get; set; }
        public string WebSite { get; set; }
    }
}
