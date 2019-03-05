using eviti.Data.Tracking.BaseObjects;
using eviti.data.tracking.Interfaces;
using System;
using System.Collections.Generic;
using EvitiContact.ContactModel;

namespace EvitiContact.ContactModel
{
    public partial class Contact : ClientChangeTracker, IPKEntity, IAuditedEntity, IHaveIdentifier2<Guid>
    {
        public Contact()
        {
            #region Generated Constructor
            ContactAddresses = new List<ContactAddress>();
            ContactEmails = new List<ContactEmail>();
            ContactExternalIDs = new List<ContactExternalIDs>();
            ContactPhones = new List<ContactPhone>();
            ContactUsers = new List<ContactUser>();
            #endregion
            InitializePartial();
        }

        partial void InitializePartial();

        #region Generated Properties
        private Guid _GUID;  
        public Guid GUID { get { return _GUID; } set { SetKeyWithOutNotify(value, ref _GUID); } } 


        private string _FirstName;  
        public string FirstName { get { return _FirstName; } set { SetWithNotify(value, ref _FirstName); } } 


        private string _LastName;  
        public string LastName { get { return _LastName; } set { SetWithNotify(value, ref _LastName); } } 


        private string _MiddleName;  
        public string MiddleName { get { return _MiddleName; } set { SetWithNotify(value, ref _MiddleName); } } 


        private string _Title;  
        public string Title { get { return _Title; } set { SetWithNotify(value, ref _Title); } } 


        private string _Credentials;  
        public string Credentials { get { return _Credentials; } set { SetWithNotify(value, ref _Credentials); } } 


        private string _Prefix;  
        public string Prefix { get { return _Prefix; } set { SetWithNotify(value, ref _Prefix); } } 


        private string _Suffix;  
        public string Suffix { get { return _Suffix; } set { SetWithNotify(value, ref _Suffix); } } 


        private string _CompanyName;  
        public string CompanyName { get { return _CompanyName; } set { SetWithNotify(value, ref _CompanyName); } } 


        private int _TypeID;  
        public int TypeID { get { return _TypeID; } set { SetWithNotify(value, ref _TypeID); } } 


        private bool _IsMd;  
        public bool IsMd { get { return _IsMd; } set { SetWithNotify(value, ref _IsMd); } } 


        private string _Version;  
        public string Version { get { return _Version; } set { SetWithNotify(value, ref _Version); } } 


        private DateTime _CreatedDate;  
        public DateTime CreatedDate { get { return _CreatedDate; } set { SetWithNotify(value, ref _CreatedDate); } } 


        private string _CreatedBy;  
        public string CreatedBy { get { return _CreatedBy; } set { SetWithNotify(value, ref _CreatedBy); } } 


        private DateTime _ModifiedDate;  
        public DateTime ModifiedDate { get { return _ModifiedDate; } set { SetWithNotify(value, ref _ModifiedDate); } } 


        private string _ModifiedBy;  
        public string ModifiedBy { get { return _ModifiedBy; } set { SetWithNotify(value, ref _ModifiedBy); } } 


        private string _SSN;  
        public string SSN { get { return _SSN; } set { SetWithNotify(value, ref _SSN); } } 


        private bool? _IsTest;  
        public bool? IsTest { get { return _IsTest; } set { SetWithNotify(value, ref _IsTest); } } 


        private bool _IsDemo;  
        public bool IsDemo { get { return _IsDemo; } set { SetWithNotify(value, ref _IsDemo); } } 


        private bool _IsDeleted;  
        public bool IsDeleted { get { return _IsDeleted; } set { SetWithNotify(value, ref _IsDeleted); } } 


        private string _Department;  
        public string Department { get { return _Department; } set { SetWithNotify(value, ref _Department); } } 


        private Guid? _CreatedByUserID;  
        public Guid? CreatedByUserID { get { return _CreatedByUserID; } set { SetWithNotify(value, ref _CreatedByUserID); } } 


        private Guid? _ModifiedByUserID;  
        public Guid? ModifiedByUserID { get { return _ModifiedByUserID; } set { SetWithNotify(value, ref _ModifiedByUserID); } } 


        #endregion
        #region Generated Relationships

        public virtual ContactType Type { get; set; }
        public virtual IList<ContactAddress> ContactAddresses { get; set; }
        public virtual IList<ContactEmail> ContactEmails { get; set; }
        public virtual IList<ContactExternalIDs> ContactExternalIDs { get; set; }
        public virtual IList<ContactPhone> ContactPhones { get; set; }
        public virtual IList<ContactUser> ContactUsers { get; set; }
        #endregion
    }
}
