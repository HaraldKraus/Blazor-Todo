using System.ComponentModel.DataAnnotations;

namespace TestBlazorAPP.Models
{
    public class Aufgabe
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Bitte gib deiner Aufgabe einen Titel.")]
        
        public string Name { get; set; } = string.Empty;
        public int Prioritaet { get; set; } = 1;
        public bool Geloescht { get; set; } = false;

        // Fremdschlüsssel
        public Bild? Bild { get; set; }

        public string schoenePrio()
        {
            switch (Prioritaet)
            {
                case 0:
                    return "Low";
                    break;
                case 1:
                    return "Medium";
                    break;
                default:
                    return "High";
                    break;
            }
        }
    }
}
