namespace VeterinaryClinic.Entities
{
    public class Animal
    {
        public int Id { get; set; }
        public string OwnerId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public string Species { get; set; }
        public string Breed { get; set; }
        public string? City { get; set; }
        public string? ImageUrl { get; set; }
        public string MedicalHistory { get; set; }
        public User Owner { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}
