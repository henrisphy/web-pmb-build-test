using Microsoft.AspNetCore.Http;

namespace PMB_Backend.Models.Auth
{
    public class RegisterDto
    {
        public string NamaLengkap { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public IFormFile Foto { get; set; }
        
    }
}