using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ofco_projects_api.Services.OfcoContext
{
    public partial class OfcoContext : DbContext
    {
        public OfcoContext()
        {
        }

        public OfcoContext(DbContextOptions<OfcoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Forms> Forms { get; set; }
        public virtual DbSet<Machine> Machine { get; set; }
        public virtual DbSet<MachineDetail> MachineDetail { get; set; }
        public virtual DbSet<MachineMappingDevice> MachineMappingDevice { get; set; }
        public virtual DbSet<MachineOtherDevice> MachineOtherDevice { get; set; }
        public virtual DbSet<MachineType> MachineType { get; set; }
        public virtual DbSet<MachineWorkOrder> MachineWorkOrder { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UsersAgents> UsersAgents { get; set; }
        public virtual DbSet<UsersForms> UsersForms { get; set; }
        public virtual DbSet<UsersMachine> UsersMachine { get; set; }
        public virtual DbSet<UsersRoles> UsersRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=211.22.242.13;User Id=sa;Password=SapidA@9160;Database=ofco_40");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity<Forms>(entity =>
            {
                entity.HasKey(e => e.FormId);

                entity.ToTable("forms");

                entity.Property(e => e.FormId)
                    .HasColumnName("formId")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.FormName)
                    .HasColumnName("form_name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Machine>(entity =>
            {
                entity.HasKey(e => e.MahId)
                    .HasName("PK_machine2");

                entity.ToTable("machine");

                entity.HasIndex(e => e.UniqueCode)
                    .HasName("IX_machine")
                    .IsUnique();

                entity.Property(e => e.MahId)
                    .HasColumnName("mah_Id")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CheckFlag)
                    .HasColumnName("check_flag")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.CountSec).HasColumnName("count_sec");

                entity.Property(e => e.CountSecTime)
                    .HasColumnName("count_sec_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.CurCount).HasColumnName("cur_count");

                entity.Property(e => e.CurCountTime)
                    .HasColumnName("cur_count_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.MahModel)
                    .HasColumnName("mah_model")
                    .HasMaxLength(50);

                entity.Property(e => e.MahType)
                    .HasColumnName("mah_type")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MahTypeName)
                    .HasColumnName("mah_type_name")
                    .HasMaxLength(50);

                entity.Property(e => e.Memo)
                    .HasColumnName("memo")
                    .HasMaxLength(50);

                entity.Property(e => e.SetCount).HasColumnName("set_count");

                entity.Property(e => e.SetCountTime)
                    .HasColumnName("set_count_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.SetMan)
                    .HasColumnName("set_man")
                    .HasMaxLength(50);

                entity.Property(e => e.SetManId)
                    .HasColumnName("set_man_id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SetTime)
                    .HasColumnName("set_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.UniqueCode)
                    .HasColumnName("unique_code")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.UpdMan)
                    .HasColumnName("upd_man")
                    .HasMaxLength(50);

                entity.Property(e => e.UpdManId)
                    .HasColumnName("upd_man_id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdTime)
                    .HasColumnName("upd_time")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<MachineDetail>(entity =>
            {
                entity.HasKey(e => e.No);

                entity.ToTable("machine_detail");

                entity.Property(e => e.MahId)
                    .HasColumnName("mah_Id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MahName)
                    .HasColumnName("mah_name")
                    .HasMaxLength(50);

                entity.Property(e => e.MahType)
                    .HasColumnName("mah_type")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MahUniqe)
                    .HasColumnName("mah_uniqe")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Man)
                    .HasColumnName("man")
                    .HasMaxLength(50);

                entity.Property(e => e.ManId)
                    .HasColumnName("man_Id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrderId)
                    .HasColumnName("orderId")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(50);

                entity.Property(e => e.Time)
                    .HasColumnName("time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MachineMappingDevice>(entity =>
            {
                entity.HasKey(e => new { e.MahId, e.OMahId })
                    .HasName("PK_machine_mapping_fitting");

                entity.ToTable("machine_mapping_device");

                entity.Property(e => e.MahId)
                    .HasColumnName("mah_id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OMahId)
                    .HasColumnName("o_mah_Id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CheckFlag)
                    .HasColumnName("check_flag")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Memo)
                    .HasColumnName("memo")
                    .HasMaxLength(50);

                entity.Property(e => e.SetMan)
                    .HasColumnName("set_man")
                    .HasMaxLength(50);

                entity.Property(e => e.SetManId)
                    .HasColumnName("set_man_id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SetTime)
                    .HasColumnName("set_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdMan)
                    .HasColumnName("upd_man")
                    .HasMaxLength(50);

                entity.Property(e => e.UpdManId)
                    .HasColumnName("upd_man_id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdTime)
                    .HasColumnName("upd_time")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<MachineOtherDevice>(entity =>
            {
                entity.HasKey(e => e.OMahId)
                    .HasName("PK_other_device");

                entity.ToTable("machine_other_device");

                entity.Property(e => e.OMahId)
                    .HasColumnName("o_mah_Id")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CheckFlag)
                    .HasColumnName("check_flag")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.CurWeight)
                    .HasColumnName("cur_weight")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.CurWeightTime)
                    .HasColumnName("cur_weight_time")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Memo)
                    .HasColumnName("memo")
                    .HasMaxLength(50);

                entity.Property(e => e.OMahModel)
                    .HasColumnName("o_mah_model")
                    .HasMaxLength(50);

                entity.Property(e => e.OMahType)
                    .HasColumnName("o_mah_type")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OMahTypeName)
                    .HasColumnName("o_mah_type_name")
                    .HasMaxLength(50);

                entity.Property(e => e.SetMan)
                    .HasColumnName("set_man")
                    .HasMaxLength(50);

                entity.Property(e => e.SetManId)
                    .HasColumnName("set_man_id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SetTime)
                    .HasColumnName("set_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.UniqueCode)
                    .HasColumnName("unique_code")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdMan)
                    .HasColumnName("upd_man")
                    .HasMaxLength(50);

                entity.Property(e => e.UpdManId)
                    .HasColumnName("upd_man_id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdTime)
                    .HasColumnName("upd_time")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<MachineType>(entity =>
            {
                entity.HasKey(e => e.Type);

                entity.ToTable("machine_type");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<MachineWorkOrder>(entity =>
            {
                entity.HasKey(e => e.No);

                entity.ToTable("machine_workOrder");

                entity.Property(e => e.No).HasColumnName("no");

                entity.Property(e => e.MahId)
                    .HasColumnName("mah_Id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SetMan)
                    .HasColumnName("set_man")
                    .HasMaxLength(50);

                entity.Property(e => e.SetManId)
                    .HasColumnName("set_man_id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SetTime)
                    .HasColumnName("set_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.WorkOrder)
                    .HasColumnName("work_order")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK_role");

                entity.ToTable("roles");

                entity.Property(e => e.RoleId)
                    .HasColumnName("role_id")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Role)
                    .HasColumnName("role")
                    .HasMaxLength(50);

                entity.Property(e => e.RoleName)
                    .HasColumnName("role_name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK_user");

                entity.ToTable("users");

                entity.HasIndex(e => e.UniqueCode)
                    .HasName("IX_users")
                    .IsUnique();

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CheckFlag)
                    .HasColumnName("check_flag")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Memo)
                    .HasColumnName("memo")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Pwd)
                    .HasColumnName("pwd")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Salt)
                    .IsRequired()
                    .HasColumnName("salt")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SetMan)
                    .HasColumnName("set_man")
                    .HasMaxLength(50);

                entity.Property(e => e.SetManId)
                    .HasColumnName("set_man_id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SetTime)
                    .HasColumnName("set_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.UniqueCode)
                    .IsRequired()
                    .HasColumnName("unique_code")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.UpdMan)
                    .HasColumnName("upd_man")
                    .HasMaxLength(50);

                entity.Property(e => e.UpdManId)
                    .HasColumnName("upd_man_id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdTime)
                    .HasColumnName("upd_time")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<UsersAgents>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.AgentId });

                entity.ToTable("users_agents");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AgentId)
                    .HasColumnName("agentId")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CheckFlag)
                    .HasColumnName("check_flag")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.EndTime)
                    .HasColumnName("endTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Memo)
                    .HasColumnName("memo")
                    .HasMaxLength(50);

                entity.Property(e => e.SetMan)
                    .HasColumnName("set_man")
                    .HasMaxLength(50);

                entity.Property(e => e.SetManId)
                    .HasColumnName("set_man_id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SetTime)
                    .HasColumnName("set_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.StartTime)
                    .HasColumnName("startTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdMan)
                    .HasColumnName("upd_man")
                    .HasMaxLength(50);

                entity.Property(e => e.UpdManId)
                    .HasColumnName("upd_man_id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdTime)
                    .HasColumnName("upd_time")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<UsersForms>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.FormId });

                entity.ToTable("users_forms");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FormId)
                    .HasColumnName("formId")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UsersMachine>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.MahId });

                entity.ToTable("users_machine");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MahId)
                    .HasColumnName("mah_Id")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UsersRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PK_user_role");

                entity.ToTable("users_roles");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId)
                    .HasColumnName("role_Id")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
