﻿using System;
using System.Collections.Generic;
using AutoMapper;
using FluentValidation;
using eviti.Data.Tracking.BaseObjects;
using eviti.data.tracking.Interfaces;
using EvitiContact.SchoolModel;

namespace EvitiContact.Domain.ContactModelDB
{
    public partial class CourseValidator : AbstractValidator<Course>
     {
    /// <summary>
    /// Initializes a new instance of the <see cref="CourseValidator"/> class.
    /// </summary>
    public CourseValidator()
     {
    #region Generated Entity Validation
    RuleFor(p => p.Title).MaximumLength(50);
    #endregion
     }
     }
    /*
    #region Generated Reference Class
    public partial class Course
    {
        public Course()
        {
            CourseAssignments = new HashSet<CourseAssignment>();
            Enrollments = new HashSet<Enrollment>();
        }

        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentID { get; set; }

        public Department Department { get; set; }
        public ICollection<CourseAssignment> CourseAssignments { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
    #endregion
    */
}
