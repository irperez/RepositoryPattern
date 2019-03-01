using System;
using System.Collections.Generic;
using AutoMapper;
using FluentValidation;
using eviti.Data.Tracking.BaseObjects;
using eviti.data.tracking.Interfaces;
using EvitiContact.ContactModel;

namespace EvitiContact.Domain.ContactModelDB
{
    public partial class ZipCodesViewModel
     {
    /// <summary>
    /// Initializes a new instance of the <see cref="ZipCodesViewModel"/> class.
    /// Based on <see cref="ZipCodes"/> class.
    /// </summary>
    public ZipCodesViewModel()
     {
     }
    #region Generated  ViewModel
    public int ID { get; set; }
    public string ZipCode { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public string Class { get; set; }
    public string City { get; set; }
    public int StateCode { get; set; }
    #endregion
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
