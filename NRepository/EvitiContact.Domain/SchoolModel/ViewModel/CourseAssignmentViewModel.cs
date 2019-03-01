using System;
using System.Collections.Generic;
using AutoMapper;
using FluentValidation;
using eviti.Data.Tracking.BaseObjects;
using eviti.data.tracking.Interfaces;
using EvitiContact.SchoolModel;

namespace EvitiContact.Domain.ContactModelDB
{
    public partial class CourseAssignmentViewModel
     {
    /// <summary>
    /// Initializes a new instance of the <see cref="CourseAssignmentViewModel"/> class.
    /// Based on <see cref="CourseAssignment"/> class.
    /// </summary>
    public CourseAssignmentViewModel()
     {
     }
    #region Generated  ViewModel
    public int InstructorID { get; set; }
    public int CourseID { get; set; }
    #endregion
     }
    /*
    #region Generated Reference Class
    public partial class CourseAssignment
    {
        public int InstructorID { get; set; }
        public int CourseID { get; set; }

        public Course Course { get; set; }
        public Instructor Instructor { get; set; }
    }
    #endregion
    */
}
