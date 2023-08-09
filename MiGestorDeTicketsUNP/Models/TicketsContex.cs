using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MiGestorDeTicketsUNP.Models
{
    public partial class TicketsContex : DbContext
    {
        public TicketsContex()
            : base("name=TicketsContex")
        {
        }

        public virtual DbSet<Responsable> Responsable { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Tickets> Tickets { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Responsable>()
                .Property(e => e.Nombres)
                .IsUnicode(false);

            modelBuilder.Entity<Responsable>()
                .Property(e => e.Apellidos)
                .IsUnicode(false);

            modelBuilder.Entity<Responsable>()
                .Property(e => e.Correo)
                .IsUnicode(false);

            modelBuilder.Entity<Responsable>()
                .Property(e => e.Cargo)
                .IsUnicode(false);

            modelBuilder.Entity<Responsable>()
                .HasMany(e => e.Tickets)
                .WithOptional(e => e.Responsable)
                .HasForeignKey(e => e.idResponsable);

            modelBuilder.Entity<Status>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.Tickets)
                .WithRequired(e => e.Status)
                .HasForeignKey(e => e.idEstado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tickets>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Tickets>()
                .Property(e => e.Solucion)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Nombres)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Apellidos)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Correo)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Tickets)
                .WithRequired(e => e.Usuario)
                .HasForeignKey(e => e.idUsuario)
                .WillCascadeOnDelete(false);
        }
    }
}
