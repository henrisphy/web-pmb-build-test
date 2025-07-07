using BCrypt.Net;
using Microsoft.Extensions.Configuration;
using PMB_Backend.Models;
using PMB_Backend.Models.Auth;
using PMB_Backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using System;

namespace PMB_Backend.Services
{
    public class AuthService
    {
        private readonly IConfiguration _config;
        private readonly DatabaseContext _db; 

        public AuthService(IConfiguration config, DatabaseContext db)
        {
            _config = config;
            _db = db;
            InitializeAdmin().Wait(); 
        }

        private async Task InitializeAdmin()
        {
            if (!await _db.Mahasiswas.AnyAsync(m => m.IsAdmin))
            {
                var admin = new Mahasiswa
                {
                    NamaLengkap = "Admin PMB",
                    Email = _config["AdminCredentials:Email"],
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(_config["AdminCredentials:Password"]),
                    IsAdmin = true,
                    Status = "Approved"
                };
                await _db.Mahasiswas.AddAsync(admin);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<Mahasiswa> Authenticate(LoginDto loginDto)
        {
            var user = await _db.Mahasiswas.FirstOrDefaultAsync(m => m.Email == loginDto.Email);
            
            if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
                return null;

            return user;
        }

        public async Task<Mahasiswa> Register(RegisterDto registerDto)
        {
            if (registerDto.Password != registerDto.ConfirmPassword)
                throw new Exception("Password tidak sama");

            if (await _db.Mahasiswas.AnyAsync(m => m.Email == registerDto.Email))
                throw new Exception("Email sudah terdaftar");

            var fotoPath = await SaveFoto(registerDto.Foto);

            var mahasiswa = new Mahasiswa
            {
                NamaLengkap = registerDto.NamaLengkap,
                Email = registerDto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password),
                FotoPath = fotoPath,
                IsAdmin = false,
                Status = "Pending"
            };

            await _db.Mahasiswas.AddAsync(mahasiswa);
            await _db.SaveChangesAsync();
            return mahasiswa;
        }

        private async Task<string> SaveFoto(IFormFile foto)
        {
            if (foto == null || foto.Length == 0)
                throw new Exception("File foto tidak valid");

            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), 
                _config["FileStorage:UploadPath"] ?? "Uploads");
            
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var uniqueFileName = $"{Guid.NewGuid()}_{Path.GetFileName(foto.FileName)}";
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await foto.CopyToAsync(fileStream);
            }

            return uniqueFileName; 
        }
    }
}