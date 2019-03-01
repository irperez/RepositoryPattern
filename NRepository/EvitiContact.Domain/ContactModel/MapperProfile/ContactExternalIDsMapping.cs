using System;
using System.Collections.Generic;
using AutoMapper;
using FluentValidation;
using eviti.Data.Tracking.BaseObjects;
using eviti.data.tracking.Interfaces;
using EvitiContact.ContactModel;

namespace EvitiContact.Domain.ContactModelDB
{
    public partial class ContactExternalIDsProfile : Profile
    {
    /// <summary>
    /// Initializes a new instance of the <see cref="ContactExternalIDsProfile"/> class.
    /// Based on <see cref="ContactExternalIDs"/> class.
    /// </summary>
        public ContactExternalIDsProfile()
        {
            #region Generated Mapping
            CreateMap<ContactExternalIDs, ContactExternalIDsViewModel>();
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
