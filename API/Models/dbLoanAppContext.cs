using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API.Models
{
    public partial class dbLoanAppContext : DbContext
    {
        public dbLoanAppContext()
        {
        }

        public dbLoanAppContext(DbContextOptions<dbLoanAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AddressMaster> AddressMasters { get; set; }
        public virtual DbSet<AppRole> AppRoles { get; set; }
        public virtual DbSet<AppUser> AppUsers { get; set; }
        public virtual DbSet<AppUserPrivateDetail> AppUserPrivateDetails { get; set; }
        public virtual DbSet<AppUserRole> AppUserRoles { get; set; }
        public virtual DbSet<ApplicationBranchAdmin> ApplicationBranchAdmins { get; set; }
        public virtual DbSet<ApplicationCustomer> ApplicationCustomers { get; set; }
        public virtual DbSet<ApplicationEmployee> ApplicationEmployees { get; set; }
        public virtual DbSet<CompanyBranchDetail> CompanyBranchDetails { get; set; }
        public virtual DbSet<CustomerLoanCard> CustomerLoanCards { get; set; }
        public virtual DbSet<CustomerLoanManager> CustomerLoanManagers { get; set; }
        public virtual DbSet<CustomerLoanManagerStage> CustomerLoanManagerStages { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeSalaryManager> EmployeeSalaryManagers { get; set; }
        public virtual DbSet<LoanStage> LoanStages { get; set; }

        public async Task<List<ApplicationCustomer>> GetCustomers(string userRole,int branchId)
        {
            SqlParameter pBranchId = new SqlParameter("@BranchId", branchId);
            SqlParameter pUserRole = new SqlParameter("@UserRole", userRole);
            try
            {
                return await this.ApplicationCustomers.FromSqlInterpolated($"EXECUTE GetCustomerList @BranchId={pBranchId}, @LoginUserRole={pUserRole}").ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<ApplicationEmployee>> GetEmployee(string userRole, int branchId)
        {
            SqlParameter pBranchId = new SqlParameter("@BranchId", branchId);
            SqlParameter pUserRole = new SqlParameter("@UserRole", userRole);
            try
            {
                return await this.ApplicationEmployees.FromSqlInterpolated($"EXECUTE GetEmployeeList @BranchId={pBranchId}, @LoginUserRole={pUserRole}").ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=103.235.105.151;Database=dbLoanApp;user id=SuperAdmin;password=^Sp23i2x2;Integrated Security=False;Trusted_Connection=False;");
                //optionsBuilder.UseSqlServer("Server=tcp:dotnetloancollectionserver.database.windows.net,1433;Initial Catalog=dbLoanApp;Persist Security Info=False;User ID=admin-sql;Password=^Sp23i2x2;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("SuperAdmin");

            modelBuilder.Entity<AddressMaster>(entity =>
            {
                entity.ToTable("AddressMaster");

                entity.Property(e => e.AddressFor)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLine1)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLine2)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AppRole>(entity =>
            {
                entity.ToTable("AppRole");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AppUser>(entity =>
            {
                entity.ToTable("AppUser");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LoanAppAccountNo)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.WhatsAppNo)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AppUserPrivateDetail>(entity =>
            {
                entity.Property(e => e.AadharCardImagePath)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.AadharCardNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BankAccountNo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BankName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CheckBooKimgPath)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("CheckBooKImgPath");

                entity.Property(e => e.Ifscode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IFSCode");

                entity.Property(e => e.PancardImagePath)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.PancardNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PassBookImgPath)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ProfileImgPath)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AppUserRole>(entity =>
            {
                entity.ToTable("AppUserRole");
            });

            modelBuilder.Entity<ApplicationBranchAdmin>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ApplicationBranchAdmin");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LoanAppAccountNo)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.WhatsAppNo)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ApplicationCustomer>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ApplicationCustomer");

                entity.Property(e => e.BranchName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LoanAppAccountNo)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.WhatsAppNo)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ApplicationEmployee>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ApplicationEmployee");

                entity.Property(e => e.BranchName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.WhatsAppNo)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CompanyBranchDetail>(entity =>
            {
                entity.Property(e => e.Certificate)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyBranchType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyLogo)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyRegisterDate).HasColumnType("datetime");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.SubTitle)
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CustomerLoanCard>(entity =>
            {
                entity.ToTable("CustomerLoanCard");

                entity.Property(e => e.AmountCollected).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.InstAmount)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Inst_Amount");

                entity.Property(e => e.Intrest).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.LoanAccNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OsPricipal)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("OS_pricipal");

                entity.Property(e => e.PaiderName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Principal).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.RepaymentDate).HasColumnType("date");
            });

            modelBuilder.Entity<CustomerLoanManager>(entity =>
            {
                entity.ToTable("CustomerLoanManager");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.DeletedDate).HasColumnType("date");

                entity.Property(e => e.LoanAccNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LoanApplyAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.LoanApplyAmountDate).HasColumnType("date");

                entity.Property(e => e.LoanDate).HasColumnType("date");

                entity.Property(e => e.LoanIntrest).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.NoOfDays)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NoOfMonths)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NoOfWeeks)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NoOfYears)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SectionAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SectionAmountDate).HasColumnType("date");

                entity.Property(e => e.UpdatedDate).HasColumnType("date");
            });

            modelBuilder.Entity<CustomerLoanManagerStage>(entity =>
            {
                entity.ToTable("CustomerLoanManagerStage");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeSalary)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeTitle)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EmployeeSalaryManager>(entity =>
            {
                entity.ToTable("EmployeeSalaryManager");

                entity.Property(e => e.NoOfDays)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PresentDays)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Salary)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SalaryDate).HasColumnType("datetime");

                entity.Property(e => e.SalaryStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LoanStage>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
