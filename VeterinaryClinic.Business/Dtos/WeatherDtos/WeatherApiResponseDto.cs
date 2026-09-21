namespace VeterinaryClinic.Business.Dtos.WeatherDtos
{
    public class WeatherApiResponseDto
    {
        public string Name { get; set; }
        public MainDto Main { get; set; }
        public List<WeatherDescriptionDto> Weather { get; set; }
    }
}
