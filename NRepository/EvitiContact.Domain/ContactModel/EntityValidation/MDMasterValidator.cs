using System;
using System.Collections.Generic;
using AutoMapper;
using FluentValidation;
using eviti.Data.Tracking.BaseObjects;
using eviti.data.tracking.Interfaces;
using EvitiContact.ContactModel;

namespace EvitiContact.Domain.ContactModelDB
{
    public partial class MDMasterValidator : AbstractValidator<MDMaster>
     {
    /// <summary>
    /// Initializes a new instance of the <see cref="MDMasterValidator"/> class.
    /// </summary>
    public MDMasterValidator()
     {
    #region Generated Entity Validation
    RuleFor(p => p.Name).NotEmpty();
    RuleFor(p => p.Name).MaximumLength(50);
    //RuleFor(p => p.Version).NotEmpty();
    //RuleFor(p => p.Version).MaximumLength(50);
    //RuleFor(p => p.CreatedBy).NotEmpty();
    //RuleFor(p => p.CreatedBy).MaximumLength(256);
    //RuleFor(p => p.ModifiedBy).NotEmpty();
    //RuleFor(p => p.ModifiedBy).MaximumLength(256);
    //RuleFor(p => p.RowVersion).NotEmpty();
    #endregion
     }
     }
    /*
    #region Generated Reference Class
    public partial class MDMaster
    {
        public MDMaster()
        {
            MDDetails = new HashSet<MDDetail>();
        }

        public Guid MasterId { get; set; }
        public string Name { get; set; }
        public decimal? TotalDollars { get; set; }
        public decimal NewRequired { get; set; }
        public string Version { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public byte[] RowVersion { get; set; }

        public ICollection<MDDetail> MDDetails { get; set; }
    }
    #endregion
    */
}
