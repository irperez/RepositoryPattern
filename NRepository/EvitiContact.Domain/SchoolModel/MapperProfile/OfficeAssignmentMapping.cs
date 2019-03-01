using System;
using System.Collections.Generic;
using AutoMapper;
using FluentValidation;
using eviti.Data.Tracking.BaseObjects;
using eviti.data.tracking.Interfaces;
using EvitiContact.SchoolModel;

namespace EvitiContact.Domain.ContactModelDB
{
    public partial class OfficeAssignmentProfile : Profile
    {
    /// <summary>
    /// Initializes a new instance of the <see cref="OfficeAssignmentProfile"/> class.
    /// Based on <see cref="OfficeAssignment"/> class.
    /// </summary>
        public OfficeAssignmentProfile()
        {
            #region Generated Mapping
            CreateMap<OfficeAssignment, OfficeAssignmentViewModel>();
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
