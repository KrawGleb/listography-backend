﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using iLearning.Listography.DataAccess.Implementations;

#nullable disable

namespace iLearning.Listography.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("iLearning.Listography.DataAccess.Models.Identity.Account", b =>
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
                });

            modelBuilder.Entity("iLearning.Listography.DataAccess.Models.List.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AccountId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("ListItemId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

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

                    b.Property<int?>("IntValue")
                        .HasColumnType("int");

                    b.Property<int?>("ListItemId")
                        .HasColumnType("int");

                    b.Property<int?>("ListItemTemplateId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<string>("StringValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TextValue")
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<string>("AccountId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("ListItemId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

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
                        .HasColumnType("nvarchar(max)");

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
                        .HasColumnType("nvarchar(max)");

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
                        .HasColumnType("nvarchar(max)");

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
                        .HasColumnType("nvarchar(max)");

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

            modelBuilder.Entity("iLearning.Listography.DataAccess.Models.List.UserList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AccountId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TopicId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

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
                            Id = "40854765-4665-492c-99dc-45179d49f62b",
                            ConcurrencyStamp = "9b51074d-fbc1-47ca-9e23-9324eac0d985",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "0e144d97-2100-46d9-8cfb-218aaf99aa96",
                            ConcurrencyStamp = "46105541-8a79-4873-a935-b9de36dcbdde",
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
                    b.HasOne("iLearning.Listography.DataAccess.Models.Identity.Account", "Account")
                        .WithMany("Comments")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("iLearning.Listography.DataAccess.Models.List.ListItem", "ListItem")
                        .WithMany("Comments")
                        .HasForeignKey("ListItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Account");

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
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("ListItem");

                    b.Navigation("ListItemTemplate");
                });

            modelBuilder.Entity("iLearning.Listography.DataAccess.Models.List.Like", b =>
                {
                    b.HasOne("iLearning.Listography.DataAccess.Models.Identity.Account", "Account")
                        .WithMany("Likes")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("iLearning.Listography.DataAccess.Models.List.ListItem", "ListItem")
                        .WithMany("Likes")
                        .HasForeignKey("ListItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Account");

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
                        .OnDelete(DeleteBehavior.SetNull);

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

            modelBuilder.Entity("iLearning.Listography.DataAccess.Models.List.UserList", b =>
                {
                    b.HasOne("iLearning.Listography.DataAccess.Models.Identity.Account", "Account")
                        .WithMany("Lists")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("iLearning.Listography.DataAccess.Models.List.ListTopic", "Topic")
                        .WithMany("UserLists")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Account");

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
                    b.HasOne("iLearning.Listography.DataAccess.Models.Identity.Account", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("iLearning.Listography.DataAccess.Models.Identity.Account", null)
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

                    b.HasOne("iLearning.Listography.DataAccess.Models.Identity.Account", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("iLearning.Listography.DataAccess.Models.Identity.Account", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("iLearning.Listography.DataAccess.Models.Identity.Account", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Likes");

                    b.Navigation("Lists");
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
