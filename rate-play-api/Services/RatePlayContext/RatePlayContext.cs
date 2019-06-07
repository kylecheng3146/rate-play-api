using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace rate_play_api.Services.RatePlayContext
{
    public partial class RatePlayContext : DbContext
    {
        public RatePlayContext()
        {
        }

        public RatePlayContext(DbContextOptions<RatePlayContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Activity> Activity { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Exrate> Exrate { get; set; }
        public virtual DbSet<Member> Member { get; set; }
        public virtual DbSet<TravelInfo> TravelInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;database=RatePlay");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Activity>(entity =>
            {
                entity.ToTable("ACTIVITY", "RatePlay");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ActCity)
                    .IsRequired()
                    .HasColumnName("act_city")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ActId)
                    .IsRequired()
                    .HasColumnName("act_id")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ActLink)
                    .IsRequired()
                    .HasColumnName("act_link")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ActMonth)
                    .IsRequired()
                    .HasColumnName("act_month")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ActName)
                    .IsRequired()
                    .HasColumnName("act_name")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ActSou)
                    .IsRequired()
                    .HasColumnName("act_sou")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ActSouper)
                    .IsRequired()
                    .HasColumnName("act_souper")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<Countries>(entity =>
            {
                entity.ToTable("countries", "RatePlay");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasColumnName("country_code")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasColumnName("country_name")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CurrencyName)
                    .IsRequired()
                    .HasColumnName("currency_name")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<Exrate>(entity =>
            {
                entity.ToTable("EXRATE", "RatePlay");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Exrate1)
                    .IsRequired()
                    .HasColumnName("exrate")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.RateName)
                    .IsRequired()
                    .HasColumnName("rate_name")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Utc)
                    .IsRequired()
                    .HasColumnName("UTC")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.ToTable("MEMBER", "RatePlay");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.MemSex)
                    .IsRequired()
                    .HasColumnName("mem_sex")
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasColumnName("token")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<TravelInfo>(entity =>
            {
                entity.ToTable("TRAVEL_INFO", "RatePlay");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ActId)
                    .IsRequired()
                    .HasColumnName("act_id")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CityNo)
                    .IsRequired()
                    .HasColumnName("city_no")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Climate)
                    .IsRequired()
                    .HasColumnName("climate")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CouId)
                    .IsRequired()
                    .HasColumnName("cou_id")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CurId)
                    .IsRequired()
                    .HasColumnName("cur_id")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Wear)
                    .IsRequired()
                    .HasColumnName("wear")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Weather)
                    .IsRequired()
                    .HasColumnName("weather")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");
            });
        }
    }
}
