using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMB_Backend.Models
{
    public class Mahasiswa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string NamaLengkap { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        
        public string AlamatAsal { get; set; }
        public string AlamatSemarang { get; set; }
        public string TempatLahir { get; set; }
        public DateTime TanggalLahir { get; set; }
        public string Agama { get; set; }
        public string JenisKelamin { get; set; }
        public string AsalSekolah { get; set; }
        public string JurusanFakultas { get; set; }
        public string FotoPath { get; set; }

        [Required]
        public bool IsAdmin { get; set; } = false;

        [Required]
        public string Status { get; set; } = "Pending"; 
    }
}