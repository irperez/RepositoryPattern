﻿using System;
using System.Collections.Generic;
using AutoMapper;
using FluentValidation;
using eviti.Data.Tracking.BaseObjects;
using eviti.data.tracking.Interfaces;
using EvitiContact.ContactModel;

namespace EvitiContact.Domain.ContactModelDB
{
    public partial class ContactPhoneProfile : Profile
    {
    /// <summary>
    /// Initializes a new instance of the <see cref="ContactPhoneProfile"/> class.
    /// Based on <see cref="ContactPhone"/> class.
    /// </summary>
        public ContactPhoneProfile()
        {
            #region Generated Mapping
            CreateMap<ContactPhone, ContactPhoneViewModel>();
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
