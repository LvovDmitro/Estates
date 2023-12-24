using Estates.Models;

namespace Estates.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Flat> Flats { get; set; }
        public string City { get; set; }
        public string State { get; set; }

    }
}
