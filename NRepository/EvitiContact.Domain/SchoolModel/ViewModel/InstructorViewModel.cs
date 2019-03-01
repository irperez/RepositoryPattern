using System;
using System.Collections.Generic;
using AutoMapper;
using FluentValidation;
using eviti.Data.Tracking.BaseObjects;
using eviti.data.tracking.Interfaces;
using EvitiContact.SchoolModel;

namespace EvitiContact.Domain.ContactModelDB
{
    public partial class InstructorViewModel
     {
    /// <summary>
    /// Initializes a new instance of the <see cref="InstructorViewModel"/> class.
    /// Based on <see cref="Instructor"/> class.
    /// </summary>
    public InstructorViewModel()
     {
     }
    #region Generated  ViewModel
    public int ID { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public DateTime HireDate { get; set; }
    #endregion
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
