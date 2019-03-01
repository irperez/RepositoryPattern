using System;
using System.Collections.Generic;
using AutoMapper;
using FluentValidation;
using eviti.Data.Tracking.BaseObjects;
using eviti.data.tracking.Interfaces;
using EvitiContact.ContactModel;

namespace EvitiContact.Domain.ContactModelDB
{
    public partial class ZipCodesValidator : AbstractValidator<ZipCodes>
     {
    /// <summary>
    /// Initializes a new instance of the <see cref="ZipCodesValidator"/> class.
    /// </summary>
    public ZipCodesValidator()
     {
    #region Generated Entity Validation
    RuleFor(p => p.ZipCode).MaximumLength(5);
    RuleFor(p => p.Latitude).MaximumLength(256);
    RuleFor(p => p.Longitude).MaximumLength(256);
    RuleFor(p => p.Class).MaximumLength(1);
    RuleFor(p => p.City).NotEmpty();
    RuleFor(p => p.City).MaximumLength(28);
    #endregion
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
