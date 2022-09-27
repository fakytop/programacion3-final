﻿// <auto-generated />
using System;
using LogicaAccesoDatos.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LogicaAccesoDatos.Migrations
{
    [DbContext(typeof(ObligatorioContext))]
    partial class ObligatorioContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LogicaNegocio.Entidades.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("LogicaNegocio.Entidades.NationalTeam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("NationalTeams");
                });

            modelBuilder.Entity("LogicaNegocio.Entidades.Country", b =>
                {
                    b.OwnsOne("LogicaNegocio.VO.ISOAlfa3Value", "IsoAlfa3", b1 =>
                        {
                            b1.Property<int>("CountryId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Value")
                                .HasColumnName("ISOAlfa3")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("CountryId");

                            b1.ToTable("Countries");

                            b1.WithOwner()
                                .HasForeignKey("CountryId");
                        });

                    b.OwnsOne("LogicaNegocio.VO.NameValue", "Name", b1 =>
                        {
                            b1.Property<int>("CountryId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Value")
                                .HasColumnName("Name")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("CountryId");

                            b1.ToTable("Countries");

                            b1.WithOwner()
                                .HasForeignKey("CountryId");
                        });

                    b.OwnsOne("LogicaNegocio.VO.PositiveFloatValue", "GDP", b1 =>
                        {
                            b1.Property<int>("CountryId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<decimal>("Value")
                                .HasColumnName("GDP")
                                .HasColumnType("decimal(18,4)");

                            b1.HasKey("CountryId");

                            b1.ToTable("Countries");

                            b1.WithOwner()
                                .HasForeignKey("CountryId");
                        });

                    b.OwnsOne("LogicaNegocio.VO.PositiveIntegerValue", "Population", b1 =>
                        {
                            b1.Property<int>("CountryId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<int>("Value")
                                .HasColumnName("Population")
                                .HasColumnType("int");

                            b1.HasKey("CountryId");

                            b1.ToTable("Countries");

                            b1.WithOwner()
                                .HasForeignKey("CountryId");
                        });

                    b.OwnsOne("LogicaNegocio.VO.RegionValue", "Region", b1 =>
                        {
                            b1.Property<int>("CountryId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Value")
                                .HasColumnName("Region")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("CountryId");

                            b1.ToTable("Countries");

                            b1.WithOwner()
                                .HasForeignKey("CountryId");
                        });
                });

            modelBuilder.Entity("LogicaNegocio.Entidades.NationalTeam", b =>
                {
                    b.HasOne("LogicaNegocio.Entidades.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.OwnsOne("LogicaNegocio.VO.EmailValue", "Email", b1 =>
                        {
                            b1.Property<int>("NationalTeamId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Value")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("NationalTeamId");

                            b1.ToTable("NationalTeams");

                            b1.WithOwner()
                                .HasForeignKey("NationalTeamId");
                        });

                    b.OwnsOne("LogicaNegocio.VO.NameValue", "Name", b1 =>
                        {
                            b1.Property<int>("NationalTeamId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Value")
                                .HasColumnName("Name")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("NationalTeamId");

                            b1.ToTable("NationalTeams");

                            b1.WithOwner()
                                .HasForeignKey("NationalTeamId");
                        });

                    b.OwnsOne("LogicaNegocio.VO.PhoneNumber", "Phone", b1 =>
                        {
                            b1.Property<int>("NationalTeamId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Value")
                                .HasColumnName("Phone")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("NationalTeamId");

                            b1.ToTable("NationalTeams");

                            b1.WithOwner()
                                .HasForeignKey("NationalTeamId");
                        });

                    b.OwnsOne("LogicaNegocio.VO.PositiveIntegerValue", "Bettors", b1 =>
                        {
                            b1.Property<int>("NationalTeamId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<int>("Value")
                                .HasColumnName("Bettors")
                                .HasColumnType("int");

                            b1.HasKey("NationalTeamId");

                            b1.ToTable("NationalTeams");

                            b1.WithOwner()
                                .HasForeignKey("NationalTeamId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
