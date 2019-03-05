using eviti.Data.Tracking.BaseObjects;
using eviti.data.tracking.Interfaces;
using System;
using System.Collections.Generic;
using EvitiContact.ContactModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvitiContact.ContactModel
{
    public partial class ContactUser : ClientChangeTracker, IPKEntity, IAuditedEntity, IHaveIdentifier2<Guid>
    {
        public ContactUser()
        {
            #region Generated Constructor
            #endregion
            InitializePartial();
        }
        [NotMapped]
        public Guid GUID { get => UserGUID; set => UserGUID = value; }
        partial void InitializePartial();

        #region Generated Properties
        private Guid _UserGUID;  
        public Guid UserGUID { get { return _UserGUID; } set { SetKeyWithOutNotify(value, ref _UserGUID); } } 


        private string _UserName;  
        public string UserName { get { return _UserName; } set { SetWithNotify(value, ref _UserName); } } 


        private Guid? _ManagerGUID;  
        public Guid? ManagerGUID { get { return _ManagerGUID; } set { SetWithNotify(value, ref _ManagerGUID); } } 


        private DateTime _CreatedDate;  
        public DateTime CreatedDate { get { return _CreatedDate; } set { SetWithNotify(value, ref _CreatedDate); } } 


        private string _CreatedBy;  
        public string CreatedBy { get { return _CreatedBy; } set { SetWithNotify(value, ref _CreatedBy); } } 


        private DateTime _ModifiedDate;  
        public DateTime ModifiedDate { get { return _ModifiedDate; } set { SetWithNotify(value, ref _ModifiedDate); } } 


        private string _ModifiedBy;  
        public string ModifiedBy { get { return _ModifiedBy; } set { SetWithNotify(value, ref _ModifiedBy); } } 


        private string _Version;  
        public string Version { get { return _Version; } set { SetWithNotify(value, ref _Version); } } 


        private Guid _ContactGuid;  
        public Guid ContactGuid { get { return _ContactGuid; } set { SetWithNotify(value, ref _ContactGuid); } } 


        private bool _IsComplete;  
        public bool IsComplete { get { return _IsComplete; } set { SetWithNotify(value, ref _IsComplete); } } 


        private int? _TermsOfUserVersion;  
        public int? TermsOfUserVersion { get { return _TermsOfUserVersion; } set { SetWithNotify(value, ref _TermsOfUserVersion); } } 


        private DateTime? _TermsOfUsedDate;  
        public DateTime? TermsOfUsedDate { get { return _TermsOfUsedDate; } set { SetWithNotify(value, ref _TermsOfUsedDate); } } 


        private bool _IsApproved;  
        public bool IsApproved { get { return _IsApproved; } set { SetWithNotify(value, ref _IsApproved); } } 


        private bool _IsSecurityQuestionRedefineRequired;  
        public bool IsSecurityQuestionRedefineRequired { get { return _IsSecurityQuestionRedefineRequired; } set { SetWithNotify(value, ref _IsSecurityQuestionRedefineRequired); } } 


        private bool _IsDeleted;  
        public bool IsDeleted { get { return _IsDeleted; } set { SetWithNotify(value, ref _IsDeleted); } } 


        private bool _IsPasswordRedefineRequired;  
        public bool IsPasswordRedefineRequired { get { return _IsPasswordRedefineRequired; } set { SetWithNotify(value, ref _IsPasswordRedefineRequired); } } 


        private DateTime? _SetupCompletedDate;  
        public DateTime? SetupCompletedDate { get { return _SetupCompletedDate; } set { SetWithNotify(value, ref _SetupCompletedDate); } } 


        private int _AccountTypeId;  
        public int AccountTypeId { get { return _AccountTypeId; } set { SetWithNotify(value, ref _AccountTypeId); } } 


        private string _Comment;  
        public string Comment { get { return _Comment; } set { SetWithNotify(value, ref _Comment); } } 


        private byte[] _TSStamp;  
        public byte[] TSStamp { get { return _TSStamp; } set { SetWithNotify(value, ref _TSStamp); } } 


        private bool _IsEvitiManaged;  
        public bool IsEvitiManaged { get { return _IsEvitiManaged; } set { SetWithNotify(value, ref _IsEvitiManaged); } } 


        private Guid? _CreatedByUserID;  
        public Guid? CreatedByUserID { get { return _CreatedByUserID; } set { SetWithNotify(value, ref _CreatedByUserID); } } 


        private Guid? _ModifiedByUserID;  
        public Guid? ModifiedByUserID { get { return _ModifiedByUserID; } set { SetWithNotify(value, ref _ModifiedByUserID); } } 


        #endregion
        #region Generated Relationships

        public virtual Contact ContactGu { get; set; }
        #endregion
    }
}
