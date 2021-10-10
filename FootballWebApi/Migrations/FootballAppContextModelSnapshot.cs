﻿// <auto-generated />
using System;
using FootballWebApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FootballWebApi.Migrations
{
    [DbContext(typeof(FootballAppContext))]
    partial class FootballAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("FootballWebApi.Models.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CityId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateOfMatch")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Team1Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Team1Score")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Team2Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Team2Score")
                        .HasColumnType("INTEGER");

                    b.Property<string>("WinnerTeam")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("Team1Id");

                    b.HasIndex("Team2Id");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("FootballWebApi.Models.MatchLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Location")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("MatchLocations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Location = "Liverpool, England"
                        },
                        new
                        {
                            Id = 2,
                            Location = "Manchester, England"
                        },
                        new
                        {
                            Id = 3,
                            Location = "Buenos Aires, Argentina"
                        },
                        new
                        {
                            Id = 4,
                            Location = "Madrid, Spain"
                        },
                        new
                        {
                            Id = 5,
                            Location = "Mexico City, Mexico"
                        },
                        new
                        {
                            Id = 6,
                            Location = "London, England"
                        },
                        new
                        {
                            Id = 7,
                            Location = "Milan, Italy"
                        },
                        new
                        {
                            Id = 8,
                            Location = "Barcelona, Spain"
                        },
                        new
                        {
                            Id = 9,
                            Location = "Rio De Janeiro, Brazil"
                        },
                        new
                        {
                            Id = 10,
                            Location = "Mexico City, Mexico"
                        },
                        new
                        {
                            Id = 11,
                            Location = "Glasgow, Scotland"
                        },
                        new
                        {
                            Id = 12,
                            Location = "Rio de Janeiro, Brazil"
                        },
                        new
                        {
                            Id = 13,
                            Location = "Rome, Italy"
                        },
                        new
                        {
                            Id = 14,
                            Location = "Moscow, Russia"
                        },
                        new
                        {
                            Id = 15,
                            Location = "Lisbon, Portugal"
                        },
                        new
                        {
                            Id = 16,
                            Location = "Rome, Italy"
                        },
                        new
                        {
                            Id = 17,
                            Location = "Athens, Greece"
                        },
                        new
                        {
                            Id = 18,
                            Location = "Madrid, Spain"
                        },
                        new
                        {
                            Id = 19,
                            Location = "Rome, Italy"
                        });
                });

            modelBuilder.Entity("FootballWebApi.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Atlanta Falcons"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Arizona Cardinals"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Carolina Panthers"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Chicago Bears"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Dallas Cowboys"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Detroit Lions"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Green Bay Packers"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Los Angeles Rams"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Minnesota Vikings"
                        },
                        new
                        {
                            Id = 10,
                            Name = "New Orleans Saints"
                        },
                        new
                        {
                            Id = 11,
                            Name = "New York Giants"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Philadelphia Eagles"
                        },
                        new
                        {
                            Id = 13,
                            Name = "San Francisco 49ers"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Seattle Seahawks"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Tampa Bay Buccaneers"
                        },
                        new
                        {
                            Id = 16,
                            Name = "Washington Football Team"
                        },
                        new
                        {
                            Id = 17,
                            Name = "Tennessee Titans"
                        },
                        new
                        {
                            Id = 18,
                            Name = "Pittsburgh Steelers"
                        });
                });

            modelBuilder.Entity("FootballWebApi.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Password = "3043AA4A83B0934982956A90828140CB834869135B5F294938865DE12E036DE440A330E1E8529BEC15DDD59F18D1161A97BFEC110D2622680F2C714A737D7061",
                            Role = "Admin",
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("FootballWebApi.Models.Match", b =>
                {
                    b.HasOne("FootballWebApi.Models.MatchLocation", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.HasOne("FootballWebApi.Models.Team", "Team1")
                        .WithMany()
                        .HasForeignKey("Team1Id");

                    b.HasOne("FootballWebApi.Models.Team", "Team2")
                        .WithMany()
                        .HasForeignKey("Team2Id");

                    b.Navigation("City");

                    b.Navigation("Team1");

                    b.Navigation("Team2");
                });
#pragma warning restore 612, 618
        }
    }
}