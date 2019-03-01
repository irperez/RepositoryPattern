using System;
using System.Collections.Generic;
using AutoMapper;
using FluentValidation;
using eviti.Data.Tracking.BaseObjects;
using eviti.data.tracking.Interfaces;
using EvitiContact.SchoolModel;

namespace EvitiContact.Domain.ContactModelDB
{
    public partial class DepartmentProfile : Profile
    {
    /// <summary>
    /// Initializes a new instance of the <see cref="DepartmentProfile"/> class.
    /// Based on <see cref="Department"/> class.
    /// </summary>
        public DepartmentProfile()
        {
            #region Generated Mapping
            CreateMap<Department, DepartmentViewModel>();
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
