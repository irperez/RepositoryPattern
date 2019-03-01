using eviti.Data.Tracking.BaseObjects;
using eviti.data.tracking.Interfaces;
using System;
using System.Collections.Generic;
using EvitiContact.ContactModel;

namespace EvitiContact.ContactModel
{
    public partial class ContactPhone : ClientChangeTracker, IPKEntity
    {
        public ContactPhone()
        {
            #region Generated Constructor
            #endregion
            InitializePartial();
        }

        partial void InitializePartial();

        #region Generated Properties
        private Guid _GUID;  
        public Guid GUID { get { return _GUID; } set { SetKeyWithOutNotify(value, ref _GUID); } } 


        private Guid _ContactGUID;  
        public Guid ContactGUID { get { return _ContactGUID; } set { SetWithNotify(value, ref _ContactGUID); } } 


        private string _Name;  
        public string Name { get { return _Name; } set { SetWithNotify(value, ref _Name); } } 


        private string _AreaCode;  
        public string AreaCode { get { return _AreaCode; } set { SetWithNotify(value, ref _AreaCode); } } 


        private string _PhoneNumber;  
        public string PhoneNumber { get { return _PhoneNumber; } set { SetWithNotify(value, ref _PhoneNumber); } } 


        private string _Extension;  
        public string Extension { get { return _Extension; } set { SetWithNotify(value, ref _Extension); } } 


        private bool _IsInternational;  
        public bool IsInternational { get { return _IsInternational; } set { SetWithNotify(value, ref _IsInternational); } } 


        private bool _IsPrimary;  
        public bool IsPrimary { get { return _IsPrimary; } set { SetWithNotify(value, ref _IsPrimary); } } 


        private int _PhoneTypeId;  
        public int PhoneTypeId { get { return _PhoneTypeId; } set { SetWithNotify(value, ref _PhoneTypeId); } } 


        #endregion
        #region Generated Relationships

        public virtual Contact ContactGU { get; set; }
        #endregion
    }
}
