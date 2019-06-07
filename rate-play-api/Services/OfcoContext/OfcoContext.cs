using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace rate_play_api.Services.OfcoContext
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
        public virtual DbSet<MachineMaterialLine> MachineMaterialLine { get; set; }
        public virtual DbSet<MachineMold> MachineMold { get; set; }
        public virtual DbSet<MachineOtherDevice> MachineOtherDevice { get; set; }
        public virtual DbSet<MachineType> MachineType { get; set; }
        public virtual DbSet<MachineWorkOrder> MachineWorkOrder { get; set; }
        public virtual DbSet<MachineWorkOrderKeg> MachineWorkOrderKeg { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UsersAgents> UsersAgents { get; set; }
        public virtual DbSet<UsersForms> UsersForms { get; set; }
        public virtual DbSet<UsersMachine> UsersMachine { get; set; }
        public virtual DbSet<UsersRoles> UsersRoles { get; set; }
        public virtual DbSet<固定倉庫存卡> 固定倉庫存卡 { get; set; }
        public virtual DbSet<工令作業> 工令作業 { get; set; }
        public virtual DbSet<模具櫃大模具> 模具櫃大模具 { get; set; }
        public virtual DbSet<模具櫃大模具國際標準> 模具櫃大模具國際標準 { get; set; }
        public virtual DbSet<模具櫃大模具模具組合明細> 模具櫃大模具模具組合明細 { get; set; }
        public virtual DbSet<模具櫃小模具> 模具櫃小模具 { get; set; }
        public virtual DbSet<模具櫃總成模具> 模具櫃總成模具 { get; set; }
        public virtual DbSet<模具櫃總成模具小模明細> 模具櫃總成模具小模明細 { get; set; }
        public virtual DbSet<模具櫃耗材> 模具櫃耗材 { get; set; }
        public virtual DbSet<模具耗材庫存卡> 模具耗材庫存卡 { get; set; }
        public virtual DbSet<模具耗材庫存序號管理表> 模具耗材庫存序號管理表 { get; set; }
        public virtual DbSet<線材櫃> 線材櫃 { get; set; }

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
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

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
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

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

            modelBuilder.Entity<MachineMaterialLine>(entity =>
            {
                entity.HasKey(e => e.No);

                entity.ToTable("machine_material_line");

                entity.Property(e => e.No).HasColumnName("no");

                entity.Property(e => e.CheckFlag)
                    .HasColumnName("check_flag")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.MahId)
                    .HasColumnName("mah_Id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Material)
                    .HasColumnName("material")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MaterialId)
                    .HasColumnName("material_Id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MaterialName)
                    .HasColumnName("material_name")
                    .HasMaxLength(50);

                entity.Property(e => e.MaterialUniqe)
                    .HasColumnName("material_uniqe")
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
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

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

            modelBuilder.Entity<MachineMold>(entity =>
            {
                entity.HasKey(e => e.No);

                entity.ToTable("machine_mold");

                entity.Property(e => e.No)
                    .HasColumnName("no")
                    .ValueGeneratedNever();

                entity.Property(e => e.CheckFlag)
                    .HasColumnName("check_flag")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.MahId)
                    .HasColumnName("mah_Id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Mold)
                    .HasColumnName("mold")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MoldId)
                    .HasColumnName("mold_Id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MoldName)
                    .HasColumnName("mold_name")
                    .HasMaxLength(50);

                entity.Property(e => e.MoldUniqe)
                    .HasColumnName("mold_uniqe")
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
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

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
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

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

                entity.Property(e => e.CheckFlag)
                    .HasColumnName("check_flag")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");

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
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

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

                entity.Property(e => e.WorkOrder)
                    .HasColumnName("work_order")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MachineWorkOrderKeg>(entity =>
            {
                entity.HasKey(e => e.No)
                    .HasName("PK_workOrder_keg");

                entity.ToTable("machine_workOrder_keg");

                entity.Property(e => e.No).HasColumnName("no");

                entity.Property(e => e.CheckFlag)
                    .HasColumnName("check_flag")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");

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
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

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

                entity.Property(e => e.WorkKegCount).HasColumnName("work_keg_count");

                entity.Property(e => e.WorkKegUniqueCode)
                    .HasColumnName("work_keg_unique_code")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WorkKegWeight)
                    .HasColumnName("work_keg_weight")
                    .HasColumnType("numeric(5, 2)");

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

                entity.Property(e => e.AuthToken)
                    .HasColumnName("auth_token")
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
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

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
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

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

            modelBuilder.Entity<固定倉庫存卡>(entity =>
            {
                entity.HasKey(e => e.編號);

                entity.Property(e => e.Dawnflag)
                    .HasColumnName("dawnflag")
                    .HasMaxLength(50);

                entity.Property(e => e.Ng入庫)
                    .IsRequired()
                    .HasColumnName("NG入庫")
                    .HasMaxLength(2)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.作廢時間).HasColumnType("datetime");

                entity.Property(e => e.作廢檢核)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'N')");

                entity.Property(e => e.來源功能表).HasMaxLength(50);

                entity.Property(e => e.來源單號)
                    .HasMaxLength(300)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.來源單號作廢)
                    .HasColumnName("來源單號_作廢")
                    .HasMaxLength(50);

                entity.Property(e => e.倉別)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.倉別1002).HasMaxLength(50);

                entity.Property(e => e.倉名)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.倉名1002).HasMaxLength(50);

                entity.Property(e => e.備註).HasMaxLength(300);

                entity.Property(e => e.備註2).HasMaxLength(100);

                entity.Property(e => e.儲位)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.入庫單價)
                    .HasColumnType("numeric(18, 5)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.入庫時間).HasMaxLength(50);

                entity.Property(e => e.功能表名稱作廢)
                    .HasColumnName("功能表名稱_作廢")
                    .HasMaxLength(50);

                entity.Property(e => e.加權成本)
                    .HasColumnType("numeric(18, 6)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.包裝編號)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.原舊有機台倉).HasMaxLength(50);

                entity.Property(e => e.品號)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.品號0525)
                    .HasColumnName("品號_0525")
                    .HasMaxLength(50);

                entity.Property(e => e.品號舊)
                    .HasColumnName("品號_舊")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.單位).HasMaxLength(50);

                entity.Property(e => e.單位重量)
                    .HasColumnType("numeric(18, 5)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.增量數量)
                    .HasColumnType("numeric(18, 5)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.增量重量)
                    .HasColumnType("numeric(18, 5)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.客供料).HasMaxLength(50);

                entity.Property(e => e.客戶名稱).HasMaxLength(500);

                entity.Property(e => e.實際單支重)
                    .HasColumnType("numeric(18, 5)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.屬性).HasMaxLength(50);

                entity.Property(e => e.工令單號).HasMaxLength(50);

                entity.Property(e => e.所屬客戶)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.批號)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.投料加權)
                    .HasColumnType("numeric(18, 6)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.投料料號)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.投料量)
                    .HasColumnType("numeric(18, 5)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.投料類別)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.新系統批號)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.時間).HasMaxLength(50);

                entity.Property(e => e.時間1).HasMaxLength(50);

                entity.Property(e => e.時間Old)
                    .HasColumnName("時間_old")
                    .HasColumnType("datetime");

                entity.Property(e => e.期初加權成本)
                    .HasColumnType("numeric(18, 6)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.桶).HasMaxLength(50);

                entity.Property(e => e.標準成本)
                    .HasColumnType("numeric(18, 5)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.機台儲位).HasMaxLength(50);

                entity.Property(e => e.減量數量)
                    .HasColumnType("numeric(18, 5)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.減量重量)
                    .HasColumnType("numeric(18, 5)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.爐號)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.盤元料號).HasMaxLength(50);

                entity.Property(e => e.移倉成本)
                    .HasColumnType("numeric(18, 6)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.製造商).HasMaxLength(50);

                entity.Property(e => e.製造商代號).HasMaxLength(10);

                entity.Property(e => e.訂單號碼).HasMaxLength(50);

                entity.Property(e => e.購買單價)
                    .HasColumnType("numeric(18, 5)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.購買幣別)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'NTD')");

                entity.Property(e => e.轉台幣匯率)
                    .HasColumnType("numeric(18, 5)")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.轉台幣單價)
                    .HasColumnType("numeric(18, 5)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.金額)
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.項次).HasMaxLength(50);

                entity.Property(e => e.類別).HasMaxLength(50);
            });

            modelBuilder.Entity<工令作業>(entity =>
            {
                entity.HasKey(e => e.單據編號);

                entity.HasIndex(e => e.單據編號)
                    .HasName("UQ__工令作業__3E9DF37C")
                    .IsUnique();

                entity.Property(e => e.單據編號)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.Lot)
                    .HasColumnName("LOT")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.作廢)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("(N'N')");

                entity.Property(e => e.作廢原因).HasMaxLength(300);

                entity.Property(e => e.使用庫存量).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.使用庫存量白皮)
                    .HasColumnName("使用庫存量_白皮")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.使用庫存量電鍍)
                    .HasColumnName("使用庫存量_電鍍")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.來源單號作廢)
                    .HasColumnName("來源單號_作廢")
                    .HasMaxLength(50);

                entity.Property(e => e.備註).HasMaxLength(500);

                entity.Property(e => e.功能表名稱作廢)
                    .HasColumnName("功能表名稱_作廢")
                    .HasMaxLength(50);

                entity.Property(e => e.原料重量).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.原料重量Old)
                    .HasColumnName("原料重量_old")
                    .HasColumnType("numeric(18, 5)");

                entity.Property(e => e.原料重量有調整)
                    .HasColumnName("原料重量_有調整")
                    .HasMaxLength(50);

                entity.Property(e => e.品名).HasMaxLength(500);

                entity.Property(e => e.品號).HasMaxLength(50);

                entity.Property(e => e.品號0525)
                    .HasColumnName("品號_0525")
                    .HasMaxLength(50);

                entity.Property(e => e.品號異動說明).HasMaxLength(300);

                entity.Property(e => e.單據日期).HasMaxLength(50);

                entity.Property(e => e.委外商).HasMaxLength(50);

                entity.Property(e => e.實際總金額).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.工令圖號).HasMaxLength(50);

                entity.Property(e => e.工令產生時間).HasMaxLength(50);

                entity.Property(e => e.工單計劃加權).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.應派工數量).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.打頭).HasMaxLength(1);

                entity.Property(e => e.排工日期).HasMaxLength(50);

                entity.Property(e => e.最先製程).HasMaxLength(50);

                entity.Property(e => e.月份).HasMaxLength(50);

                entity.Property(e => e.月份old).HasMaxLength(50);

                entity.Property(e => e.標準重量).HasColumnType("numeric(18, 5)");

                entity.Property(e => e.標準重量Old)
                    .HasColumnName("標準重量_old")
                    .HasColumnType("numeric(18, 5)");

                entity.Property(e => e.模具編號).HasMaxLength(50);

                entity.Property(e => e.模具說明).HasMaxLength(500);

                entity.Property(e => e.機台).HasMaxLength(50);

                entity.Property(e => e.機台0810)
                    .HasColumnName("機台_0810")
                    .HasMaxLength(50);

                entity.Property(e => e.機型).HasMaxLength(50);

                entity.Property(e => e.機型0810)
                    .HasColumnName("機型_0810")
                    .HasMaxLength(50);

                entity.Property(e => e.派工單號).HasMaxLength(50);

                entity.Property(e => e.派工屬性).HasMaxLength(50);

                entity.Property(e => e.派工數量).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.派工數量0809)
                    .HasColumnName("派工數量_0809")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.派工特殊要求).HasMaxLength(100);

                entity.Property(e => e.派工異動檢核).HasMaxLength(50);

                entity.Property(e => e.派工異動說明).HasMaxLength(500);

                entity.Property(e => e.派工週期).HasMaxLength(50);

                entity.Property(e => e.熱處理).HasMaxLength(1);

                entity.Property(e => e.生產備品數量).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.生產通知數量).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.用料).HasMaxLength(50);

                entity.Property(e => e.異動前品號).HasMaxLength(50);

                entity.Property(e => e.發料).HasMaxLength(50);

                entity.Property(e => e.管製卡號).HasMaxLength(50);

                entity.Property(e => e.線材品名).HasMaxLength(50);

                entity.Property(e => e.線材品名0905).HasMaxLength(50);

                entity.Property(e => e.線材品號).HasMaxLength(50);

                entity.Property(e => e.線材品號0905).HasMaxLength(50);

                entity.Property(e => e.線材重量).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.線材重量Old)
                    .HasColumnName("線材重量_old")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.舊系統工單).HasMaxLength(50);

                entity.Property(e => e.舊系統工單異動說明).HasMaxLength(300);

                entity.Property(e => e.補單).HasMaxLength(50);

                entity.Property(e => e.製作對象).HasMaxLength(50);

                entity.Property(e => e.規劃預排序號).HasMaxLength(50);

                entity.Property(e => e.訂單總需求量).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.計劃總成本).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.輾牙).HasMaxLength(1);

                entity.Property(e => e.門檻)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'N')");

                entity.Property(e => e.關聯工單).HasMaxLength(50);

                entity.Property(e => e.電鍍).HasMaxLength(1);
            });

            modelBuilder.Entity<模具櫃大模具>(entity =>
            {
                entity.HasKey(e => e.模具編號)
                    .HasName("PK_模具櫃_大模具_資料");

                entity.ToTable("模具櫃_大模具");

                entity.Property(e => e.模具編號)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.代碼國際規範)
                    .HasColumnName("代碼_國際規範")
                    .HasMaxLength(4);

                entity.Property(e => e.代碼機型)
                    .HasColumnName("代碼_機型")
                    .HasMaxLength(3);

                entity.Property(e => e.代碼牙長)
                    .HasColumnName("代碼_牙長")
                    .HasMaxLength(2);

                entity.Property(e => e.代碼規格)
                    .HasColumnName("代碼_規格")
                    .HasMaxLength(3);

                entity.Property(e => e.代碼長度)
                    .HasColumnName("代碼_長度")
                    .HasMaxLength(4);

                entity.Property(e => e.代碼長度舊)
                    .HasColumnName("代碼_長度_舊")
                    .HasMaxLength(4);

                entity.Property(e => e.來源功能表名稱建檔)
                    .HasColumnName("來源功能表名稱_建檔")
                    .HasMaxLength(50);

                entity.Property(e => e.來源功能表名稱異動)
                    .HasColumnName("來源功能表名稱_異動")
                    .HasMaxLength(50);

                entity.Property(e => e.來源單號建檔)
                    .HasColumnName("來源單號_建檔")
                    .HasMaxLength(50);

                entity.Property(e => e.來源單號異動)
                    .HasColumnName("來源單號_異動")
                    .HasMaxLength(50);

                entity.Property(e => e.停用檢核).HasMaxLength(50);

                entity.Property(e => e.備註).HasMaxLength(255);

                entity.Property(e => e.定義國際規範)
                    .HasColumnName("定義_國際規範")
                    .HasMaxLength(300);

                entity.Property(e => e.定義機型)
                    .HasColumnName("定義_機型")
                    .HasMaxLength(300);

                entity.Property(e => e.定義牙長)
                    .HasColumnName("定義_牙長")
                    .HasMaxLength(300);

                entity.Property(e => e.定義規格)
                    .HasColumnName("定義_規格")
                    .HasMaxLength(300);

                entity.Property(e => e.定義長度)
                    .HasColumnName("定義_長度")
                    .HasMaxLength(300);

                entity.Property(e => e.建檔時間).HasMaxLength(50);

                entity.Property(e => e.模具名稱).HasMaxLength(200);

                entity.Property(e => e.模具編號舊)
                    .HasColumnName("模具編號_舊")
                    .HasMaxLength(50);

                entity.Property(e => e.版本碼).HasMaxLength(50);

                entity.Property(e => e.版次碼).HasMaxLength(50);

                entity.Property(e => e.異動時間).HasMaxLength(50);
            });

            modelBuilder.Entity<模具櫃大模具國際標準>(entity =>
            {
                entity.HasKey(e => new { e.模具編號, e.國際標準代碼, e.牙別碼 })
                    .HasName("PK_模具櫃_大模具_國際標準_資料");

                entity.ToTable("模具櫃_大模具_國際標準");

                entity.Property(e => e.模具編號).HasMaxLength(50);

                entity.Property(e => e.國際標準代碼).HasMaxLength(50);

                entity.Property(e => e.牙別碼).HasMaxLength(50);

                entity.Property(e => e.中文定義).HasMaxLength(500);

                entity.Property(e => e.來源功能表名稱建檔)
                    .HasColumnName("來源功能表名稱_建檔")
                    .HasMaxLength(50);

                entity.Property(e => e.來源功能表名稱異動)
                    .HasColumnName("來源功能表名稱_異動")
                    .HasMaxLength(50);

                entity.Property(e => e.來源單號建檔)
                    .HasColumnName("來源單號_建檔")
                    .HasMaxLength(255);

                entity.Property(e => e.來源單號異動)
                    .HasColumnName("來源單號_異動")
                    .HasMaxLength(50);

                entity.Property(e => e.停用檢核).HasMaxLength(50);

                entity.Property(e => e.國際標準).HasMaxLength(50);

                entity.Property(e => e.建檔時間).HasMaxLength(50);

                entity.Property(e => e.牙別定義).HasMaxLength(500);

                entity.Property(e => e.異動時間).HasMaxLength(50);

                entity.Property(e => e.規範).HasMaxLength(50);

                entity.Property(e => e.鍍別定義).HasMaxLength(255);

                entity.Property(e => e.鍍別碼).HasMaxLength(50);
            });

            modelBuilder.Entity<模具櫃大模具模具組合明細>(entity =>
            {
                entity.HasKey(e => new { e.模具編號, e.模具編號總成 })
                    .HasName("PK_模具櫃_大模具_模具組合明細_資料");

                entity.ToTable("模具櫃_大模具_模具組合明細");

                entity.Property(e => e.模具編號).HasMaxLength(50);

                entity.Property(e => e.模具編號總成)
                    .HasColumnName("模具編號_總成")
                    .HasMaxLength(50);

                entity.Property(e => e.來源功能表名稱建檔)
                    .HasColumnName("來源功能表名稱_建檔")
                    .HasMaxLength(50);

                entity.Property(e => e.來源功能表名稱異動)
                    .HasColumnName("來源功能表名稱_異動")
                    .HasMaxLength(50);

                entity.Property(e => e.來源單號建檔)
                    .HasColumnName("來源單號_建檔")
                    .HasMaxLength(50);

                entity.Property(e => e.來源單號異動)
                    .HasColumnName("來源單號_異動")
                    .HasMaxLength(50);

                entity.Property(e => e.停用檢核).HasMaxLength(50);

                entity.Property(e => e.備註).HasMaxLength(50);

                entity.Property(e => e.建檔時間).HasMaxLength(50);

                entity.Property(e => e.數量).HasMaxLength(50);

                entity.Property(e => e.模具名稱總成)
                    .HasColumnName("模具名稱_總成")
                    .HasMaxLength(50);

                entity.Property(e => e.模具編號舊)
                    .HasColumnName("模具編號_舊")
                    .HasMaxLength(50);

                entity.Property(e => e.異動時間).HasMaxLength(50);

                entity.Property(e => e.種類).HasMaxLength(50);
            });

            modelBuilder.Entity<模具櫃小模具>(entity =>
            {
                entity.HasKey(e => e.模具編號);

                entity.ToTable("模具櫃_小模具");

                entity.Property(e => e.模具編號)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.代碼模具長度)
                    .HasColumnName("代碼_模具長度")
                    .HasMaxLength(50);

                entity.Property(e => e.代碼模具長度舊)
                    .HasColumnName("代碼_模具長度_舊")
                    .HasMaxLength(50);

                entity.Property(e => e.代碼流水碼)
                    .HasColumnName("代碼_流水碼")
                    .HasMaxLength(50);

                entity.Property(e => e.代碼規格)
                    .HasColumnName("代碼_規格")
                    .HasMaxLength(50);

                entity.Property(e => e.來源功能表名稱建檔)
                    .HasColumnName("來源功能表名稱_建檔")
                    .HasMaxLength(50);

                entity.Property(e => e.來源功能表名稱異動)
                    .HasColumnName("來源功能表名稱_異動")
                    .HasMaxLength(50);

                entity.Property(e => e.來源單號建檔)
                    .HasColumnName("來源單號_建檔")
                    .HasMaxLength(50);

                entity.Property(e => e.來源單號異動)
                    .HasColumnName("來源單號_異動")
                    .HasMaxLength(50);

                entity.Property(e => e.停用檢核).HasMaxLength(50);

                entity.Property(e => e.備註).HasMaxLength(255);

                entity.Property(e => e.定義模具長度)
                    .HasColumnName("定義_模具長度")
                    .HasMaxLength(50);

                entity.Property(e => e.定義規格)
                    .HasColumnName("定義_規格")
                    .HasMaxLength(50);

                entity.Property(e => e.建檔時間).HasMaxLength(50);

                entity.Property(e => e.標準壽命生產數量)
                    .HasColumnName("標準壽命_生產數量")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.模具名稱).HasMaxLength(255);

                entity.Property(e => e.模具編號舊)
                    .HasColumnName("模具編號_舊")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<模具櫃總成模具>(entity =>
            {
                entity.HasKey(e => e.模具編號)
                    .HasName("PK_模具櫃_總成模具_資料");

                entity.ToTable("模具櫃_總成模具");

                entity.Property(e => e.模具編號)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.代碼國際規範)
                    .HasColumnName("代碼_國際規範")
                    .HasMaxLength(50);

                entity.Property(e => e.代碼機型)
                    .HasColumnName("代碼_機型")
                    .HasMaxLength(50);

                entity.Property(e => e.代碼牙別)
                    .HasColumnName("代碼_牙別")
                    .HasMaxLength(50);

                entity.Property(e => e.代碼種類)
                    .HasColumnName("代碼_種類")
                    .HasMaxLength(50);

                entity.Property(e => e.代碼規格)
                    .HasColumnName("代碼_規格")
                    .HasMaxLength(50);

                entity.Property(e => e.來源功能表名稱建檔)
                    .HasColumnName("來源功能表名稱_建檔")
                    .HasMaxLength(50);

                entity.Property(e => e.來源功能表名稱異動)
                    .HasColumnName("來源功能表名稱_異動")
                    .HasMaxLength(50);

                entity.Property(e => e.來源單號建檔)
                    .HasColumnName("來源單號_建檔")
                    .HasMaxLength(50);

                entity.Property(e => e.來源單號異動)
                    .HasColumnName("來源單號_異動")
                    .HasMaxLength(50);

                entity.Property(e => e.停用檢核)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'N')");

                entity.Property(e => e.備註).HasMaxLength(500);

                entity.Property(e => e.定義國際規範)
                    .HasColumnName("定義_國際規範")
                    .HasMaxLength(50);

                entity.Property(e => e.定義機型)
                    .HasColumnName("定義_機型")
                    .HasMaxLength(50);

                entity.Property(e => e.定義牙別)
                    .HasColumnName("定義_牙別")
                    .HasMaxLength(50);

                entity.Property(e => e.定義種類)
                    .HasColumnName("定義_種類")
                    .HasMaxLength(50);

                entity.Property(e => e.定義規格)
                    .HasColumnName("定義_規格")
                    .HasMaxLength(50);

                entity.Property(e => e.建檔時間).HasMaxLength(50);

                entity.Property(e => e.模具名稱).HasMaxLength(200);

                entity.Property(e => e.無接模明細檢核)
                    .HasMaxLength(5)
                    .HasDefaultValueSql("(N'N')");

                entity.Property(e => e.無耗材需求明細檢核)
                    .HasMaxLength(5)
                    .HasDefaultValueSql("(N'N')");

                entity.Property(e => e.版次碼).HasMaxLength(50);

                entity.Property(e => e.異動時間).HasMaxLength(50);
            });

            modelBuilder.Entity<模具櫃總成模具小模明細>(entity =>
            {
                entity.HasKey(e => new { e.模具編號, e.接模順序, e.小模編號, e.停用檢核 })
                    .HasName("PK_模具櫃_總成模具_小模明細_資料");

                entity.ToTable("模具櫃_總成模具_小模明細");

                entity.Property(e => e.模具編號).HasMaxLength(50);

                entity.Property(e => e.接模順序).HasMaxLength(50);

                entity.Property(e => e.小模編號).HasMaxLength(50);

                entity.Property(e => e.停用檢核)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'N')");

                entity.Property(e => e.來源功能表名稱建檔)
                    .HasColumnName("來源功能表名稱_建檔")
                    .HasMaxLength(50);

                entity.Property(e => e.來源功能表名稱異動)
                    .HasColumnName("來源功能表名稱_異動")
                    .HasMaxLength(50);

                entity.Property(e => e.來源單號建檔)
                    .HasColumnName("來源單號_建檔")
                    .HasMaxLength(50);

                entity.Property(e => e.來源單號異動)
                    .HasColumnName("來源單號_異動")
                    .HasMaxLength(50);

                entity.Property(e => e.備註).HasMaxLength(300);

                entity.Property(e => e.小模名稱).HasMaxLength(300);

                entity.Property(e => e.建檔時間).HasMaxLength(50);

                entity.Property(e => e.異動時間).HasMaxLength(50);
            });

            modelBuilder.Entity<模具櫃耗材>(entity =>
            {
                entity.HasKey(e => e.模具編號)
                    .HasName("PK_模具櫃_耗材_資料");

                entity.ToTable("模具櫃_耗材");

                entity.Property(e => e.模具編號)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.代碼機型)
                    .HasColumnName("代碼_機型")
                    .HasMaxLength(3);

                entity.Property(e => e.代碼流水碼)
                    .HasColumnName("代碼_流水碼")
                    .HasMaxLength(50);

                entity.Property(e => e.代碼牙別)
                    .HasColumnName("代碼_牙別")
                    .HasMaxLength(3);

                entity.Property(e => e.代碼種類)
                    .HasColumnName("代碼_種類")
                    .HasMaxLength(50);

                entity.Property(e => e.代碼線材線徑)
                    .HasColumnName("代碼_線材線徑")
                    .HasMaxLength(5);

                entity.Property(e => e.代碼螺絲長度)
                    .HasColumnName("代碼_螺絲長度")
                    .HasMaxLength(4);

                entity.Property(e => e.代碼規格)
                    .HasColumnName("代碼_規格")
                    .HasMaxLength(50);

                entity.Property(e => e.來源功能表名稱建檔)
                    .HasColumnName("來源功能表名稱_建檔")
                    .HasMaxLength(50);

                entity.Property(e => e.來源功能表名稱異動)
                    .HasColumnName("來源功能表名稱_異動")
                    .HasMaxLength(200);

                entity.Property(e => e.來源單號建檔)
                    .HasColumnName("來源單號_建檔")
                    .HasMaxLength(50);

                entity.Property(e => e.來源單號異動)
                    .HasColumnName("來源單號_異動")
                    .HasMaxLength(200);

                entity.Property(e => e.停用檢核).HasMaxLength(50);

                entity.Property(e => e.備註).HasMaxLength(255);

                entity.Property(e => e.安全存量).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.定義機型)
                    .HasColumnName("定義_機型")
                    .HasMaxLength(255);

                entity.Property(e => e.定義牙別)
                    .HasColumnName("定義_牙別")
                    .HasMaxLength(255);

                entity.Property(e => e.定義種類)
                    .HasColumnName("定義_種類")
                    .HasMaxLength(50);

                entity.Property(e => e.定義線材線徑)
                    .HasColumnName("定義_線材線徑")
                    .HasMaxLength(255);

                entity.Property(e => e.定義螺絲長度)
                    .HasColumnName("定義_螺絲長度")
                    .HasMaxLength(300);

                entity.Property(e => e.定義規格)
                    .HasColumnName("定義_規格")
                    .HasMaxLength(50);

                entity.Property(e => e.建檔時間).HasMaxLength(50);

                entity.Property(e => e.標準壽命生產數量)
                    .HasColumnName("標準壽命_生產數量")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.模具名稱).HasMaxLength(255);

                entity.Property(e => e.異動原因).HasMaxLength(255);

                entity.Property(e => e.異動時間).HasMaxLength(200);

                entity.Property(e => e.頭部記號).HasMaxLength(50);

                entity.Property(e => e.頭部記號碼).HasMaxLength(50);
            });

            modelBuilder.Entity<模具耗材庫存卡>(entity =>
            {
                entity.HasKey(e => e.流水號);

                entity.Property(e => e.來源功能表).HasMaxLength(50);

                entity.Property(e => e.來源單號).HasMaxLength(50);

                entity.Property(e => e.入庫單價).HasColumnType("numeric(18, 5)");

                entity.Property(e => e.入庫採購單).HasMaxLength(50);

                entity.Property(e => e.入庫日期).HasMaxLength(50);

                entity.Property(e => e.入庫請購單).HasMaxLength(50);

                entity.Property(e => e.入庫請購需求日).HasMaxLength(50);

                entity.Property(e => e.加權成本).HasColumnType("numeric(18, 5)");

                entity.Property(e => e.品號).HasMaxLength(255);

                entity.Property(e => e.增量數量).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.屬性).HasMaxLength(50);

                entity.Property(e => e.時間).HasMaxLength(50);

                entity.Property(e => e.減量數量).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.移倉成本).HasColumnType("numeric(18, 5)");

                entity.Property(e => e.購買單價).HasMaxLength(255);

                entity.Property(e => e.購買幣別).HasMaxLength(10);

                entity.Property(e => e.轉台幣匯率).HasColumnType("numeric(18, 5)");

                entity.Property(e => e.轉台幣單價).HasColumnType("numeric(18, 5)");

                entity.Property(e => e.類別)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<模具耗材庫存序號管理表>(entity =>
            {
                entity.HasKey(e => new { e.類別, e.品號, e.序號 });

                entity.Property(e => e.類別).HasMaxLength(15);

                entity.Property(e => e.品號).HasMaxLength(50);

                entity.Property(e => e.序號).HasMaxLength(50);

                entity.Property(e => e.供應商代號).HasMaxLength(50);

                entity.Property(e => e.供應商名稱).HasMaxLength(50);

                entity.Property(e => e.備註).HasMaxLength(100);

                entity.Property(e => e.功能表名稱來源)
                    .HasColumnName("功能表名稱_來源")
                    .HasMaxLength(50);

                entity.Property(e => e.功能表名稱取消報廢)
                    .HasColumnName("功能表名稱_取消報廢")
                    .HasMaxLength(200);

                entity.Property(e => e.功能表名稱報廢)
                    .HasColumnName("功能表名稱_報廢")
                    .HasMaxLength(50);

                entity.Property(e => e.功能表名稱領用)
                    .HasColumnName("功能表名稱_領用")
                    .HasMaxLength(50);

                entity.Property(e => e.取消報廢日期).HasMaxLength(50);

                entity.Property(e => e.取消報廢說明).HasMaxLength(200);

                entity.Property(e => e.單據編號來源)
                    .HasColumnName("單據編號_來源")
                    .HasMaxLength(50);

                entity.Property(e => e.單據編號取消報廢)
                    .HasColumnName("單據編號_取消報廢")
                    .HasMaxLength(200);

                entity.Property(e => e.單據編號報廢)
                    .HasColumnName("單據編號_報廢")
                    .HasMaxLength(50);

                entity.Property(e => e.單據編號領用)
                    .HasColumnName("單據編號_領用")
                    .HasMaxLength(50);

                entity.Property(e => e.報廢地點).HasMaxLength(10);

                entity.Property(e => e.報廢屬性).HasMaxLength(50);

                entity.Property(e => e.報廢日期).HasMaxLength(50);

                entity.Property(e => e.報廢檢核).HasMaxLength(10);

                entity.Property(e => e.報廢說明).HasMaxLength(300);

                entity.Property(e => e.存放位置).HasMaxLength(50);

                entity.Property(e => e.時間).HasMaxLength(50);

                entity.Property(e => e.購買日期).HasMaxLength(50);

                entity.Property(e => e.領用屬性).HasMaxLength(10);

                entity.Property(e => e.領用日期).HasMaxLength(50);

                entity.Property(e => e.領用機台).HasMaxLength(50);

                entity.Property(e => e.領用機種).HasMaxLength(50);

                entity.Property(e => e.領用檢核).HasMaxLength(10);
            });

            modelBuilder.Entity<線材櫃>(entity =>
            {
                entity.HasKey(e => e.品號);

                entity.Property(e => e.品號)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.修改單號).HasMaxLength(50);

                entity.Property(e => e.加工狀態碼).HasMaxLength(50);

                entity.Property(e => e.品名).HasMaxLength(100);

                entity.Property(e => e.單位).HasMaxLength(50);

                entity.Property(e => e.建檔人).HasMaxLength(50);

                entity.Property(e => e.建檔單號).HasMaxLength(50);

                entity.Property(e => e.建檔日期).HasMaxLength(50);

                entity.Property(e => e.建檔部門).HasMaxLength(50);

                entity.Property(e => e.技術抽線率).HasColumnType("numeric(18, 5)");

                entity.Property(e => e.材質碼).HasMaxLength(100);

                entity.Property(e => e.標準重量).HasColumnType("numeric(18, 5)");

                entity.Property(e => e.異動日期).HasMaxLength(50);

                entity.Property(e => e.線材線徑碼).HasMaxLength(50);

                entity.Property(e => e.製造商碼).HasMaxLength(50);
            });
        }
    }
}
