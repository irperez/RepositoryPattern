using eviti.Data.Tracking.BaseObjects;
using eviti.data.tracking.Interfaces;
using System;
using System.Collections.Generic;
using EvitiContact.ContactModel;

namespace EvitiContact.ContactModel
{
    public partial class AuditLog : ClientChangeTracker, IPKEntity
    {
        public AuditLog()
        {
            #region Generated Constructor
            #endregion
            InitializePartial();
        }

        partial void InitializePartial();

        #region Generated Properties
        private long _Id;  
        public long Id { get { return _Id; } set { SetKeyWithOutNotify(value, ref _Id); } } 


        private string _EntityName;  
        public string EntityName { get { return _EntityName; } set { SetWithNotify(value, ref _EntityName); } } 


        private string _PropertyName;  
        public string PropertyName { get { return _PropertyName; } set { SetWithNotify(value, ref _PropertyName); } } 


        private string _PrimaryKeyValue;  
        public string PrimaryKeyValue { get { return _PrimaryKeyValue; } set { SetWithNotify(value, ref _PrimaryKeyValue); } } 


        private string _OldValue;  
        public string OldValue { get { return _OldValue; } set { SetWithNotify(value, ref _OldValue); } } 


        private string _NewValue;  
        public string NewValue { get { return _NewValue; } set { SetWithNotify(value, ref _NewValue); } } 


        private DateTime _DateChanged;  
        public DateTime DateChanged { get { return _DateChanged; } set { SetWithNotify(value, ref _DateChanged); } } 


        private string _EntityState;  
        public string EntityState { get { return _EntityState; } set { SetWithNotify(value, ref _EntityState); } } 


        #endregion
        #region Generated Relationships
        #endregion
    }
}
