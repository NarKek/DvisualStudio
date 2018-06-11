using DvisualStudio.Core.Model;
using System.Collections.Generic;

namespace DvisualStudio.Core.Interfaces
{
    public interface IConcertRepository
    {
        IEnumerable<Concert> Concerts { get; }
    }
}
