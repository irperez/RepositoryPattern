using System;
using System.Collections.Generic;
using AutoMapper;
using FluentValidation;
using eviti.Data.Tracking.BaseObjects;
using eviti.data.tracking.Interfaces;
using EvitiContact.SchoolModel;

namespace EvitiContact.Domain.ContactModelDB
{
    public partial class DepartmentViewModelValidator : AbstractValidator<DepartmentViewModel>
     {
    /// <summary>
    /// Initializes a new instance of the <see cref="DepartmentViewModelValidator"/> class.
    /// </summary>
    public DepartmentViewModelValidator()
     {
    #region Generated Validation For ViewModel
    RuleFor(p => p.Name).MaximumLength(50);
    #endregion
     }
     }
    /*
    #region Generated Reference Class
    public partial class Department
    {
        public Department()
        {
            Courses = new HashSet<Course>();
        }

        public int DepartmentID { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public DateTime StartDate { get; set; }
        public int? InstructorID { get; set; }

        public Instructor Instructor { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
    #endregion
    */
}
