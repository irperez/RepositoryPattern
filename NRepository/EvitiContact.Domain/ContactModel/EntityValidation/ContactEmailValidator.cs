using System;
using System.Collections.Generic;
using AutoMapper;
using FluentValidation;
using eviti.Data.Tracking.BaseObjects;
using eviti.data.tracking.Interfaces;
using EvitiContact.ContactModel;

namespace EvitiContact.Domain.ContactModelDB
{
    public partial class ContactEmailValidator : AbstractValidator<ContactEmail>
     {
    /// <summary>
    /// Initializes a new instance of the <see cref="ContactEmailValidator"/> class.
    /// </summary>
    public ContactEmailValidator()
     {
    #region Generated Entity Validation
    RuleFor(p => p.Name).NotEmpty();
    RuleFor(p => p.Name).MaximumLength(100);
    RuleFor(p => p.EmailAddress).NotEmpty();
    RuleFor(p => p.EmailAddress).MaximumLength(200);
    #endregion
     }
     }
    /*
    #region Generated Reference Class
    public partial class ContactEmail
    {
        public Guid Guid { get; set; }
        public Guid ContactGuid { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public bool IsPrimary { get; set; }

        public Contact ContactGu { get; set; }
    }
    #endregion
    */
}
