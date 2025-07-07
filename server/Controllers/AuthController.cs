using Microsoft.AspNetCore.Mvc;
using PMB_Backend.Models.Auth;
using PMB_Backend.Services;
using System.Threading.Tasks;

namespace PMB_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var user = await _authService.Authenticate(loginDto);
            
            if (user == null)
                return Unauthorized("Email atau password salah");

            return Ok(new {
                Id = user.Id,
                NamaLengkap = user.NamaLengkap,
                Email = user.Email,
                IsAdmin = user.IsAdmin,
                Status = user.Status
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] RegisterDto registerDto)
        {
            try
            {
                var mahasiswa = await _authService.Register(registerDto);
                return Ok(new { 
                    Message = "Pendaftaran berhasil!",
                    Data = new {
                        mahasiswa.NamaLengkap,
                        mahasiswa.Email,
                        Status = mahasiswa.Status
                    }
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}