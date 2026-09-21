using Microsoft.AspNetCore.Identity;

namespace VeterinaryClinic.Entities
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
        public List<Animal> Animals { get; set; }

    }
}
