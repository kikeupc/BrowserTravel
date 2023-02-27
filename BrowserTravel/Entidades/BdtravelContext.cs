using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BrowserTravel.Entidades;

public partial class BdtravelContext : DbContext
{
    public BdtravelContext()
    {
    }

    public BdtravelContext(DbContextOptions<BdtravelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Autore> Autores { get; set; }

    public virtual DbSet<Editoriale> Editoriales { get; set; }

    public virtual DbSet<Libro> Libros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=DESKTOP-MACDQE2\\SQLEXPRESS; database=BrowserTravel; integrated security=true; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Autore>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Autores__3213E83F56BD12C3");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("apellidos");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasMany(d => d.LibrosIsbns).WithMany(p => p.Autores)
                .UsingEntity<Dictionary<string, object>>(
                    "AutoresHasLibro",
                    r => r.HasOne<Libro>().WithMany()
                        .HasForeignKey("LibrosIsbn")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Autores_h__libro__4F7CD00D"),
                    l => l.HasOne<Autore>().WithMany()
                        .HasForeignKey("AutoresId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Autores_h__autor__4E88ABD4"),
                    j =>
                    {
                        j.HasKey("AutoresId", "LibrosIsbn");
                        j.ToTable("Autores_has_libros");
                        j.IndexerProperty<int>("AutoresId").HasColumnName("autores_id");
                        j.IndexerProperty<int>("LibrosIsbn").HasColumnName("libros_ISBN");
                    });
        });

        modelBuilder.Entity<Editoriale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Editoria__3213E83F79F0FAD6");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Sede)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("sede");
        });

        modelBuilder.Entity<Libro>(entity =>
        {
            entity.HasKey(e => e.Isbn).HasName("PK__Libros__447D36EB55DB40E4");

            entity.Property(e => e.Isbn)
                .ValueGeneratedNever()
                .HasColumnName("ISBN");
            entity.Property(e => e.EditorialesId).HasColumnName("editoriales_id");
            entity.Property(e => e.NPaginas)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("n_paginas");
            entity.Property(e => e.Sinopsis)
                .HasColumnType("text")
                .HasColumnName("sinopsis");
            entity.Property(e => e.Titulo)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("titulo");

            entity.HasOne(d => d.Editoriales).WithMany(p => p.Libros)
                .HasForeignKey(d => d.EditorialesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Libros__editoria__5070F446");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
