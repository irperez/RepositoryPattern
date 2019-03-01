using eviti.Data.Tracking.BaseObjects;
using eviti.data.tracking.Interfaces;
using System;
using System.Collections.Generic;
using EvitiContact.ContactModel;

namespace EvitiContact.ContactModel
{
    public partial class ContactAddress : ClientChangeTracker, IPKEntity
    {
        public ContactAddress()
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


        private string _Street;  
        public string Street { get { return _Street; } set { SetWithNotify(value, ref _Street); } } 


        private string _Street2;  
        public string Street2 { get { return _Street2; } set { SetWithNotify(value, ref _Street2); } } 


        private string _City;  
        public string City { get { return _City; } set { SetWithNotify(value, ref _City); } } 


        private int? _State;  
        public int? State { get { return _State; } set { SetWithNotify(value, ref _State); } } 


        private string _Province;  
        public string Province { get { return _Province; } set { SetWithNotify(value, ref _Province); } } 


        private string _ZipCodeExtension;  
        public string ZipCodeExtension { get { return _ZipCodeExtension; } set { SetWithNotify(value, ref _ZipCodeExtension); } } 


        private string _ZipCode;  
        public string ZipCode { get { return _ZipCode; } set { SetWithNotify(value, ref _ZipCode); } } 


        private string _Country;  
        public string Country { get { return _Country; } set { SetWithNotify(value, ref _Country); } } 


        private bool _IsPrimary;  
        public bool IsPrimary { get { return _IsPrimary; } set { SetWithNotify(value, ref _IsPrimary); } } 


        private string _TimeZone;  
        public string TimeZone { get { return _TimeZone; } set { SetWithNotify(value, ref _TimeZone); } } 


        private string _Longitude;  
        public string Longitude { get { return _Longitude; } set { SetWithNotify(value, ref _Longitude); } } 


        private string _Latitude;  
        public string Latitude { get { return _Latitude; } set { SetWithNotify(value, ref _Latitude); } } 


        private string _ZipCodeString;  
        public string ZipCodeString { get { return _ZipCodeString; } set { SetWithNotify(value, ref _ZipCodeString); } } 


        #endregion
        #region Generated Relationships

        public virtual Contact ContactGU { get; set; }
        public virtual States StateNavigation { get; set; }
        #endregion
    }
}
