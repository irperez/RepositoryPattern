using eviti.Data.Tracking.BaseObjects;
using eviti.data.tracking.Interfaces;
using System;
using System.Collections.Generic;
using EvitiContact.ContactModel;

namespace EvitiContact.ContactModel
{
    public partial class ContactExternalIDs : ClientChangeTracker, IPKEntity
    {
        public ContactExternalIDs()
        {
            #region Generated Constructor
            #endregion
            InitializePartial();
        }

        partial void InitializePartial();

        #region Generated Properties
        private Guid _Guid;  
        public Guid Guid { get { return _Guid; } set { SetKeyWithOutNotify(value, ref _Guid); } } 


        private Guid _ContactGuid;  
        public Guid ContactGuid { get { return _ContactGuid; } set { SetWithNotify(value, ref _ContactGuid); } } 


        private string _Identifier;  
        public string Identifier { get { return _Identifier; } set { SetWithNotify(value, ref _Identifier); } } 


        private string _Description;  
        public string Description { get { return _Description; } set { SetWithNotify(value, ref _Description); } } 


        private Guid? _ApplicationOwnerGuid;  
        public Guid? ApplicationOwnerGuid { get { return _ApplicationOwnerGuid; } set { SetWithNotify(value, ref _ApplicationOwnerGuid); } } 


        #endregion
        #region Generated Relationships

        public virtual Contact ContactGu { get; set; }
        #endregion
    }
}
