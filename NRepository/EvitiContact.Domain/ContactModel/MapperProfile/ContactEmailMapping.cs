using System;
using System.Collections.Generic;
using AutoMapper;
using FluentValidation;
using eviti.Data.Tracking.BaseObjects;
using eviti.data.tracking.Interfaces;
using EvitiContact.ContactModel;

namespace EvitiContact.Domain.ContactModelDB
{
    public partial class ContactEmailProfile : Profile
    {
    /// <summary>
    /// Initializes a new instance of the <see cref="ContactEmailProfile"/> class.
    /// Based on <see cref="ContactEmail"/> class.
    /// </summary>
        public ContactEmailProfile()
        {
            #region Generated Mapping
            CreateMap<ContactEmail, ContactEmailViewModel>();
            #endregion
            CreateMap<ContactEmailViewModel, ContactEmail>();
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
