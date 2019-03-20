using System;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using AutoMapper;
using FluentValidation;
using eviti.Data.Tracking.BaseObjects;
using eviti.data.tracking.Interfaces;
using EvitiContact.ContactModel;

namespace EvitiContact.Domain.ContactModelDB
{
    public partial class ContactViewModel : ITrackOrginalValue
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactViewModel"/> class.
        /// Based on <see cref="Contact"/> class.
        /// </summary>
        public ContactViewModel()
        {
        }
        #region Generated  ViewModel
        public Guid? GUID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a title for your video.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Display(Name = "Title")]
        public string Title { get; set; }
        //public string Credentials { get; set; }
        //public string Prefix { get; set; }
        //public string Suffix { get; set; }
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        [Display(Name = "Contact Type")]
        public int TypeID { get; set; }
        [Display(Name = "Is Doctor")]
        public bool IsMd { get; set; }
        //public string Version { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public string CreatedBy { get; set; }
        //public DateTime ModifiedDate { get; set; }
        //public string ModifiedBy { get; set; }
        //public string SSN { get; set; }
        //public bool? IsTest { get; set; }
        //public bool IsDemo { get; set; }
        [Display(Name = "Is Deleted")]
        public bool IsDeleted { get; set; }
        //public string Department { get; set; }
        //public Guid? CreatedByUserID { get; set; }
        //public Guid? ModifiedByUserID { get; set; }
        #endregion
        public ContactTypeViewModel Type { get; set; }
        public IList<ContactPhoneViewModel> ContactPhones { get; set; } = new List<ContactPhoneViewModel>();
        public IList<ContactEmailViewModel> ContactEmails { get; set; } = new List<ContactEmailViewModel>();
        public IList<ContactAddressViewModel> ContactAddresses { get; set; } = new List<ContactAddressViewModel>();
        public string OriginalVMObject { get; set; }
    }
    /*
    #region Generated Reference Class
    public partial class Contact
    {
        public Contact()
        {
            ContactAddresses = new HashSet<ContactAddress>();
            ContactEmails = new HashSet<ContactEmail>();
            ContactExternalIDs = new HashSet<ContactExternalIDs>();
            ContactPhones = new HashSet<ContactPhone>();
            ContactUsers = new HashSet<ContactUser>();
        }

        public Guid GUID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Title { get; set; }
        public string Credentials { get; set; }
        public string Prefix { get; set; }
        public string Suffix { get; set; }
        public string CompanyName { get; set; }
        public int TypeID { get; set; }
        public bool IsMd { get; set; }
        public string Version { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string SSN { get; set; }
        public bool? IsTest { get; set; }
        public bool IsDemo { get; set; }
        public bool IsDeleted { get; set; }
        public string Department { get; set; }
        public Guid? CreatedByUserID { get; set; }
        public Guid? ModifiedByUserID { get; set; }

        public ContactType Type { get; set; }
        public ICollection<ContactAddress> ContactAddresses { get; set; }
        public ICollection<ContactEmail> ContactEmails { get; set; }
        public ICollection<ContactExternalIDs> ContactExternalIDs { get; set; }
        public ICollection<ContactPhone> ContactPhones { get; set; }
        public ICollection<ContactUser> ContactUsers { get; set; }
    }
    #endregion
    */
}
