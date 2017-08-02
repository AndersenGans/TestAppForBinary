using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TestAppForBinary.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public string BodyStyle { get; set; }

        [ForeignKey("Id")]
        public int ManufacturerId { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
    }
}