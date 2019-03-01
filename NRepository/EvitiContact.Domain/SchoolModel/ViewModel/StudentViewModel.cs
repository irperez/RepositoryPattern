using System;
using System.Collections.Generic;
using AutoMapper;
using FluentValidation;
using eviti.Data.Tracking.BaseObjects;
using eviti.data.tracking.Interfaces;
using EvitiContact.SchoolModel;

namespace EvitiContact.Domain.ContactModelDB
{
    public partial class StudentViewModel
     {
    /// <summary>
    /// Initializes a new instance of the <see cref="StudentViewModel"/> class.
    /// Based on <see cref="Student"/> class.
    /// </summary>
    public StudentViewModel()
     {
     }
    #region Generated  ViewModel
    public int ID { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public DateTime EnrollmentDate { get; set; }
    #endregion
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
