using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DbApplicationZ
{
    public partial class PracticeContext : DbContext
    {
        public PracticeContext()
        {
        }

        public PracticeContext(DbContextOptions<PracticeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Занятия> Занятияs { get; set; }
        public virtual DbSet<Преподаватели> Преподавателиs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=Practice;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Занятия>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Занятия");

                entity.Property(e => e.Группа).HasMaxLength(10);

                entity.Property(e => e.ДатаЗанятия)
                    .HasColumnType("date")
                    .HasColumnName("Дата занятия");

                entity.Property(e => e.Дисциплина).HasMaxLength(20);

                entity.Property(e => e.ЗанятияId).ValueGeneratedOnAdd();

                entity.Property(e => e.КолВоЧас).HasColumnName("Кол-во час.");

                entity.Property(e => e.ТабельныйНомер)
                    .HasMaxLength(10)
                    .HasColumnName("Табельный номер");

                entity.Property(e => e.ЧасоваяСтавка).HasColumnName("Часовая ставка");

                entity.HasOne(d => d.ТабельныйНомерNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.ТабельныйНомер)
                    .HasConstraintName("FK_Занятия_To_Преподаватели");
            });

            modelBuilder.Entity<Преподаватели>(entity =>
            {
                entity.HasKey(e => e.ТабельныйНомер)
                    .HasName("PK__Преподав__C327248FE3E817F7");

                entity.ToTable("Преподаватели");

                entity.Property(e => e.ТабельныйНомер)
                    .HasMaxLength(10)
                    .HasColumnName("Табельный номер");

                entity.Property(e => e.Должность).HasMaxLength(20);

                entity.Property(e => e.ФиоПреподавателя)
                    .HasMaxLength(50)
                    .HasColumnName("ФИО преподавателя");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
