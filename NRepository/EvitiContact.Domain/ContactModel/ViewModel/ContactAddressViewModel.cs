using System;
using System.Collections.Generic;
using AutoMapper;
using FluentValidation;
using eviti.Data.Tracking.BaseObjects;
using eviti.data.tracking.Interfaces;
using EvitiContact.ContactModel;

namespace EvitiContact.Domain.ContactModelDB
{
    public partial class ContactAddressViewModel
     {
    /// <summary>
    /// Initializes a new instance of the <see cref="ContactAddressViewModel"/> class.
    /// Based on <see cref="ContactAddress"/> class.
    /// </summary>
    public ContactAddressViewModel()
     {
     }
    #region Generated  ViewModel
    public Guid? GUID { get; set; }
    public Guid ContactGUID { get; set; }
    public string Name { get; set; }
    public string Street { get; set; }
    public string Street2 { get; set; }
    public string City { get; set; }
    public int? State { get; set; }
    public string Province { get; set; }
    public string ZipCodeExtension { get; set; }
    public string ZipCode { get; set; }
    public string Country { get; set; }
    public bool IsPrimary { get; set; }
    public string TimeZone { get; set; }
    public string Longitude { get; set; }
    public string Latitude { get; set; }
    public string ZipCodeString { get; set; }
    #endregion
     }
    /*
    #region Generated Reference Class
    public partial class ContactAddress
    {
        public Guid GUID { get; set; }
        public Guid ContactGUID { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public int? State { get; set; }
        public string Province { get; set; }
        public string ZipCodeExtension { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public bool IsPrimary { get; set; }
        public string TimeZone { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string ZipCodeString { get; set; }

        public Contact ContactGU { get; set; }
        public States StateNavigation { get; set; }
    }
    #endregion
    */
}
