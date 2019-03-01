using eviti.Data.Tracking.BaseObjects;
using eviti.data.tracking.Interfaces;
using System;
using System.Collections.Generic;
using EvitiContact.ContactModel;

namespace EvitiContact.ContactModel
{
    public partial class States : ClientChangeTracker, IPKEntity
    {
        public States()
        {
            #region Generated Constructor
            ContactAddresses = new List<ContactAddress>();
            ZipCodes = new List<ZipCodes>();
            #endregion
            InitializePartial();
        }

        partial void InitializePartial();

        #region Generated Properties
        private int _StateCode;  
        public int StateCode { get { return _StateCode; } set { SetKeyWithOutNotify(value, ref _StateCode); } } 


        private string _Abbreviation;  
        public string Abbreviation { get { return _Abbreviation; } set { SetWithNotify(value, ref _Abbreviation); } } 


        private string _Name;  
        public string Name { get { return _Name; } set { SetWithNotify(value, ref _Name); } } 


        private bool _IsStandard;  
        public bool IsStandard { get { return _IsStandard; } set { SetWithNotify(value, ref _IsStandard); } } 


        #endregion
        #region Generated Relationships

        public virtual IList<ContactAddress> ContactAddresses { get; set; }
        public virtual IList<ZipCodes> ZipCodes { get; set; }
        #endregion
    }
}
