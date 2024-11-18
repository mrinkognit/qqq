﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project.DataBase;

#nullable disable

namespace Project.Migrations
{
    [DbContext(typeof(StudentDbCotext))]
    partial class StudentDbCotextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("DisciplineGroup", b =>
                {
                    b.Property<int>("DisciplinesDisciplineId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GroupsGroupId")
                        .HasColumnType("INTEGER");

                    b.HasKey("DisciplinesDisciplineId", "GroupsGroupId");

                    b.HasIndex("GroupsGroupId");

                    b.ToTable("DisciplineGroup");
                });

            modelBuilder.Entity("Project.Models.Discipline", b =>
                {
                    b.Property<int>("DisciplineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("discipline_id")
                        .HasComment("Идентификатор записи дисциплины");

                    b.Property<string>("DisciplineName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("discipline_name")
                        .HasComment("Название дисциплины");

                    b.HasKey("DisciplineId")
                        .HasName("pk_cd_discipline_discipline_id");

                    b.ToTable("cd_discipline", (string)null);
                });

            modelBuilder.Entity("Project.Models.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("group_id")
                        .HasComment("Идентификатор записи группы");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_group_name")
                        .HasComment("Название группы");

                    b.HasKey("GroupId")
                        .HasName("pk_cd_group_group_id");

                    b.ToTable("cd_group", (string)null);
                });

            modelBuilder.Entity("Project.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("student_id")
                        .HasComment("Идентификатор записи студента");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_student_firstname")
                        .HasComment("Имя студента");

                    b.Property<int>("GroupId")
                        .HasColumnType("int4")
                        .HasColumnName("f_group_id")
                        .HasComment("Идентификатор группы");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bool")
                        .HasColumnName("b_deleted")
                        .HasComment("Статус удаления");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_student_lastname")
                        .HasComment("Фамилия студента");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_student_middlename")
                        .HasComment("Отчество студента");

                    b.HasKey("StudentId")
                        .HasName("pk_cd_student_student_id");

                    b.HasIndex(new[] { "GroupId" }, "idx_cd_student_fk_f_group_id");

                    b.ToTable("cd_student", (string)null);
                });

            modelBuilder.Entity("DisciplineGroup", b =>
                {
                    b.HasOne("Project.Models.Discipline", null)
                        .WithMany()
                        .HasForeignKey("DisciplinesDisciplineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project.Models.Group", null)
                        .WithMany()
                        .HasForeignKey("GroupsGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Project.Models.Student", b =>
                {
                    b.HasOne("Project.Models.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_f_group_id");

                    b.Navigation("Group");
                });
#pragma warning restore 612, 618
        }
    }
}
