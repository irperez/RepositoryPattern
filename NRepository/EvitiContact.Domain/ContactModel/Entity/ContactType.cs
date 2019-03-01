using eviti.Data.Tracking.BaseObjects;
using eviti.data.tracking.Interfaces;
using System;
using System.Collections.Generic;
using EvitiContact.ContactModel;

namespace EvitiContact.ContactModel
{
    public partial class ContactType : ClientChangeTracker, IPKEntity
    {
        public ContactType()
        {
            #region Generated Constructor
            Contacts = new List<Contact>();
            #endregion
            InitializePartial();
        }

        partial void InitializePartial();

        #region Generated Properties
        private int _ID;  
        public int ID { get { return _ID; } set { SetKeyWithOutNotify(value, ref _ID); } } 


        private string _Name;  
        public string Name { get { return _Name; } set { SetWithNotify(value, ref _Name); } } 


        private string _Description;  
        public string Description { get { return _Description; } set { SetWithNotify(value, ref _Description); } } 


        private int? _ParentID;  
        public int? ParentID { get { return _ParentID; } set { SetWithNotify(value, ref _ParentID); } } 


        private bool? _IsActive;  
        public bool? IsActive { get { return _IsActive; } set { SetWithNotify(value, ref _IsActive); } } 


        #endregion
        #region Generated Relationships

        public virtual IList<Contact> Contacts { get; set; }
        #endregion
    }
}
