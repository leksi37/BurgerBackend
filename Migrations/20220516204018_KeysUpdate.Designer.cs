// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi.Helpers;

#nullable disable

namespace WebApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220516204018_KeysUpdate")]
    partial class KeysUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.5");

            modelBuilder.Entity("WebApi.Entities.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("AcceptTerms")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("PasswordReset")
                        .HasColumnType("TEXT");

                    b.Property<string>("ResetToken")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ResetTokenExpires")
                        .HasColumnType("TEXT");

                    b.Property<int>("Role")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("TEXT");

                    b.Property<string>("VerificationToken")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Verified")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("WebApi.Entities.Burger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BurgerPlaceId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<int>("ScoreId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Burgers");
                });

            modelBuilder.Entity("WebApi.Entities.BurgerPlace", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<double>("OverallScore")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("BurgerPlaces");
                });

            modelBuilder.Entity("WebApi.Entities.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BurgerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ScoreId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("WebApi.Entities.Score", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("OverallScore")
                        .HasColumnType("REAL");

                    b.Property<double>("TasteScore")
                        .HasColumnType("REAL");

                    b.Property<double>("TextureScore")
                        .HasColumnType("REAL");

                    b.Property<double>("VisualScore")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Scores");
                });

            modelBuilder.Entity("WebApi.Entities.Account", b =>
                {
                    b.OwnsMany("WebApi.Entities.RefreshToken", "RefreshTokens", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("INTEGER");

                            b1.Property<int>("AccountId")
                                .HasColumnType("INTEGER");

                            b1.Property<DateTime>("Created")
                                .HasColumnType("TEXT");

                            b1.Property<string>("CreatedByIp")
                                .HasColumnType("TEXT");

                            b1.Property<DateTime>("Expires")
                                .HasColumnType("TEXT");

                            b1.Property<string>("ReasonRevoked")
                                .HasColumnType("TEXT");

                            b1.Property<string>("ReplacedByToken")
                                .HasColumnType("TEXT");

                            b1.Property<DateTime?>("Revoked")
                                .HasColumnType("TEXT");

                            b1.Property<string>("RevokedByIp")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Token")
                                .HasColumnType("TEXT");

                            b1.HasKey("Id");

                            b1.HasIndex("AccountId");

                            b1.ToTable("RefreshToken");

                            b1.WithOwner("Account")
                                .HasForeignKey("AccountId");

                            b1.Navigation("Account");
                        });

                    b.Navigation("RefreshTokens");
                });
#pragma warning restore 612, 618
        }
    }
}
