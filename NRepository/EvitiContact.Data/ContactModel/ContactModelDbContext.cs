using System.Threading;
using System.Threading.Tasks;
using eviti.data.tracking.DataContactBase;
using eviti.data.tracking.DIHelp;
using eviti.data.tracking.PrincipalAccessor;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EvitiContact.ContactModel
{
    /// <summary>
    /// This is a test 2
    /// </summary>
    public partial class ContactModelDbContext : EvitiDBContactBase
    {
        private void InitializePartial()
        {
            //DbContext.Configuration.ProxyCreationEnabled
            //base.Configuration.ProxyCreationEnabled = false;

            //this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        private void OnConfiguringPartial(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder .UseLoggerFactory(LoggersForDev.ChangeTrackingAndSqlConsoleLoggerFactory).EnableSensitiveDataLogging();

            //optionsBuilder .UseLoggerFactory(LoggersForDev.EverythingConsoleLoggerFactory).EnableSensitiveDataLogging();
            // optionsBuilder .UseLoggerFactory(LoggersForDev.BobLoggers).EnableSensitiveDataLogging();

            // var temp2 = ServiceLocator.GetService<ILoggerFactory>();
            // optionsBuilder .UseLoggerFactory(temp2).EnableSensitiveDataLogging();

            if (_logger == null)
            {
                _logger = ServiceLocator.GetService<ILogger<ContactModelDbContext>>();
            }
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        public ContactModelDbContext()
        {
            InitializePartial();
        }

        private ILogger<ContactModelDbContext> _logger { get; set; }



        public ContactModelDbContext(DbContextOptions<ContactModelDbContext> options,
            ILogger<ContactModelDbContext> logger,
            IPrincipalAccessor principalAccessor, IMediator _mediator)
            : base(options, principalAccessor, _mediator)
        {
            #region Generated Constructor
            _logger = logger;
            #endregion
            InitializePartial();
        }

        #region Generated Properties
        public virtual DbSet<AuditLog> AuditLog { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<ContactAddress> ContactAddress { get; set; }
        public virtual DbSet<ContactEmail> ContactEmail { get; set; }
        public virtual DbSet<ContactExternalIDs> ContactExternalIDs { get; set; }
        public virtual DbSet<ContactPayer> ContactPayer { get; set; }
        public virtual DbSet<ContactPhone> ContactPhone { get; set; }
        public virtual DbSet<ContactType> ContactType { get; set; }
        public virtual DbSet<ContactUser> ContactUser { get; set; }
        public virtual DbSet<MDDetail> MDDetail { get; set; }
        public virtual DbSet<MDMaster> MDMaster { get; set; }
        public virtual DbSet<States> States { get; set; }
        public virtual DbSet<ZipCodes> ZipCodes { get; set; }
        #endregion

        #region Generated GenerateEntityTypeErrors
        #endregion
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=evitiContactModel;Trusted_Connection=True;");
                OnConfiguringPartial(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Generated Configuration

            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            // do i need this??base.OnModelCreating(modelBuilder);
            // Or this from https://github.com/JasonGT/NorthwindTraders ??modelBuilder.ApplyAllConfigurations();

            modelBuilder.ApplyConfiguration(new AuditLogConfiguration());
            modelBuilder.ApplyConfiguration(new ContactConfiguration());
            modelBuilder.ApplyConfiguration(new ContactAddressConfiguration());
            modelBuilder.ApplyConfiguration(new ContactEmailConfiguration());
            modelBuilder.ApplyConfiguration(new ContactExternalIDsConfiguration());
            modelBuilder.ApplyConfiguration(new ContactPayerConfiguration());
            modelBuilder.ApplyConfiguration(new ContactPhoneConfiguration());
            modelBuilder.ApplyConfiguration(new ContactTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ContactUserConfiguration());
            modelBuilder.ApplyConfiguration(new MDDetailConfiguration());
            modelBuilder.ApplyConfiguration(new MDMasterConfiguration());
            modelBuilder.ApplyConfiguration(new StatesConfiguration());
            modelBuilder.ApplyConfiguration(new ZipCodesConfiguration());
            #endregion

            OnModelCreatingPartial(modelBuilder);

        }



        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {

            var result = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
            return result;

        }



        public override int SaveChanges()
        {
            int result = base.SaveChanges();
            return result;

        }
        /*

        public partial class Contact : IPKEntity
         {
          partial void InitializePartial()
        {
         }
        [NotMapped]
        public Guid Id  {  get  {  return this.Guid;   }   set  { this.Guid = value;  } }
        }

        public partial class ContactAddress : IPKEntity
         {
          partial void InitializePartial()
        {
         }
        [NotMapped]
        public Guid Id  {  get  {  return this.Guid;   }   set  { this.Guid = value;  } }
        }

        public partial class ContactEmail : IPKEntity
         {
          partial void InitializePartial()
        {
         }
        [NotMapped]
        public Guid Id  {  get  {  return this.Guid;   }   set  { this.Guid = value;  } }
        }

        public partial class ContactExternalIDs : IPKEntity
         {
          partial void InitializePartial()
        {
         }
        [NotMapped]
        public Guid Id  {  get  {  return this.Guid;   }   set  { this.Guid = value;  } }
        }

        public partial class ContactPayer : IPKEntity
         {
          partial void InitializePartial()
        {
         }
        [NotMapped]
        public Guid Id  {  get  {  return this.Guid;   }   set  { this.Guid = value;  } }
        }

        public partial class ContactPhone : IPKEntity
         {
          partial void InitializePartial()
        {
         }
        [NotMapped]
        public Guid Id  {  get  {  return this.Guid;   }   set  { this.Guid = value;  } }
        }

        public partial class ContactType : IPKEntity
         {
          partial void InitializePartial()
        {
         }
        [NotMapped]
        public Guid Id  {  get  {  return this.Guid;   }   set  { this.Guid = value;  } }
        }

        public partial class ContactUser : IPKEntity
         {
          partial void InitializePartial()
        {
         }
        [NotMapped]
        public Guid Id  {  get  {  return this.Guid;   }   set  { this.Guid = value;  } }
        }

        public partial class MDDetail : IPKEntity
         {
          partial void InitializePartial()
        {
         }
        [NotMapped]
        public Guid Id  {  get  {  return this.Guid;   }   set  { this.Guid = value;  } }
        }

        public partial class MDMaster : IPKEntity
         {
          partial void InitializePartial()
        {
         }
        [NotMapped]
        public Guid Id  {  get  {  return this.Guid;   }   set  { this.Guid = value;  } }
        }

        public partial class States : IPKEntity
         {
          partial void InitializePartial()
        {
         }
        [NotMapped]
        public Guid Id  {  get  {  return this.Guid;   }   set  { this.Guid = value;  } }
        }

        public partial class ZipCodes : IPKEntity
         {
          partial void InitializePartial()
        {
         }
        [NotMapped]
        public Guid Id  {  get  {  return this.Guid;   }   set  { this.Guid = value;  } }
        }
        */
    }


    //public partial class ContactModelDbContext
    //{
    //    //public ContactModelDbContext()
    //    //{
    //    //}

    //    //public ContactModelDbContext(DbContextOptions<ContactModelDbContext> options)
    //    //    : base(options)
    //    //{
    //    //}


    //    partial void InitializePartial()
    //    {
    //        //DbContext.Configuration.ProxyCreationEnabled
    //        //base.Configuration.ProxyCreationEnabled = false;

    //        //this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    //    }

    //    partial void OnConfiguringPartial(DbContextOptionsBuilder optionsBuilder)
    //    {

    //        //optionsBuilder .UseLoggerFactory(LoggersForDev.ChangeTrackingAndSqlConsoleLoggerFactory).EnableSensitiveDataLogging();

    //        //optionsBuilder .UseLoggerFactory(LoggersForDev.EverythingConsoleLoggerFactory).EnableSensitiveDataLogging();
    //        // optionsBuilder .UseLoggerFactory(LoggersForDev.BobLoggers).EnableSensitiveDataLogging();

    //        // var temp2 = ServiceLocator.GetService<ILoggerFactory>();
    //        // optionsBuilder .UseLoggerFactory(temp2).EnableSensitiveDataLogging();

    //        if (_logger == null)
    //        {
    //            _logger = ServiceLocator.GetService<ILogger<ContactModelDbContext>>();
    //        }

    //    }


    //    partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
    //    {
    //        string t = string.Empty;
    //    }


    //    public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
    //    {

    //        var result = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    //        return result;

    //    }



    //    public override int SaveChanges()
    //    {
    //        int result = base.SaveChanges();
    //        return result;

    //    }
    //}
}
