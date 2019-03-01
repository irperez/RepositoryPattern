using System;
using System.Collections.Generic;
using AutoMapper;
using FluentValidation;
using eviti.Data.Tracking.BaseObjects;
using eviti.data.tracking.Interfaces;
using EvitiContact.ContactModel;

namespace EvitiContact.Domain.ContactModelDB
{
    public partial class StatesValidator : AbstractValidator<States>
     {
    /// <summary>
    /// Initializes a new instance of the <see cref="StatesValidator"/> class.
    /// </summary>
    public StatesValidator()
     {
    #region Generated Entity Validation
    RuleFor(p => p.Abbreviation).MaximumLength(2);
    RuleFor(p => p.Name).NotEmpty();
    RuleFor(p => p.Name).MaximumLength(15);
    #endregion
     }
     }
    /*
    #region Generated Reference Class
    public partial class States
    {
        public States()
        {
            ContactAddresses = new HashSet<ContactAddress>();
            ZipCodes = new HashSet<ZipCodes>();
        }

        public int StateCode { get; set; }
        public string Abbreviation { get; set; }
        public string Name { get; set; }
        public bool IsStandard { get; set; }

        public ICollection<ContactAddress> ContactAddresses { get; set; }
        public ICollection<ZipCodes> ZipCodes { get; set; }
    }
    #endregion
    */
}
