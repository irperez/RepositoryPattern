using System;
using System.Collections.Generic;
using AutoMapper;
using FluentValidation;
using eviti.Data.Tracking.BaseObjects;
using eviti.data.tracking.Interfaces;
using EvitiContact.ContactModel;

namespace EvitiContact.Domain.ContactModelDB
{
    public partial class AuditLogViewModelValidator : AbstractValidator<AuditLogViewModel>
     {
    /// <summary>
    /// Initializes a new instance of the <see cref="AuditLogViewModelValidator"/> class.
    /// </summary>
    public AuditLogViewModelValidator()
     {
    #region Generated Validation For ViewModel
    RuleFor(p => p.EntityName).NotEmpty();
    RuleFor(p => p.EntityName).MaximumLength(100);
    RuleFor(p => p.PropertyName).NotEmpty();
    RuleFor(p => p.PropertyName).MaximumLength(100);
    RuleFor(p => p.PrimaryKeyValue).MaximumLength(100);
    RuleFor(p => p.OldValue).MaximumLength(100);
    RuleFor(p => p.NewValue).MaximumLength(100);
    RuleFor(p => p.EntityState).NotEmpty();
    RuleFor(p => p.EntityState).MaximumLength(100);
    #endregion
     }
     }
    /*
    #region Generated Reference Class
    public partial class AuditLog
    {
        public long Id { get; set; }
        public string EntityName { get; set; }
        public string PropertyName { get; set; }
        public string PrimaryKeyValue { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public DateTime DateChanged { get; set; }
        public string EntityState { get; set; }
    }
    #endregion
    */
}
