using System;
using System.Collections.Generic;
using AutoMapper;
using FluentValidation;
using eviti.Data.Tracking.BaseObjects;
using eviti.data.tracking.Interfaces;
using EvitiContact.SchoolModel;

namespace EvitiContact.Domain.ContactModelDB
{
    public partial class OfficeAssignmentViewModelValidator : AbstractValidator<OfficeAssignmentViewModel>
     {
    /// <summary>
    /// Initializes a new instance of the <see cref="OfficeAssignmentViewModelValidator"/> class.
    /// </summary>
    public OfficeAssignmentViewModelValidator()
     {
    #region Generated Validation For ViewModel
    RuleFor(p => p.Location).MaximumLength(50);
    #endregion
     }
     }
    /*
    #region Generated Reference Class
    public partial class OfficeAssignment
    {
        public int InstructorID { get; set; }
        public string Location { get; set; }

        public Instructor Instructor { get; set; }
    }
    #endregion
    */
}
