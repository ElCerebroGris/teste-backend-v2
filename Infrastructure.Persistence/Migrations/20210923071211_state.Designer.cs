﻿// <auto-generated />
using System;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210923071211_state")]
    partial class state
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Domain.Entities.Equipment", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("equipment_model_id")
                        .HasColumnType("uuid");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("equipment_model_id");

                    b.ToTable("equipment");
                });

            modelBuilder.Entity("Domain.Entities.Equipment_Model", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("equipment_Model");
                });

            modelBuilder.Entity("Domain.Entities.Equipment_State", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("equipment_State");

                    b.HasData(
                        new
                        {
                            id = 1,
                            name = "Operando"
                        },
                        new
                        {
                            id = 2,
                            name = "Parado"
                        },
                        new
                        {
                            id = 4,
                            name = "Manutenção"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Equipment_model_state_hourly_earnings", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("equipment_model_id")
                        .HasColumnType("uuid");

                    b.Property<int>("equipment_state_id")
                        .HasColumnType("integer");

                    b.Property<double>("value")
                        .HasColumnType("double precision");

                    b.HasKey("id");

                    b.HasIndex("equipment_model_id");

                    b.HasIndex("equipment_state_id");

                    b.ToTable("equipment_model_state_hourly_earnings");
                });

            modelBuilder.Entity("Domain.Entities.Equipment_position_history", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("equipment_id")
                        .HasColumnType("uuid");

                    b.Property<double>("lat")
                        .HasColumnType("double precision");

                    b.Property<double>("lon")
                        .HasColumnType("double precision");

                    b.HasKey("id");

                    b.HasIndex("equipment_id");

                    b.ToTable("equipment_position_history");
                });

            modelBuilder.Entity("Domain.Entities.Equipment_state_history", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("equipment_id")
                        .HasColumnType("uuid");

                    b.Property<int>("equipment_state_id")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("equipment_id");

                    b.HasIndex("equipment_state_id");

                    b.ToTable("equipment_state_history");
                });

            modelBuilder.Entity("Domain.Entities.NotaUtilizador", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Descricao")
                        .HasColumnType("text");

                    b.Property<string>("IdUtilizador")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Notas");
                });

            modelBuilder.Entity("Domain.Entities.Equipment", b =>
                {
                    b.HasOne("Domain.Entities.Equipment_Model", "Equipment_Model")
                        .WithMany()
                        .HasForeignKey("equipment_model_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipment_Model");
                });

            modelBuilder.Entity("Domain.Entities.Equipment_model_state_hourly_earnings", b =>
                {
                    b.HasOne("Domain.Entities.Equipment_Model", "Equipment_Model")
                        .WithMany()
                        .HasForeignKey("equipment_model_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Equipment_State", "Equipment_State")
                        .WithMany()
                        .HasForeignKey("equipment_state_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipment_Model");

                    b.Navigation("Equipment_State");
                });

            modelBuilder.Entity("Domain.Entities.Equipment_position_history", b =>
                {
                    b.HasOne("Domain.Entities.Equipment", "Equipment")
                        .WithMany()
                        .HasForeignKey("equipment_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipment");
                });

            modelBuilder.Entity("Domain.Entities.Equipment_state_history", b =>
                {
                    b.HasOne("Domain.Entities.Equipment", "Equipment")
                        .WithMany()
                        .HasForeignKey("equipment_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Equipment_State", "Equipment_State")
                        .WithMany()
                        .HasForeignKey("equipment_state_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipment");

                    b.Navigation("Equipment_State");
                });
#pragma warning restore 612, 618
        }
    }
}
