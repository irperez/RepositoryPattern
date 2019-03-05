using eviti.Data.Tracking.BaseObjects;
using eviti.data.tracking.Interfaces;
using System;
using System.Collections.Generic;
using EvitiContact.ContactModel;

namespace EvitiContact.ContactModel
{


    /// <summary>
    /// Need to test if Internal or protected will work to encapsulate the domain model
    /// 
    ///  // internal or protected.
    //private string _Name;
    //public string Name { get { return _Name; } internal set { SetWithNotify(value, ref _Name); } }
    /// </summary>
    public partial class MDMaster : ClientChangeTracker, IPKEntity, IAuditedEntity
    {
        public MDMaster() // internal MDMaster()
        {
            #region Generated Constructor
            MDDetails = new List<MDDetail>();
            #endregion
            InitializePartial();
        }
        public MDMaster(string name) : this()
        {
            this.Name = name;
        }
        partial void InitializePartial();

        #region Generated Properties
        private Guid _MasterId;  
        public Guid MasterId { get { return _MasterId; } set { SetKeyWithOutNotify(value, ref _MasterId); } } 


        private string _Name;  
        public string Name { get { return _Name; } set { SetWithNotify(value, ref _Name); } } 


        private decimal? _TotalDollars;  
        public decimal? TotalDollars { get { return _TotalDollars; } set { SetWithNotify(value, ref _TotalDollars); } } 


        private decimal _NewRequired;  
        public decimal NewRequired { get { return _NewRequired; } set { SetWithNotify(value, ref _NewRequired); } } 


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


        private byte[] _RowVersion;  
        public byte[] RowVersion { get { return _RowVersion; } set { SetWithNotify(value, ref _RowVersion); } } 


        #endregion
        #region Generated Relationships

        public virtual IList<MDDetail> MDDetails { get; set; }
        #endregion

        public static MDMaster GetNewMasterRecord()
        {
            return new MDMaster();
        }
    }
}
