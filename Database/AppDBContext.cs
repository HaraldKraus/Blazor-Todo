﻿using Microsoft.EntityFrameworkCore;
using System;
using TestBlazorAPP.Models;

namespace TestBlazorAPP.Database
{
    public class AppDBContext : DbContext
    {
        /* Datenbank updaten
         * in Package Manager Console
         * Add-Migration <Migrationsname>
         * Update-Database
         * 
         * Datenbank Migrationen löschen
         * Remove-Migration (so oft wiederholen bis keine mehr da sind)
         */
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        /* Falls ein anderes Schema in Postgres verwendet wird 
           So kann man ein default Schema deklarieren
        */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ToDo");

            // So kann man beim Datenbank Aufbau bereits Daten einspielen
            modelBuilder.Entity<Aufgabe>().HasData(
                new Aufgabe { Id = 1, Name = "Testaufgabe", Prioritaet = 1 }
            );

            // Referenzen auf andere Tabellen
            
            modelBuilder.Entity<Aufgabe>()
                .HasOne(a => a.Bild)
                .WithOne(b => b.Aufgabe)
                .HasForeignKey<Bild>(b => b.AufgabeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Bild>()
                .HasOne(b => b.Aufgabe)
                .WithOne(a => a.Bild)
                .OnDelete(DeleteBehavior.NoAction);           
        }

        public DbSet<Aufgabe> Aufgabe { get; set; }
        public DbSet<Bild> Bild { get; set; }
        public DbSet<Benutzer> Benutzer { get; set; }
    }
}
