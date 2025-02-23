﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vortex.Manager.Infrastructure.Data.Context;

#nullable disable

namespace Vortex.Manager.WebApp.Migrations
{
    [DbContext(typeof(VortextManagerContext))]
    partial class VortextManagerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.20");

            modelBuilder.Entity("Vortex.Manager.Domain.Entity.Noticia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Noticias");
                });

            modelBuilder.Entity("Vortex.Manager.Domain.Entity.NoticiaTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("NoticiaId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TagId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("NoticiaId");

                    b.HasIndex("TagId");

                    b.ToTable("NoticiaTags");
                });

            modelBuilder.Entity("Vortex.Manager.Domain.Entity.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Vortex.Manager.Domain.Entity.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Vortex.Manager.Domain.Entity.Noticia", b =>
                {
                    b.HasOne("Vortex.Manager.Domain.Entity.Usuario", "Usuario")
                        .WithMany("Noticias")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Vortex.Manager.Domain.Entity.NoticiaTag", b =>
                {
                    b.HasOne("Vortex.Manager.Domain.Entity.Noticia", "Noticia")
                        .WithMany("NoticiaTag")
                        .HasForeignKey("NoticiaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vortex.Manager.Domain.Entity.Tag", "Tag")
                        .WithMany("Noticias")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Noticia");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("Vortex.Manager.Domain.Entity.Noticia", b =>
                {
                    b.Navigation("NoticiaTag");
                });

            modelBuilder.Entity("Vortex.Manager.Domain.Entity.Tag", b =>
                {
                    b.Navigation("Noticias");
                });

            modelBuilder.Entity("Vortex.Manager.Domain.Entity.Usuario", b =>
                {
                    b.Navigation("Noticias");
                });
#pragma warning restore 612, 618
        }
    }
}
