using System;
using System.Collections.Generic;
using AutoMapper;
using FluentValidation;
using eviti.Data.Tracking.BaseObjects;
using eviti.data.tracking.Interfaces;
using EvitiContact.ContactModel;

namespace EvitiContact.Domain.ContactModelDB
{
    public partial class ContactExternalIDsViewModel
     {
    /// <summary>
    /// Initializes a new instance of the <see cref="ContactExternalIDsViewModel"/> class.
    /// Based on <see cref="ContactExternalIDs"/> class.
    /// </summary>
    public ContactExternalIDsViewModel()
     {
     }
    #region Generated  ViewModel
    public Guid Guid { get; set; }
    public Guid ContactGuid { get; set; }
    public string Identifier { get; set; }
    public string Description { get; set; }
    public Guid? ApplicationOwnerGuid { get; set; }
    #endregion
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
