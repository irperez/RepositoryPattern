﻿using System;
using System.Collections.Generic;
using AutoMapper;
using FluentValidation;
using eviti.Data.Tracking.BaseObjects;
using eviti.data.tracking.Interfaces;
using EvitiContact.ContactModel;

namespace EvitiContact.Domain.ContactModelDB
{
    public partial class ZipCodesProfile : Profile
    {
    /// <summary>
    /// Initializes a new instance of the <see cref="ZipCodesProfile"/> class.
    /// Based on <see cref="ZipCodes"/> class.
    /// </summary>
        public ZipCodesProfile()
        {
            #region Generated Mapping
            CreateMap<ZipCodes, ZipCodesViewModel>();
            #endregion
            CreateMap<ZipCodes, ZipCodesViewModel>(MemberList.None);
            CreateMap<ZipCodesViewModel, ZipCodes>(MemberList.None);
        }
     }
    /*
    #region Generated Reference Class
    public partial class ZipCodes
    {
        public int ID { get; set; }
        public string ZipCode { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Class { get; set; }
        public string City { get; set; }
        public int StateCode { get; set; }

        public States StateCodeNavigation { get; set; }
    }
    #endregion
    */
}
