using System;
using System.Collections.Generic;
using BlazorApp.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace BlazorApp.Data;

public partial class MysqlhomebrewContext : DbContext
{
    public MysqlhomebrewContext()
    {
    }

    public MysqlhomebrewContext(DbContextOptions<MysqlhomebrewContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Fermentable> Fermentables { get; set; }

    public virtual DbSet<Fermentablepair> Fermentablepairs { get; set; }

    public virtual DbSet<Hop> Hops { get; set; }

    public virtual DbSet<Hopaddition> Hopadditions { get; set; }

    public virtual DbSet<Recipe> Recipes { get; set; }

    public virtual DbSet<Yeast> Yeasts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql({connection string}, Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.34-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Fermentable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("fermentables");
        });

        modelBuilder.Entity<Fermentablepair>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("fermentablepair");

            entity.HasIndex(e => e.FermentableId, "IX_FermentablePair_FermentableId");

            entity.HasIndex(e => e.RecipeId, "IX_FermentablePair_RecipeId");

            entity.HasOne(d => d.Fermentable).WithMany(p => p.Fermentablepairs)
                .HasForeignKey(d => d.FermentableId)
                .HasConstraintName("FK_FermentablePair_Fermentables_FermentableId");

            entity.HasOne(d => d.Recipe).WithMany(p => p.Fermentablepairs)
                .HasForeignKey(d => d.RecipeId)
                .HasConstraintName("FK_FermentablePair_Recipes_RecipeId");
        });

        modelBuilder.Entity<Hop>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("hops");
        });

        modelBuilder.Entity<Hopaddition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("hopaddition");

            entity.HasIndex(e => e.HopId, "IX_HopAddition_HopId");

            entity.HasIndex(e => e.RecipeId, "IX_HopAddition_RecipeId");

            entity.HasOne(d => d.Hop).WithMany(p => p.Hopadditions)
                .HasForeignKey(d => d.HopId)
                .HasConstraintName("FK_HopAddition_Hops_HopId");

            entity.HasOne(d => d.Recipe).WithMany(p => p.Hopadditions)
                .HasForeignKey(d => d.RecipeId)
                .HasConstraintName("FK_HopAddition_Recipes_RecipeId");
        });

        modelBuilder.Entity<Recipe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("recipes");

            entity.HasIndex(e => e.YeastId, "IX_Recipes_YeastId");

            entity.Property(e => e.Abv).HasColumnName("ABV");
            entity.Property(e => e.Ibu).HasColumnName("IBU");

            entity.HasOne(d => d.Yeast).WithMany(p => p.Recipes)
                .HasForeignKey(d => d.YeastId)
                .HasConstraintName("FK_Recipes_Yeasts_YeastId");
        });

        modelBuilder.Entity<Yeast>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("yeasts");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
