﻿// <auto-generated />
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PillowFight.Repositories;
using PillowFight.Repositories.Enumerations;

namespace PillowFight.App.Migrations
{
    [DbContext(typeof(PillowContext))]
    [Migration("20210804203602_PlayerDetails")]
    partial class PlayerDetails
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("PillowFight")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("PillowFight.Repositories.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ArmsSlotItem")
                        .HasColumnType("text");

                    b.Property<int>("ArmsSlotItemId")
                        .HasColumnType("integer");

                    b.Property<int>("Class")
                        .HasColumnType("integer");

                    b.Property<int>("Constitution")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("Dexterity")
                        .HasColumnType("integer");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("HeadSlotItem")
                        .HasColumnType("text");

                    b.Property<int>("HeadSlotItemId")
                        .HasColumnType("integer");

                    b.Property<int>("Intelligence")
                        .HasColumnType("integer");

                    b.Property<string>("LegsSlotItem")
                        .HasColumnType("text");

                    b.Property<int>("LegsSlotItemId")
                        .HasColumnType("integer");

                    b.Property<string>("MainHandSlotItem")
                        .HasColumnType("text");

                    b.Property<int>("MainHandSlotItemId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("OffHandSlotItem")
                        .HasColumnType("text");

                    b.Property<int>("OffHandSlotSlotItemId")
                        .HasColumnType("integer");

                    b.Property<List<StatusEffectEnum>>("StatusEffects")
                        .HasColumnType("integer[]");

                    b.Property<int>("Strength")
                        .HasColumnType("integer");

                    b.Property<string>("TorsoSlotItem")
                        .HasColumnType("text");

                    b.Property<int>("TorsoSlotItemId")
                        .HasColumnType("integer");

                    b.Property<int>("Wisdom")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Characters");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Character");
                });

            modelBuilder.Entity("PillowFight.Repositories.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<List<StatusEffectEnum>>("StatusEffects")
                        .HasColumnType("integer[]");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Items");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Item");
                });

            modelBuilder.Entity("PillowFight.Repositories.Models.Player", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<int>("Losses")
                        .HasColumnType("integer");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("RealName")
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<int>("Wins")
                        .HasColumnType("integer");

                    b.HasKey("Name");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("PillowFight.Repositories.Models.PlayerCharacter", b =>
                {
                    b.HasBaseType("PillowFight.Repositories.Models.Character");

                    b.Property<string>("Player")
                        .HasColumnType("text");

                    b.Property<int>("PlayerId")
                        .HasColumnType("integer");

                    b.HasDiscriminator().HasValue("PlayerCharacter");
                });

            modelBuilder.Entity("PillowFight.Repositories.Models.ArmorItem", b =>
                {
                    b.HasBaseType("PillowFight.Repositories.Models.Item");

                    b.Property<int>("Defense")
                        .HasColumnType("integer");

                    b.HasDiscriminator().HasValue("ArmorItem");
                });

            modelBuilder.Entity("PillowFight.Repositories.Models.WeaponItem", b =>
                {
                    b.HasBaseType("PillowFight.Repositories.Models.Item");

                    b.Property<int>("Attack")
                        .HasColumnType("integer");

                    b.Property<int>("Range")
                        .HasColumnType("integer");

                    b.HasDiscriminator().HasValue("WeaponItem");
                });

            modelBuilder.Entity("PillowFight.Repositories.Models.SpellItem", b =>
                {
                    b.HasBaseType("PillowFight.Repositories.Models.WeaponItem");

                    b.Property<int>("Cost")
                        .HasColumnType("integer");

                    b.HasDiscriminator().HasValue("SpellItem");
                });
#pragma warning restore 612, 618
        }
    }
}
