using Microsoft.EntityFrameworkCore;

namespace ProjetoIntegrador4B.Models
{
    public partial class projetointegrador3bContext : DbContext
    {
        public projetointegrador3bContext()
        {
        }

        public projetointegrador3bContext(DbContextOptions<projetointegrador3bContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Groupvaccination> Groupvaccination { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Persongroup> Persongroup { get; set; }
        public virtual DbSet<Useradm> Useradm { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Server=localhost; Port=5432; Password=postgres; User Id=postgres; Database=projetointegrador3b; pooling = true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Groupvaccination>(entity =>
            {
                entity.ToTable("groupvaccination");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(255);

                entity.Property(e => e.Liberationdate)
                    .HasColumnName("liberationdate")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("person");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.Telegram)
                    .HasColumnName("telegram")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Useradm>(entity =>
            {
                entity.ToTable("useradm");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(255);

                entity.Property(e => e.Token)
                    .HasColumnName("token")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Persongroup>(entity =>
            {
                entity.ToTable("persongroup");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Idgroup).HasColumnName("idgroup");

                entity.Property(e => e.Idperson).HasColumnName("idperson");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
