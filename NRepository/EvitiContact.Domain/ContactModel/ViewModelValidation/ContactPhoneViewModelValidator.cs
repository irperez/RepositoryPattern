using System;
using System.Collections.Generic;
using AutoMapper;
using FluentValidation;
using eviti.Data.Tracking.BaseObjects;
using eviti.data.tracking.Interfaces;
using EvitiContact.ContactModel;

namespace EvitiContact.Domain.ContactModelDB
{
    public partial class ContactPhoneViewModelValidator : AbstractValidator<ContactPhoneViewModel>
     {
    /// <summary>
    /// Initializes a new instance of the <see cref="ContactPhoneViewModelValidator"/> class.
    /// </summary>
    public ContactPhoneViewModelValidator()
     {
    #region Generated Validation For ViewModel
    RuleFor(p => p.Name).NotEmpty();
    RuleFor(p => p.Name).MaximumLength(100);
    RuleFor(p => p.AreaCode).NotEmpty();
    RuleFor(p => p.AreaCode).MaximumLength(5);
    RuleFor(p => p.PhoneNumber).NotEmpty();
    RuleFor(p => p.PhoneNumber).MaximumLength(10);
    RuleFor(p => p.Extension).MaximumLength(10);
    #endregion
     }
     }
    /*
    #region Generated Reference Class
    public partial class ContactPhone
    {
        public Guid GUID { get; set; }
        public Guid ContactGUID { get; set; }
        public string Name { get; set; }
        public string AreaCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Extension { get; set; }
        public bool IsInternational { get; set; }
        public bool IsPrimary { get; set; }
        public int PhoneTypeId { get; set; }

        public Contact ContactGU { get; set; }
    }
    #endregion
    */
}
