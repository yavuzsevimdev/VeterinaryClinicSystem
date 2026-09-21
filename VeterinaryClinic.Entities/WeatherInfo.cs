using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinaryClinic.Entities
{
    public class WeatherInfo
    {
        public int Id { get; set; }
        public string City { get; set; }
        public decimal Temperature { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
