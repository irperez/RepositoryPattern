using eviti.Data.Tracking.BaseObjects;
using eviti.data.tracking.Interfaces;
using System;
using System.Collections.Generic;
using EvitiContact.ContactModel;

namespace EvitiContact.ContactModel
{
    public partial class MDDetail : ClientChangeTracker, IPKEntity, IAuditedEntity
    {
        public MDDetail()
        {
            #region Generated Constructor
            #endregion
            InitializePartial();
        }

        partial void InitializePartial();

        #region Generated Properties
        private Guid _DetailID;  
        public Guid DetailID { get { return _DetailID; } set { SetKeyWithOutNotify(value, ref _DetailID); } } 


        private Guid _MasterId;  
        public Guid MasterId { get { return _MasterId; } set { SetWithNotify(value, ref _MasterId); } } 


        private string _Name;  
        public string Name { get { return _Name; } set { SetWithNotify(value, ref _Name); } } 


        private string _SomeOtherName;  
        public string SomeOtherName { get { return _SomeOtherName; } set { SetWithNotify(value, ref _SomeOtherName); } } 


        private decimal? _Dollars;  
        public decimal? Dollars { get { return _Dollars; } set { SetWithNotify(value, ref _Dollars); } } 


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


        #endregion
        #region Generated Relationships

        public virtual MDMaster Master { get; set; }
        #endregion
    }
}
