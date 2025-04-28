using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace TestBlazorAPP.Models
{
    public class Benutzer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Bitte gib einen Usernamen ein.")]
        [MinLength(4, ErrorMessage = "Dein Benutzername muss mind. 4 Zeichen lang sein.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Bitte gib ein Passwort ein.")]
        [MinLength(4, ErrorMessage = "Dein Passwort muss mindesten 4 Zeichen lang sein.")]
        public string Password { get; set; }

        // Um User und Administratoren zu unterscheiden
        public string Role { get; set; } = "User";
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastLogin { get; set; } = DateTime.MinValue;

        void HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.Unicode.GetBytes(password));
                this.Password = BitConverter.ToString(hashBytes).Replace("-", "").ToUpper();
            }
        }
    }
}
