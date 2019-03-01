using System;
using System.Collections.Generic;
using AutoMapper;
using FluentValidation;
using eviti.Data.Tracking.BaseObjects;
using eviti.data.tracking.Interfaces;
using EvitiContact.SchoolModel;

namespace EvitiContact.Domain.ContactModelDB
{
    public partial class InstructorValidator : AbstractValidator<Instructor>
     {
    /// <summary>
    /// Initializes a new instance of the <see cref="InstructorValidator"/> class.
    /// </summary>
    public InstructorValidator()
     {
    #region Generated Entity Validation
    RuleFor(p => p.LastName).NotEmpty();
    RuleFor(p => p.LastName).MaximumLength(50);
    RuleFor(p => p.FirstName).NotEmpty();
    RuleFor(p => p.FirstName).MaximumLength(50);
    #endregion
     }
     }
    /*
    #region Generated Reference Class
    public partial class Instructor
    {
        public Instructor()
        {
            CourseAssignments = new HashSet<CourseAssignment>();
            Departments = new HashSet<Department>();
        }

        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime HireDate { get; set; }

        public OfficeAssignment OfficeAssignment { get; set; }
        public ICollection<CourseAssignment> CourseAssignments { get; set; }
        public ICollection<Department> Departments { get; set; }
    }
    #endregion
    */
}
