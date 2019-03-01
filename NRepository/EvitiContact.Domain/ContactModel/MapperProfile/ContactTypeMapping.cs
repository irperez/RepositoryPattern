using System;
using System.Collections.Generic;
using AutoMapper;
using FluentValidation;
using eviti.Data.Tracking.BaseObjects;
using eviti.data.tracking.Interfaces;
using EvitiContact.ContactModel;

namespace EvitiContact.Domain.ContactModelDB
{
    public partial class ContactTypeProfile : Profile
    {
    /// <summary>
    /// Initializes a new instance of the <see cref="ContactTypeProfile"/> class.
    /// Based on <see cref="ContactType"/> class.
    /// </summary>
        public ContactTypeProfile()
        {
            #region Generated Mapping
            CreateMap<ContactType, ContactTypeViewModel>();
            #endregion
         }
     }
    /*
    #region Generated Reference Class
    public partial class ContactType
    {
        public ContactType()
        {
            Contacts = new HashSet<Contact>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ParentID { get; set; }
        public bool? IsActive { get; set; }

        public ICollection<Contact> Contacts { get; set; }
    }
    #endregion
    */
}
