﻿using System;
using Abstract.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IntegrationTest
{
    public partial class ClinicAppContext:DbContext
    {
        public ClinicAppContext()
        {
        }

        public ClinicAppContext(DbContextOptions<ClinicAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<SysActions> SysActions { get; set; }
        public virtual DbSet<SysPages> SysPages { get; set; }
        public virtual DbSet<SysPageActions> SysPageActions { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UserClaims> UserClaims { get; set; }
        public virtual DbSet<UserTokens> UserTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Roles>(entity =>
            {
                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SysActions>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ActionName).HasMaxLength(50);
            });

            modelBuilder.Entity<SysPages>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.PageName).HasMaxLength(50);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SysPages_SysPagesParent");
            });

            modelBuilder.Entity<SysPageActions>(entity =>
            {
                entity.HasOne(d => d.Action)
                    .WithMany(p => p.SysPageActions)
                    .HasForeignKey(d => d.ActionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SysPagesActions_SysActions");

                entity.HasOne(d => d.Page)
                    .WithMany(p => p.SysPageActions)
                    .HasForeignKey(d => d.PageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SysPagesActions_SysPages");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.SysPageActions)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_SysPagesActions_Roles");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Email).HasMaxLength(120);

                entity.Property(e => e.EmailConfirmationCode).HasMaxLength(300);

                entity.Property(e => e.EmailNormalized).HasMaxLength(150);

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(120);

                entity.Property(e => e.UsernameNormalized).HasMaxLength(150);
            });

            modelBuilder.Entity<UserClaims>(entity =>
            {
                entity.Property(e => e.ClaimName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ClaimValue)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserClaims)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserClaims_Users");
            });

            modelBuilder.Entity<UserTokens>(entity =>
            {
                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserTokens)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserTokens_Users");
            });
        }
    }
}
