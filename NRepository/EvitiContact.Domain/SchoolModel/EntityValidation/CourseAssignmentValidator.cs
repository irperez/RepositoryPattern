using System;
using System.Collections.Generic;
using AutoMapper;
using FluentValidation;
using eviti.Data.Tracking.BaseObjects;
using eviti.data.tracking.Interfaces;
using EvitiContact.SchoolModel;

namespace EvitiContact.Domain.ContactModelDB
{
    public partial class CourseAssignmentValidator : AbstractValidator<CourseAssignment>
     {
    /// <summary>
    /// Initializes a new instance of the <see cref="CourseAssignmentValidator"/> class.
    /// </summary>
    public CourseAssignmentValidator()
     {
    #region Generated Entity Validation
    #endregion
     }
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
