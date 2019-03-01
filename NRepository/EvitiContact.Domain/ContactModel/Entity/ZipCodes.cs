using eviti.Data.Tracking.BaseObjects;
using eviti.data.tracking.Interfaces;
using System;
using System.Collections.Generic;
using EvitiContact.ContactModel;

namespace EvitiContact.ContactModel
{
    public partial class ZipCodes : ClientChangeTracker, IPKEntity
    {
        public ZipCodes()
        {
            #region Generated Constructor
            #endregion
            InitializePartial();
        }

        partial void InitializePartial();

        #region Generated Properties
        private int _ID;  
        public int ID { get { return _ID; } set { SetKeyWithOutNotify(value, ref _ID); } } 


        private string _ZipCode;  
        public string ZipCode { get { return _ZipCode; } set { SetWithNotify(value, ref _ZipCode); } } 


        private string _Latitude;  
        public string Latitude { get { return _Latitude; } set { SetWithNotify(value, ref _Latitude); } } 


        private string _Longitude;  
        public string Longitude { get { return _Longitude; } set { SetWithNotify(value, ref _Longitude); } } 


        private string _Class;  
        public string Class { get { return _Class; } set { SetWithNotify(value, ref _Class); } } 


        private string _City;  
        public string City { get { return _City; } set { SetWithNotify(value, ref _City); } } 


        private int _StateCode;  
        public int StateCode { get { return _StateCode; } set { SetWithNotify(value, ref _StateCode); } } 


        #endregion
        #region Generated Relationships

        public virtual States StateCodeNavigation { get; set; }
        #endregion
    }
}
