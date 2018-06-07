using DvisualStudio.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvisualStudio.Core.Interfaces
{
    public interface IConcertRepository
    {
        IEnumerable<Concert> Concerts { get; }
    }
}
