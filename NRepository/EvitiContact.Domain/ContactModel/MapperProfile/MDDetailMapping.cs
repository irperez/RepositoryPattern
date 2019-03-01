﻿using System;
using System.Collections.Generic;
using AutoMapper;
using FluentValidation;
using eviti.Data.Tracking.BaseObjects;
using eviti.data.tracking.Interfaces;
using EvitiContact.ContactModel;

namespace EvitiContact.Domain.ContactModelDB
{
    public partial class MDDetailProfile : Profile
    {
    /// <summary>
    /// Initializes a new instance of the <see cref="MDDetailProfile"/> class.
    /// Based on <see cref="MDDetail"/> class.
    /// </summary>
        public MDDetailProfile()
        {
            #region Generated Mapping
            CreateMap<MDDetail, MDDetailViewModel>();
            #endregion
         }
     }
    /*
    #region Generated Reference Class
    public partial class MDDetail
    {
        public Guid DetailID { get; set; }
        public Guid MasterId { get; set; }
        public string Name { get; set; }
        public string SomeOtherName { get; set; }
        public decimal? Dollars { get; set; }
        public string Version { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public MDMaster Master { get; set; }
    }
    #endregion
    */
}
