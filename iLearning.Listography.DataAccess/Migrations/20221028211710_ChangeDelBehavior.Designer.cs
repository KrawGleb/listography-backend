﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using iLearning.Listography.DataAccess.Implementations;

#nullable disable

namespace iLearning.Listography.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221028211710_ChangeDelBehavior")]
    partial class ChangeDelBehavior
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("iLearning.Listography.DataAccess.Models.Identity.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SelectedLanguage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SelectedTheme")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "A3BF16BB-378C-4350-8BFF-FF1ED9CB2915",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "8a8efa7c-1429-41b9-8586-b38d3bd40bde",
                            Email = "krawcevitsch@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "KRAWCEVITSCH@GMAIL.COM",
                            NormalizedUserName = "CREATOR",
                            PasswordHash = "AQAAAAEAACcQAAAAENmR3VyO1iFAng5WjdT6ziiANQvfQFn4Qy7WHWJisPNljF6EUGibbRB9mTjpWJ2Y6A",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "33b51609-26fc-4430-a8bf-c3f2b64065b0",
                            State = 0,
                            TwoFactorEnabled = false,
                            UserName = "Creator"
                        });
                });

            modelBuilder.Entity("iLearning.Listography.DataAccess.Models.List.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("ListItemId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("ListItemId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("iLearning.Listography.DataAccess.Models.List.CustomField", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool?>("BoolValue")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DateTimeValue")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ListItemId")
                        .HasColumnType("int");

                    b.Property<int?>("ListItemTemplateId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal?>("NumberValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<int?>("SelectValue")
                        .HasColumnType("int");

                    b.Property<string>("StringValue")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TextValue")
                        .HasMaxLength(600)
                        .HasColumnType("nvarchar(600)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ListItemId");

                    b.HasIndex("ListItemTemplateId");

                    b.ToTable("CustomFields");
                });

            modelBuilder.Entity("iLearning.Listography.DataAccess.Models.List.Like", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("ListItemId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("ListItemId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("iLearning.Listography.DataAccess.Models.List.ListItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("UserListId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserListId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("iLearning.Listography.DataAccess.Models.List.ListItemTemplate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("UserListId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserListId")
                        .IsUnique()
                        .HasFilter("[UserListId] IS NOT NULL");

                    b.ToTable("ItemTemplates");
                });

            modelBuilder.Entity("iLearning.Listography.DataAccess.Models.List.ListTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ListItemId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("ListItemId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("iLearning.Listography.DataAccess.Models.List.ListTopic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Topics");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Books"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Animals"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Movies"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Locations"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Persons"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Games"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Food"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Other"
                        });
                });

            modelBuilder.Entity("iLearning.Listography.DataAccess.Models.List.SelectOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CustomFieldId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomFieldId");

                    b.ToTable("SelectOptions");
                });

            modelBuilder.Entity("iLearning.Listography.DataAccess.Models.List.UserList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasMaxLength(1500)
                        .HasColumnType("nvarchar(1500)");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("TopicId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("TopicId");

                    b.ToTable("Lists");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "677FFB03-B872-4D82-96AF-08A2747699D6",
                            ConcurrencyStamp = "1442e34a-076e-42ba-ae73-64aaa6de6465",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "A98F783C-2C85-46AB-BC7D-73F766D04DB3",
                            ConcurrencyStamp = "8f742f83-55e1-4506-8981-86268ae15f31",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "A3BF16BB-378C-4350-8BFF-FF1ED9CB2915",
                            RoleId = "677FFB03-B872-4D82-96AF-08A2747699D6"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("iLearning.Listography.DataAccess.Models.List.Comment", b =>
                {
                    b.HasOne("iLearning.Listography.DataAccess.Models.Identity.ApplicationUser", "ApplicationUser")
                        .WithMany("Comments")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("iLearning.Listography.DataAccess.Models.List.ListItem", "ListItem")
                        .WithMany("Comments")
                        .HasForeignKey("ListItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("ApplicationUser");

                    b.Navigation("ListItem");
                });

            modelBuilder.Entity("iLearning.Listography.DataAccess.Models.List.CustomField", b =>
                {
                    b.HasOne("iLearning.Listography.DataAccess.Models.List.ListItem", "ListItem")
                        .WithMany("CustomFields")
                        .HasForeignKey("ListItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("iLearning.Listography.DataAccess.Models.List.ListItemTemplate", "ListItemTemplate")
                        .WithMany("CustomFields")
                        .HasForeignKey("ListItemTemplateId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("ListItem");

                    b.Navigation("ListItemTemplate");
                });

            modelBuilder.Entity("iLearning.Listography.DataAccess.Models.List.Like", b =>
                {
                    b.HasOne("iLearning.Listography.DataAccess.Models.Identity.ApplicationUser", "ApplicationUser")
                        .WithMany("Likes")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("iLearning.Listography.DataAccess.Models.List.ListItem", "ListItem")
                        .WithMany("Likes")
                        .HasForeignKey("ListItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("ApplicationUser");

                    b.Navigation("ListItem");
                });

            modelBuilder.Entity("iLearning.Listography.DataAccess.Models.List.ListItem", b =>
                {
                    b.HasOne("iLearning.Listography.DataAccess.Models.List.UserList", "UserList")
                        .WithMany("Items")
                        .HasForeignKey("UserListId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("UserList");
                });

            modelBuilder.Entity("iLearning.Listography.DataAccess.Models.List.ListItemTemplate", b =>
                {
                    b.HasOne("iLearning.Listography.DataAccess.Models.List.UserList", "UserList")
                        .WithOne("ItemTemplate")
                        .HasForeignKey("iLearning.Listography.DataAccess.Models.List.ListItemTemplate", "UserListId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("UserList");
                });

            modelBuilder.Entity("iLearning.Listography.DataAccess.Models.List.ListTag", b =>
                {
                    b.HasOne("iLearning.Listography.DataAccess.Models.List.ListItem", "ListItem")
                        .WithMany("Tags")
                        .HasForeignKey("ListItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("ListItem");
                });

            modelBuilder.Entity("iLearning.Listography.DataAccess.Models.List.SelectOption", b =>
                {
                    b.HasOne("iLearning.Listography.DataAccess.Models.List.CustomField", "CustomField")
                        .WithMany("SelectOptions")
                        .HasForeignKey("CustomFieldId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("CustomField");
                });

            modelBuilder.Entity("iLearning.Listography.DataAccess.Models.List.UserList", b =>
                {
                    b.HasOne("iLearning.Listography.DataAccess.Models.Identity.ApplicationUser", "ApplicationUser")
                        .WithMany("Lists")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("iLearning.Listography.DataAccess.Models.List.ListTopic", "Topic")
                        .WithMany("UserLists")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("ApplicationUser");

                    b.Navigation("Topic");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("iLearning.Listography.DataAccess.Models.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("iLearning.Listography.DataAccess.Models.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("iLearning.Listography.DataAccess.Models.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("iLearning.Listography.DataAccess.Models.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("iLearning.Listography.DataAccess.Models.Identity.ApplicationUser", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Likes");

                    b.Navigation("Lists");
                });

            modelBuilder.Entity("iLearning.Listography.DataAccess.Models.List.CustomField", b =>
                {
                    b.Navigation("SelectOptions");
                });

            modelBuilder.Entity("iLearning.Listography.DataAccess.Models.List.ListItem", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("CustomFields");

                    b.Navigation("Likes");

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("iLearning.Listography.DataAccess.Models.List.ListItemTemplate", b =>
                {
                    b.Navigation("CustomFields");
                });

            modelBuilder.Entity("iLearning.Listography.DataAccess.Models.List.ListTopic", b =>
                {
                    b.Navigation("UserLists");
                });

            modelBuilder.Entity("iLearning.Listography.DataAccess.Models.List.UserList", b =>
                {
                    b.Navigation("ItemTemplate");

                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
