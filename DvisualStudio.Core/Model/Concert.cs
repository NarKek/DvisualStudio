using DvisualStudio.API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvisualStudio.Core.Model
{
    public class Concert
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<string> Genres { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string ClubName { get; set; }
        public string ClubAdress { get; set; }
        public Location ClubLocation { get; set; }
        public string ClubTelephone { get; set; }
        public string Afisha { get; set; }
        public string SmallAfisha { get; set; }
    }
}
