
using Evaluacion.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evaluacion.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public virtual DbSet<Cuentum> Cuenta { get; set; }
        public virtual DbSet<Socio> Socios { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Cuentum>(entity =>
            {
                entity.ToTable("Cuenta");

                entity.Property(e => e.Numero)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoSocio)
                    //.IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SaldoTotal)
                    //.IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodigoSocioNavigation)
                    .WithMany(p => p.Cuenta)
                    .HasForeignKey(d => d.CodigoSocio)
                    .OnDelete(DeleteBehavior.ClientSetNull);
                    
            });

            modelBuilder.Entity<Socio>(entity =>
            {
               

                entity.ToTable("Socio");

                entity.Property(e => e.Cedula)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Apellido)
                    //.IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                   // .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    //.IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

            });
        }
    }
    }
