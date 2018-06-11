using DvisualStudio.Core.Interfaces;

namespace DvisualStudio.Core
{
    public class Factory
    {
        static Factory _instance;

        public static Factory Instance => _instance ?? (_instance = new Factory());

        private Factory() { }

        IConcertRepository _repo;

        public IConcertRepository GetRepository()
        {
            return _repo ?? (_repo = new JSONConcertRepository());
        }
    }
}
