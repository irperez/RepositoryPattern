using System;
using System.Collections.Generic;
using AutoMapper;
using FluentValidation;
using eviti.Data.Tracking.BaseObjects;
using eviti.data.tracking.Interfaces;
using EvitiContact.ContactModel;

namespace EvitiContact.Domain.ContactModelDB
{
    public partial class MDDetailValidator : AbstractValidator<MDDetail>
     {
    /// <summary>
    /// Initializes a new instance of the <see cref="MDDetailValidator"/> class.
    /// </summary>
    public MDDetailValidator()
     {
    #region Generated Entity Validation
    RuleFor(p => p.Name).NotEmpty();
    RuleFor(p => p.Name).MaximumLength(50);
    RuleFor(p => p.SomeOtherName).NotEmpty();
    RuleFor(p => p.SomeOtherName).MaximumLength(50);
    //RuleFor(p => p.Version).NotEmpty();
    //RuleFor(p => p.Version).MaximumLength(50);
    //RuleFor(p => p.CreatedBy).NotEmpty();
    //RuleFor(p => p.CreatedBy).MaximumLength(256);
    //RuleFor(p => p.ModifiedBy).NotEmpty();
    //RuleFor(p => p.ModifiedBy).MaximumLength(256);
    #endregion
     }
     }
    /*
    #region Generated Reference Class
    public partial class MDDetail
    {
        public Guid DetailID { get; set; }
        public Guid MasterId { get; set; }
        public string Name { get; set; }
        public string SomeOtherName { get; set; }
        public decimal? Dollars { get; set; }
        public string Version { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public MDMaster Master { get; set; }
    }
    #endregion
    */
}
