using System;
using System.Collections.Generic;
using AutoMapper;
using FluentValidation;
using eviti.Data.Tracking.BaseObjects;
using eviti.data.tracking.Interfaces;
using EvitiContact.SchoolModel;

namespace EvitiContact.Domain.ContactModelDB
{
    public partial class CourseAssignmentViewModelValidator : AbstractValidator<CourseAssignmentViewModel>
     {
    /// <summary>
    /// Initializes a new instance of the <see cref="CourseAssignmentViewModelValidator"/> class.
    /// </summary>
    public CourseAssignmentViewModelValidator()
     {
    #region Generated Validation For ViewModel
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
