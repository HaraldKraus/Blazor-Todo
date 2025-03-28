namespace TestBlazorAPP.Models
{
    public class Bild
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Data { get; set; }
        public string ContentType { get; set; }

        // Foreign Keys
        public int AufgabeId { get; set; }
        public Aufgabe Aufgabe { get; set; }
    }
}
