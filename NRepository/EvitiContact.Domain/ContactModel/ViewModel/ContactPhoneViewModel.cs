using System;
using EvitiContact.ContactModel;

namespace EvitiContact.Domain.ContactModelDB
{
    public partial class ContactPhoneViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactPhoneViewModel"/> class.
        /// Based on <see cref="ContactPhone"/> class.
        /// </summary>
        public ContactPhoneViewModel()
        {
        }
        #region Generated  ViewModel
        public Guid GUID { get; set; }
        public Guid ContactGUID { get; set; }
        public string Name { get; set; }
        public string AreaCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Extension { get; set; }
        public bool IsInternational { get; set; }
        public bool IsPrimary { get; set; }
        public int PhoneTypeId { get; set; }
        #endregion

        public bool IsDeleted { get; set; }
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
