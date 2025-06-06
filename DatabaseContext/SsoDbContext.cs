using Microsoft.EntityFrameworkCore;
using Models;

namespace DatabaseContext
{
    public partial class SsoDbContext:DbContext
    {
        //public SsoDbContext(DbContextOptions options) : base(options){}
        public SsoDbContext(DbContextOptions<SsoDbContext> options)
        : base(options)
        {
        }

        public virtual DbSet<AppPortifolio> AppPortifolios { get; set; }
        public virtual DbSet<BillModel> BillModels { get; set; }
        public virtual DbSet<CityModel> CityModels { get; set; }
        public virtual DbSet<CountryModel> CountryModels { get; set; }
        public virtual DbSet<EnrollmentModel> EnrollmentModels { get; set; }
        public virtual DbSet<OrganizationModel> OrganizationModels { get; set; }
        public virtual DbSet<RoleModel> RoleModels { get; set; }
        public virtual DbSet<SignatureModel> SignatureModels { get; set; }
        public virtual DbSet<StateModel> StateModels { get; set; }
        public virtual DbSet<UserLogin> UserLogins { get; set; }
        public virtual DbSet<UserModel> UserModels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Server=DESKTOP-TAFAH9C;Database=AlphaSSODb;Trusted_Connection=True;TrustServerCertificate=true;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppPortifolio>(entity =>
            {
                entity.HasKey(e => e.AppId).HasName("PK__AppPorti__8E2CF7F9661FC2B9");

                entity.ToTable("AppPortifolio");

                entity.Property(e => e.ApplicationName).HasMaxLength(150);
            });

            modelBuilder.Entity<BillModel>(entity =>
            {
                entity.HasKey(e => e.BillId).HasName("PK__BillMode__11F2FC6A3A430D14");

                entity.ToTable("BillModel");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(3)
                    .HasComment("Tipo do meio de pagamento...");
                entity.Property(e => e.UrlApi)
                    .HasMaxLength(255)
                    .HasColumnName("UrlAPI");
            });

            modelBuilder.Entity<CityModel>(entity =>
            {
                entity.HasKey(e => e.CityId).HasName("PK__CityMode__F2D21B76EF796D0B");

                entity.ToTable("CityModel");

                entity.Property(e => e.Ibge)
                    .HasMaxLength(7)
                    .HasColumnName("IBGE");
                entity.Property(e => e.Name).HasMaxLength(50);
                entity.Property(e => e.StateModelStateId).HasColumnName("StateModel_StateId");

                entity.HasOne(d => d.StateModelState).WithMany(p => p.CityModels)
                    .HasForeignKey(d => d.StateModelStateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CityModel__State__4AB81AF0");
            });

            modelBuilder.Entity<CountryModel>(entity =>
            {
                entity.HasKey(e => e.CountryId).HasName("PK__CountryM__10D1609F98E06333");

                entity.ToTable("CountryModel");

                entity.Property(e => e.Codigo).HasMaxLength(3);
                entity.Property(e => e.Fone).HasMaxLength(4);
                entity.Property(e => e.Iso)
                    .HasMaxLength(2)
                    .HasColumnName("ISO");
                entity.Property(e => e.Iso3)
                    .HasMaxLength(3)
                    .HasColumnName("ISO3");
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.NomeFormal).HasMaxLength(150);
            });

            modelBuilder.Entity<EnrollmentModel>(entity =>
            {
                entity.HasKey(e => new { e.EnrollmentId, e.UserModelUserId }).HasName("PK__Enrollme__37202B96D10BCCAE");

                entity.ToTable("EnrollmentModel");

                entity.Property(e => e.EnrollmentId).ValueGeneratedOnAdd();
                entity.Property(e => e.UserModelUserId).HasColumnName("UserModel_UserId");
                entity.Property(e => e.AppPortifolioAppId).HasColumnName("AppPortifolio_AppId");
                entity.Property(e => e.SignatureModelSignatureId).HasColumnName("SignatureModel_SignatureId");

                entity.HasOne(d => d.AppPortifolioApp).WithMany(p => p.EnrollmentModels)
                    .HasForeignKey(d => d.AppPortifolioAppId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Enrollmen__AppPo__4BAC3F29");

                entity.HasOne(d => d.SignatureModelSignature).WithMany(p => p.EnrollmentModels)
                    .HasForeignKey(d => d.SignatureModelSignatureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Enrollmen__Signa__4CA06362");

                entity.HasOne(d => d.UserModelUser).WithMany(p => p.EnrollmentModels)
                    .HasForeignKey(d => d.UserModelUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Enrollmen__UserM__4D94879B");
            });

            modelBuilder.Entity<OrganizationModel>(entity =>
            {
                entity.HasKey(e => new { e.OrganizationId, e.Cnpj }).HasName("PK__Organiza__807E7679005F241C");

                entity.ToTable("OrganizationModel");

                entity.Property(e => e.OrganizationId).ValueGeneratedOnAdd();
                entity.Property(e => e.Cnpj)
                    .HasMaxLength(15)
                    .HasColumnName("CNPJ");
                entity.Property(e => e.Address).HasMaxLength(250);
                entity.Property(e => e.CityModelCityId).HasColumnName("CityModel_CityId");
                entity.Property(e => e.CreditCardNumber).HasMaxLength(16);
                entity.Property(e => e.Cv)
                    .HasMaxLength(3)
                    .HasColumnName("CV");
                entity.Property(e => e.District).HasMaxLength(150);
                entity.Property(e => e.EmailContact).HasMaxLength(255);
                entity.Property(e => e.NumberAddr).HasMaxLength(6);
                entity.Property(e => e.Razao).HasMaxLength(250);
                entity.Property(e => e.ZipCode).HasMaxLength(8);

                entity.HasOne(d => d.CityModelCity).WithMany(p => p.OrganizationModels)
                    .HasForeignKey(d => d.CityModelCityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Organizat__CityM__4E88ABD4");
            });

            modelBuilder.Entity<RoleModel>(entity =>
            {
                entity.HasKey(e => e.RoleId).HasName("PK__RoleMode__8AFACE1A7677E852");

                entity.ToTable("RoleModel");

                entity.Property(e => e.RoleName).HasMaxLength(100);
            });

            modelBuilder.Entity<SignatureModel>(entity =>
            {
                entity.HasKey(e => e.SignatureId).HasName("PK__Signatur__3DCA57A9E0E50FD6");

                entity.ToTable("SignatureModel");

                entity.Property(e => e.BillModelBillId).HasColumnName("BillModel_BillId");
                entity.Property(e => e.KeySignature).HasMaxLength(128);
                entity.Property(e => e.OrganizationModelCnpj)
                    .HasMaxLength(15)
                    .HasColumnName("OrganizationModel_CNPJ");
                entity.Property(e => e.OrganizationModelOrganizationId).HasColumnName("OrganizationModel_OrganizationId");

                entity.HasOne(d => d.BillModelBill).WithMany(p => p.SignatureModels)
                    .HasForeignKey(d => d.BillModelBillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Signature__BillM__4F7CD00D");

                entity.HasOne(d => d.OrganizationModel).WithMany(p => p.SignatureModels)
                    .HasForeignKey(d => new { d.OrganizationModelOrganizationId, d.OrganizationModelCnpj })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SignatureModel__5070F446");
            });

            modelBuilder.Entity<StateModel>(entity =>
            {
                entity.HasKey(e => e.StateId).HasName("PK__StateMod__C3BA3B3ADDB287E7");

                entity.ToTable("StateModel");

                entity.Property(e => e.CountryModelCountryId).HasColumnName("CountryModel_CountryId");
                entity.Property(e => e.Ddd)
                    .HasMaxLength(3)
                    .HasColumnName("DDD");
                entity.Property(e => e.Ibgecode)
                    .HasMaxLength(7)
                    .HasColumnName("IBGECode");
                entity.Property(e => e.Name).HasMaxLength(50);
                entity.Property(e => e.Uf)
                    .HasMaxLength(2)
                    .HasColumnName("UF");

                entity.HasOne(d => d.CountryModelCountry).WithMany(p => p.StateModels)
                    .HasForeignKey(d => d.CountryModelCountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StateMode__Count__5165187F");
            });

            modelBuilder.Entity<UserLogin>(entity =>
            {
                entity.HasKey(e => e.UserLoginId).HasName("PK__UserLogi__107D568C5EEFC7AD");

                entity.ToTable("UserLogin");

                entity.Property(e => e.CreateLogin).HasColumnType("datetime");
                entity.Property(e => e.Log)
                    .HasMaxLength(255)
                    .HasColumnName("LOG");
                entity.Property(e => e.LogTime).HasColumnType("datetime");
                entity.Property(e => e.UserModelUserId).HasColumnName("UserModel_UserId");

                entity.HasOne(d => d.UserModelUser).WithMany(p => p.UserLogins)
                    .HasForeignKey(d => d.UserModelUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserLogin__UserM__52593CB8");
            });

            modelBuilder.Entity<UserModel>(entity =>
            {
                entity.HasKey(e => e.UserId).HasName("PK__UserMode__1788CC4C16F1E003");

                entity.ToTable("UserModel");

                entity.Property(e => e.EmailAddress).HasMaxLength(150);
                entity.Property(e => e.GivenName).HasMaxLength(150);
                entity.Property(e => e.Password).HasMaxLength(250);
                entity.Property(e => e.Role).HasMaxLength(100);
                entity.Property(e => e.RoleModelRoleId).HasColumnName("RoleModel_RoleId");
                entity.Property(e => e.Surname).HasMaxLength(150);
                entity.Property(e => e.UserName).HasMaxLength(150);

                entity.HasOne(d => d.RoleModelRole).WithMany(p => p.UserModels)
                    .HasForeignKey(d => d.RoleModelRoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserModel__RoleM__534D60F1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}