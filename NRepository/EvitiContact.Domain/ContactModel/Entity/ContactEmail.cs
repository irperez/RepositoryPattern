﻿using eviti.Data.Tracking.BaseObjects;
using eviti.data.tracking.Interfaces;
using System;
using System.Collections.Generic;
using EvitiContact.ContactModel;

namespace EvitiContact.ContactModel
{
    public partial class ContactEmail : ClientChangeTracker, IPKEntity
    {
        public ContactEmail()
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


        private string _Name;  
        public string Name { get { return _Name; } set { SetWithNotify(value, ref _Name); } } 


        private string _EmailAddress;  
        public string EmailAddress { get { return _EmailAddress; } set { SetWithNotify(value, ref _EmailAddress); } }

        // Looks like bool are a problem for the tracking framework if we don't start with the original state.  
        // We can only support nullable bools
        // because if we have a true field, we default to false, get an update to set the field to false
        // the tracking framework comparison will not "see" the tracking change.  Changing them to 
        // nullable bools will work, until i find a reason why it will not, as it passed items on to 
        // EF core
        private bool? _IsPrimary;  
        public bool? IsPrimary { get { return _IsPrimary; } set { SetWithNotify(value, ref _IsPrimary); } } 


        #endregion
        #region Generated Relationships

        public virtual Contact ContactGu { get; set; }
        #endregion
    }
}
