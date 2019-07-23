using System;
using System.Collections.Generic;
using SharedLibrary;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using System.Data.Objects;

namespace AppModel
{
    /// <summary>
    /// Класс, представляющий контекст данных Документов и Позиций(Модель).
    /// </summary>
    public class DocContext : DbContext
    {
        
        public DocContext() : base("DocConnection") { }

        /// <summary>
        /// Набор Документов.
        /// </summary>
        public DbSet<Document> Documents { get; set; }
        /// <summary>
        /// Набор Позиций.
        /// </summary>
        public DbSet<Position> Positions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Document>()
                        .HasKey(d => d.Number)
                        .Property(d => d.Number)
                        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Document>()
                        .Property(d => d.Date)
                        .HasColumnType("datetime2");
            modelBuilder.Entity<Position>()
                        .HasKey(p => p.Number)
                        .Property(p => p.Number)
                        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Document>().HasMany(d => d.Positions)
                                           .WithRequired(p => p.Document)
                                           .HasForeignKey(p => p.DocumentNum);
        }
    }
}
