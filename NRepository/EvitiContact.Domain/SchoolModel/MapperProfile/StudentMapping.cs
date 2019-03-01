using System;
using System.Collections.Generic;
using AutoMapper;
using FluentValidation;
using eviti.Data.Tracking.BaseObjects;
using eviti.data.tracking.Interfaces;
using EvitiContact.SchoolModel;

namespace EvitiContact.Domain.ContactModelDB
{
    public partial class StudentProfile : Profile
    {
    /// <summary>
    /// Initializes a new instance of the <see cref="StudentProfile"/> class.
    /// Based on <see cref="Student"/> class.
    /// </summary>
        public StudentProfile()
        {
            #region Generated Mapping
            CreateMap<Student, StudentViewModel>();
            #endregion
         }
     }
    /*
    #region Generated Reference Class
    public partial class Student
    {
        public Student()
        {
            Enrollments = new HashSet<Enrollment>();
        }

        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
    #endregion
    */
}
