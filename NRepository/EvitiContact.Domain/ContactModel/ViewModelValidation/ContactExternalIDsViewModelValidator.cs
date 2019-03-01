using System;
using System.Collections.Generic;
using AutoMapper;
using FluentValidation;
using eviti.Data.Tracking.BaseObjects;
using eviti.data.tracking.Interfaces;
using EvitiContact.ContactModel;

namespace EvitiContact.Domain.ContactModelDB
{
    public partial class ContactExternalIDsViewModelValidator : AbstractValidator<ContactExternalIDsViewModel>
     {
    /// <summary>
    /// Initializes a new instance of the <see cref="ContactExternalIDsViewModelValidator"/> class.
    /// </summary>
    public ContactExternalIDsViewModelValidator()
     {
    #region Generated Validation For ViewModel
    RuleFor(p => p.Identifier).NotEmpty();
    RuleFor(p => p.Identifier).MaximumLength(200);
    RuleFor(p => p.Description).MaximumLength(500);
    #endregion
     }
     }
    /*
    #region Generated Reference Class
    public partial class ContactExternalIDs
    {
        public Guid Guid { get; set; }
        public Guid ContactGuid { get; set; }
        public string Identifier { get; set; }
        public string Description { get; set; }
        public Guid? ApplicationOwnerGuid { get; set; }

        public Contact ContactGu { get; set; }
    }
    #endregion
    */
}
