﻿using System;
using System.Collections.Generic;
using AutoMapper;
using FluentValidation;
using eviti.Data.Tracking.BaseObjects;
using eviti.data.tracking.Interfaces;
using EvitiContact.SchoolModel;

namespace EvitiContact.Domain.ContactModelDB
{
    public partial class EnrollmentViewModelValidator : AbstractValidator<EnrollmentViewModel>
     {
    /// <summary>
    /// Initializes a new instance of the <see cref="EnrollmentViewModelValidator"/> class.
    /// </summary>
    public EnrollmentViewModelValidator()
     {
    #region Generated Validation For ViewModel
    #endregion
     }
     }
    /*
    #region Generated Reference Class
    public partial class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public int? Grade { get; set; }

        public Course Course { get; set; }
        public Student Student { get; set; }
    }
    #endregion
    */
}
