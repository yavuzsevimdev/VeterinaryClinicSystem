namespace VeterinaryClinic.UI.Dtos.Weather
{
    public class WeatherDto
    {
        public int Id { get; set; }
        public string City { get; set; }
        public decimal Temperature { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
