﻿// <auto-generated />
using System;
using FootballWebApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FootballWebApi.Migrations
{
    [DbContext(typeof(FootballAppContext))]
    [Migration("20211009191326_newInit")]
    partial class newInit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<int?>("WinnerTeamId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("Team1Id");

                    b.HasIndex("Team2Id");

                    b.HasIndex("WinnerTeamId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("FootballWebApi.Models.MatchLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("MatchLocations");
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

                    b.HasOne("FootballWebApi.Models.Team", "WinnerTeam")
                        .WithMany()
                        .HasForeignKey("WinnerTeamId");

                    b.Navigation("City");

                    b.Navigation("Team1");

                    b.Navigation("Team2");

                    b.Navigation("WinnerTeam");
                });
#pragma warning restore 612, 618
        }
    }
}