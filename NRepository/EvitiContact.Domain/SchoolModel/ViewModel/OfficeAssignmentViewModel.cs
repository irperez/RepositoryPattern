using System;
using System.Collections.Generic;
using AutoMapper;
using FluentValidation;
using eviti.Data.Tracking.BaseObjects;
using eviti.data.tracking.Interfaces;
using EvitiContact.SchoolModel;

namespace EvitiContact.Domain.ContactModelDB
{
    public partial class OfficeAssignmentViewModel
     {
    /// <summary>
    /// Initializes a new instance of the <see cref="OfficeAssignmentViewModel"/> class.
    /// Based on <see cref="OfficeAssignment"/> class.
    /// </summary>
    public OfficeAssignmentViewModel()
     {
     }
    #region Generated  ViewModel
    public int InstructorID { get; set; }
    public string Location { get; set; }
    #endregion
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
