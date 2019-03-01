using eviti.data.tracking.PrincipalAccessor;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
namespace EvitiContact.SchoolModel
{
    public partial class SchoolModelDbContext : eviti.data.tracking.DataContactBase.EvitiDBContactBase
    {
        partial void InitializePartial();
        partial void OnConfiguringPartial(DbContextOptionsBuilder optionsBuilder);
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        public SchoolModelDbContext()
        {
            InitializePartial();
        }

        private ILogger<SchoolModelDbContext> _logger { get; set; }
        public SchoolModelDbContext(DbContextOptions<SchoolModelDbContext> options, ILogger<SchoolModelDbContext> logger,
            IPrincipalAccessor principalAccessor,
             IMediator _mediator)
            : base(options, principalAccessor, _mediator)
        {
            #region Generated Constructor
            _logger = logger;
            #endregion
            InitializePartial();
        }

        #region Generated Properties
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<CourseAssignment> CourseAssignment { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Enrollment> Enrollment { get; set; }
        public virtual DbSet<Instructor> Instructor { get; set; }
        public virtual DbSet<OfficeAssignment> OfficeAssignment { get; set; }
        public virtual DbSet<Student> Student { get; set; }
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

            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new CourseAssignmentConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new EnrollmentConfiguration());
            modelBuilder.ApplyConfiguration(new InstructorConfiguration());
            modelBuilder.ApplyConfiguration(new OfficeAssignmentConfiguration());
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            #endregion

            OnModelCreatingPartial(modelBuilder);

        }
        /*

        public partial class Course : IPKEntity
         {
          partial void InitializePartial()
        {
         }
        [NotMapped]
        public Guid Id  {  get  {  return this.Guid;   }   set  { this.Guid = value;  } }
        }

        public partial class CourseAssignment : IPKEntity
         {
          partial void InitializePartial()
        {
         }
        [NotMapped]
        public Guid Id  {  get  {  return this.Guid;   }   set  { this.Guid = value;  } }
        }

        public partial class Department : IPKEntity
         {
          partial void InitializePartial()
        {
         }
        [NotMapped]
        public Guid Id  {  get  {  return this.Guid;   }   set  { this.Guid = value;  } }
        }

        public partial class Enrollment : IPKEntity
         {
          partial void InitializePartial()
        {
         }
        [NotMapped]
        public Guid Id  {  get  {  return this.Guid;   }   set  { this.Guid = value;  } }
        }

        public partial class Instructor : IPKEntity
         {
          partial void InitializePartial()
        {
         }
        [NotMapped]
        public Guid Id  {  get  {  return this.Guid;   }   set  { this.Guid = value;  } }
        }

        public partial class OfficeAssignment : IPKEntity
         {
          partial void InitializePartial()
        {
         }
        [NotMapped]
        public Guid Id  {  get  {  return this.Guid;   }   set  { this.Guid = value;  } }
        }

        public partial class Student : IPKEntity
         {
          partial void InitializePartial()
        {
         }
        [NotMapped]
        public Guid Id  {  get  {  return this.Guid;   }   set  { this.Guid = value;  } }
        }
        */
    }
}
