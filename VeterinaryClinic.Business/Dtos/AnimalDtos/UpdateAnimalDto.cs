using System.ComponentModel.DataAnnotations;

namespace VeterinaryClinic.Business.Dtos.AnimalDtos
{
    public class UpdateAnimalDto
    {
        public int Id { get; set; }

        [Required]
        public string OwnerId { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(0, 100)]
        public int Age { get; set; }

        [Range(0.1, 200)]
        public decimal Weight { get; set; }

        [Range(0.1, 300)]
        public decimal Height { get; set; }

        [Required]
        public string Species { get; set; }

        [Required]
        public string Breed { get; set; }

        public string MedicalHistory { get; set; }
        public string? City { get; set; }
        public string? ImageUrl { get; set; }
    }
}
