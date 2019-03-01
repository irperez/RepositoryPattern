using System;
using System.Collections.Generic;
using AutoMapper;
using FluentValidation;
using eviti.Data.Tracking.BaseObjects;
using eviti.data.tracking.Interfaces;
using EvitiContact.ContactModel;

namespace EvitiContact.Domain.ContactModelDB
{
    public partial class AuditLogViewModel
     {
    /// <summary>
    /// Initializes a new instance of the <see cref="AuditLogViewModel"/> class.
    /// Based on <see cref="AuditLog"/> class.
    /// </summary>
    public AuditLogViewModel()
     {
     }
    #region Generated  ViewModel
    public long Id { get; set; }
    public string EntityName { get; set; }
    public string PropertyName { get; set; }
    public string PrimaryKeyValue { get; set; }
    public string OldValue { get; set; }
    public string NewValue { get; set; }
    public DateTime DateChanged { get; set; }
    public string EntityState { get; set; }
    #endregion
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
