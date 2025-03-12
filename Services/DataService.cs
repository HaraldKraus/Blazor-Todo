using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using TestBlazorAPP.Database;
using TestBlazorAPP.Models;

namespace TestBlazorAPP.Services
{
    public class DataService
    {
        List<Aufgabe> aufgabenListe = new List<Aufgabe>();

        // Die Kontext Factory welche die Datenbankverbindung aufbaut
        private readonly IDbContextFactory<AppDBContext> _dbContextFactory;

        // Im Konstruktor wird die ContextFactory übergeben die wir in Program.cs erstellt haben
        // Das passiert automatisch
        public DataService(IDbContextFactory<AppDBContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public List<Aufgabe> GetAufgaben()
        {
            AppDBContext dbConnection = this._dbContextFactory.CreateDbContext();

            List<Aufgabe> aufgaben = dbConnection.Aufgabe.ToList();

            return aufgaben;
        }

        public bool AddAufgabe(Aufgabe aufgabe)
        {
            AppDBContext dbConnection = this._dbContextFactory.CreateDbContext();

            dbConnection.Aufgabe.Add(aufgabe);
            dbConnection.SaveChanges();

            return true;
            /*
            if (aufgabenListe.Where(t => t.Name == aufgabe.Name).Count() == 0)
            {
                this.aufgabenListe.Add(aufgabe);
                return true;
            }
            else
            {
                return false;
            }
            */
        }

        public void DeleteAufgabe(Aufgabe aufgabe)
        {
            this.aufgabenListe.Remove(aufgabe);
        }
    }
}
