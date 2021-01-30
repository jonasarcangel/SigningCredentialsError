﻿// <auto-generated />
using System;
using MyProject.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MyProject.Data.Migrations.SqlServer
{
    [DbContext(typeof(SqlServerDbContext))]
    [Migration("20210122220430_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("MyProject.Core.Entities.Configuration.Setting", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CreatedDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("MyProject.Core.Entities.Content.Activity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Action")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CreatedDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GroupId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsSystem")
                        .HasColumnType("bit");

                    b.Property<string>("LastUpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastUpdatedDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NodeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SiteId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenantId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("NodeId");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("MyProject.Core.Entities.Content.Message", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GroupId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LastUpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastUpdatedDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Module")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SiteId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenantId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("MyProject.Core.Entities.Content.Node", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ChildCount")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DescendantCount")
                        .HasColumnType("int");

                    b.Property<int>("DownVotes")
                        .HasColumnType("int");

                    b.Property<string>("GroupId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Hot")
                        .HasColumnType("float");

                    b.Property<string>("LastUpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastUpdatedDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Module")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SiteId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slug")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenantId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UpVotes")
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("ParentId");

                    b.HasIndex("Slug");

                    b.ToTable("Nodes");
                });

            modelBuilder.Entity("MyProject.Core.Entities.Content.NodeCustomFields", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CustomField1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomField10")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomField11")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomField12")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomField13")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomField14")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomField15")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomField16")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomField17")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomField18")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomField19")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomField2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomField20")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomField3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomField4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomField5")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomField6")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomField7")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomField8")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomField9")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IndexedCustomField1")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IndexedCustomField10")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IndexedCustomField11")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IndexedCustomField12")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IndexedCustomField13")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IndexedCustomField14")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IndexedCustomField15")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IndexedCustomField16")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IndexedCustomField17")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IndexedCustomField18")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IndexedCustomField19")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IndexedCustomField2")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IndexedCustomField20")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IndexedCustomField3")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IndexedCustomField4")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IndexedCustomField5")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IndexedCustomField6")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IndexedCustomField7")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IndexedCustomField8")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IndexedCustomField9")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NodeId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("IndexedCustomField1");

                    b.HasIndex("IndexedCustomField10");

                    b.HasIndex("IndexedCustomField11");

                    b.HasIndex("IndexedCustomField12");

                    b.HasIndex("IndexedCustomField13");

                    b.HasIndex("IndexedCustomField14");

                    b.HasIndex("IndexedCustomField15");

                    b.HasIndex("IndexedCustomField16");

                    b.HasIndex("IndexedCustomField17");

                    b.HasIndex("IndexedCustomField18");

                    b.HasIndex("IndexedCustomField19");

                    b.HasIndex("IndexedCustomField2");

                    b.HasIndex("IndexedCustomField20");

                    b.HasIndex("IndexedCustomField3");

                    b.HasIndex("IndexedCustomField4");

                    b.HasIndex("IndexedCustomField5");

                    b.HasIndex("IndexedCustomField6");

                    b.HasIndex("IndexedCustomField7");

                    b.HasIndex("IndexedCustomField8");

                    b.HasIndex("IndexedCustomField9");

                    b.HasIndex("NodeId")
                        .IsUnique()
                        .HasFilter("[NodeId] IS NOT NULL");

                    b.ToTable("NodeCustomFields");
                });

            modelBuilder.Entity("MyProject.Core.Entities.Content.NodeLink", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FromNodeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ToNodeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FromNodeId");

                    b.HasIndex("ToNodeId");

                    b.ToTable("NodeLinks");
                });

            modelBuilder.Entity("MyProject.Core.Entities.Content.NodeReaction", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NodeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ReactionType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("NodeId");

                    b.HasIndex("NodeId", "UserId");

                    b.ToTable("Reactions");
                });

            modelBuilder.Entity("MyProject.Core.Entities.Content.NodeTag", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NodeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Tag")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("NodeId");

                    b.HasIndex("Tag");

                    b.ToTable("NodeTags");
                });

            modelBuilder.Entity("MyProject.Core.Entities.Content.NodeVersion", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NodeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NodeId");

                    b.ToTable("NodeVersions");
                });

            modelBuilder.Entity("MyProject.Core.Entities.Content.NodeVote", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NodeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<short>("Score")
                        .HasColumnType("smallint");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("NodeId");

                    b.HasIndex("NodeId", "UserId");

                    b.ToTable("NodeVotes");
                });

            modelBuilder.Entity("MyProject.Core.Entities.Organization.Badge", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastUpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastUpdatedDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SiteId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenantId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Badges");
                });

            modelBuilder.Entity("MyProject.Core.Entities.Organization.Email", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DateSent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FromEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FromName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResponseBody")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResponseHeaders")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResponseStatusCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("To")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Emails");
                });

            modelBuilder.Entity("MyProject.Core.Entities.Organization.Group", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsOpen")
                        .HasColumnType("bit");

                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastUpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastUpdatedDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MemberCount")
                        .HasColumnType("int");

                    b.Property<string>("Module")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SiteId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slug")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenantId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("MyProject.Core.Entities.Organization.GroupMember", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GroupId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LastUpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastUpdatedDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SiteId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenantId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("GroupId", "UserId");

                    b.ToTable("GroupMembers");
                });

            modelBuilder.Entity("MyProject.Core.Entities.Organization.Invitation", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("InvitationCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastUpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastUpdatedDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SiteId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenantId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Email");

                    b.ToTable("Invitations");
                });

            modelBuilder.Entity("MyProject.Core.Entities.Organization.Site", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenantId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.ToTable("Site");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.DeviceFlowCodes", b =>
                {
                    b.Property<string>("UserCode")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasMaxLength(50000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("DeviceCode")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("Expiration")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("SessionId")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SubjectId")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("UserCode");

                    b.HasIndex("DeviceCode")
                        .IsUnique();

                    b.HasIndex("Expiration");

                    b.ToTable("DeviceCodes");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.PersistedGrant", b =>
                {
                    b.Property<string>("Key")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("ConsumedTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasMaxLength(50000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("Expiration")
                        .HasColumnType("datetime2");

                    b.Property<string>("SessionId")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SubjectId")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Key");

                    b.HasIndex("Expiration");

                    b.HasIndex("SubjectId", "ClientId", "Type");

                    b.HasIndex("SubjectId", "SessionId", "Type");

                    b.ToTable("PersistedGrants");
                });

            modelBuilder.Entity("MyProject.Core.Entities.Content.NodeCustomFields", b =>
                {
                    b.HasOne("MyProject.Core.Entities.Content.Node", null)
                        .WithOne("CustomFields")
                        .HasForeignKey("MyProject.Core.Entities.Content.NodeCustomFields", "NodeId");
                });

            modelBuilder.Entity("MyProject.Core.Entities.Content.NodeReaction", b =>
                {
                    b.HasOne("MyProject.Core.Entities.Content.Node", null)
                        .WithMany("Reactions")
                        .HasForeignKey("NodeId");
                });

            modelBuilder.Entity("MyProject.Core.Entities.Content.NodeTag", b =>
                {
                    b.HasOne("MyProject.Core.Entities.Content.Node", null)
                        .WithMany("Tags")
                        .HasForeignKey("NodeId");
                });

            modelBuilder.Entity("MyProject.Core.Entities.Content.NodeVersion", b =>
                {
                    b.HasOne("MyProject.Core.Entities.Content.Node", null)
                        .WithMany("Versions")
                        .HasForeignKey("NodeId");
                });

            modelBuilder.Entity("MyProject.Core.Entities.Content.NodeVote", b =>
                {
                    b.HasOne("MyProject.Core.Entities.Content.Node", null)
                        .WithMany("Votes")
                        .HasForeignKey("NodeId");
                });

            modelBuilder.Entity("MyProject.Core.Entities.Content.Node", b =>
                {
                    b.Navigation("CustomFields");

                    b.Navigation("Reactions");

                    b.Navigation("Tags");

                    b.Navigation("Versions");

                    b.Navigation("Votes");
                });
#pragma warning restore 612, 618
        }
    }
}
