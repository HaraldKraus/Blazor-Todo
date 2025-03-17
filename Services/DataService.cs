using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using TestBlazorAPP.Components.Pages;
using TestBlazorAPP.Database;
using TestBlazorAPP.Models;

namespace TestBlazorAPP.Services
{
    public class DataService
    {
        // Die Kontext Factory welche die Datenbankverbindung aufbaut
        private readonly IDbContextFactory<AppDBContext> _dbContextFactory;

        // Im Konstruktor wird die ContextFactory übergeben die wir in Program.cs erstellt haben
        // Das passiert automatisch
        public DataService(IDbContextFactory<AppDBContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        /// <summary>
        /// Holt alle nicht gelöschten Aufgaben aus der Datenbank
        /// </summary>
        /// <returns>Eine Liste von Aufgaben die nicht gelöscht sind</returns>
        public List<Aufgabe> GetAufgaben()
        {
            AppDBContext dbConnection = this._dbContextFactory.CreateDbContext();

            List<Aufgabe> aufgaben = dbConnection.Aufgabe.Where(a => a.Geloescht == false).ToList();

            return aufgaben;
        }

        /// <summary>
        /// Holt alle gelöschten Aufgaben aus der Datenbank
        /// </summary>
        /// <returns>Eine Liste von Aufgaben die gelöscht wurden</returns>
        public List<Aufgabe> GetGeloeschteAufgaben()
        {
            AppDBContext dbConnection = this._dbContextFactory.CreateDbContext();

            List<Aufgabe> aufgaben = dbConnection.Aufgabe.Where(a => a.Geloescht == true).ToList();

            return aufgaben;
        }

        public bool AddAufgabe(Aufgabe aufgabe)
        {
            AppDBContext dbConnection = this._dbContextFactory.CreateDbContext();

            if(dbConnection.Aufgabe.Where(t => t.Name == aufgabe.Name).Where(abc => abc.Geloescht == false).Count() == 0)
            {
                dbConnection.Aufgabe.Add(aufgabe);
                dbConnection.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
        }

        public void DeleteAufgabe(Aufgabe aufgabe)
        {
            AppDBContext dbConnection = this._dbContextFactory.CreateDbContext();

            dbConnection.Aufgabe.Attach(aufgabe);

            aufgabe.Geloescht = true;

            dbConnection.Entry(aufgabe).State = EntityState.Modified;

            dbConnection.SaveChanges();
        }

        public void RestoreAufgabe(Aufgabe aufgabe)
        {
            AppDBContext dbConnection = this._dbContextFactory.CreateDbContext();

            dbConnection.Aufgabe.Attach(aufgabe);

            aufgabe.Geloescht = false;

            dbConnection.Entry(aufgabe).State = EntityState.Modified;

            dbConnection.SaveChanges();
        }
    }
}
