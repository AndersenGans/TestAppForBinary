using System.Collections.Generic;

namespace TestAppForBinary.Models
{
    public class Manufacturer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string GenDirector { get; set; }
        public string HoldingCompany { get; set; }
        public string WebSite { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}