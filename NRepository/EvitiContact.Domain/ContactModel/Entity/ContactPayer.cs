using eviti.Data.Tracking.BaseObjects;
using eviti.data.tracking.Interfaces;
using System;
using System.Collections.Generic;
using EvitiContact.ContactModel;

namespace EvitiContact.ContactModel
{
    public partial class ContactPayer : ClientChangeTracker, IPKEntity
    {
        public ContactPayer()
        {
            #region Generated Constructor
            #endregion
            InitializePartial();
        }

        partial void InitializePartial();

        #region Generated Properties
        private Guid _PayerGuid;  
        public Guid PayerGuid { get { return _PayerGuid; } set { SetKeyWithOutNotify(value, ref _PayerGuid); } } 


        private string _PayerID;  
        public string PayerID { get { return _PayerID; } set { SetWithNotify(value, ref _PayerID); } } 


        private string _Name;  
        public string Name { get { return _Name; } set { SetWithNotify(value, ref _Name); } } 


        private bool _DefaultToEBM;  
        public bool DefaultToEBM { get { return _DefaultToEBM; } set { SetWithNotify(value, ref _DefaultToEBM); } } 


        private string _EligibilityVerifier;  
        public string EligibilityVerifier { get { return _EligibilityVerifier; } set { SetWithNotify(value, ref _EligibilityVerifier); } } 


        private int? _EligibilityVerifierMode;  
        public int? EligibilityVerifierMode { get { return _EligibilityVerifierMode; } set { SetWithNotify(value, ref _EligibilityVerifierMode); } } 


        private Guid? _PrimaryAdminContact;  
        public Guid? PrimaryAdminContact { get { return _PrimaryAdminContact; } set { SetWithNotify(value, ref _PrimaryAdminContact); } } 


        private bool? _IsComplete;  
        public bool? IsComplete { get { return _IsComplete; } set { SetWithNotify(value, ref _IsComplete); } } 


        private string _RegistrationPin;  
        public string RegistrationPin { get { return _RegistrationPin; } set { SetWithNotify(value, ref _RegistrationPin); } } 


        private string _EvitiDisplayName;  
        public string EvitiDisplayName { get { return _EvitiDisplayName; } set { SetWithNotify(value, ref _EvitiDisplayName); } } 


        private string _ParameterDictionary;  
        public string ParameterDictionary { get { return _ParameterDictionary; } set { SetWithNotify(value, ref _ParameterDictionary); } } 


        private bool _IsInPublicList;  
        public bool IsInPublicList { get { return _IsInPublicList; } set { SetWithNotify(value, ref _IsInPublicList); } } 


        private Guid? _EntityGuid;  
        public Guid? EntityGuid { get { return _EntityGuid; } set { SetWithNotify(value, ref _EntityGuid); } } 


        private bool _IsPayerEmailOn;  
        public bool IsPayerEmailOn { get { return _IsPayerEmailOn; } set { SetWithNotify(value, ref _IsPayerEmailOn); } } 


        private bool _HideNonCompliantRegimens;  
        public bool HideNonCompliantRegimens { get { return _HideNonCompliantRegimens; } set { SetWithNotify(value, ref _HideNonCompliantRegimens); } } 


        private bool _IsActive;  
        public bool IsActive { get { return _IsActive; } set { SetWithNotify(value, ref _IsActive); } } 


        private bool _ShowPerformanceStatus;  
        public bool ShowPerformanceStatus { get { return _ShowPerformanceStatus; } set { SetWithNotify(value, ref _ShowPerformanceStatus); } } 


        private bool _ShowPlanCompliantColumn;  
        public bool ShowPlanCompliantColumn { get { return _ShowPlanCompliantColumn; } set { SetWithNotify(value, ref _ShowPlanCompliantColumn); } } 


        private bool _ShowBiomarkersForChemo;  
        public bool ShowBiomarkersForChemo { get { return _ShowBiomarkersForChemo; } set { SetWithNotify(value, ref _ShowBiomarkersForChemo); } } 


        private bool _ShowBiomarkersForRadiation;  
        public bool ShowBiomarkersForRadiation { get { return _ShowBiomarkersForRadiation; } set { SetWithNotify(value, ref _ShowBiomarkersForRadiation); } } 


        private int _TreatmentEndDate;  
        public int TreatmentEndDate { get { return _TreatmentEndDate; } set { SetWithNotify(value, ref _TreatmentEndDate); } } 


        private int _TurnaroundUrgentHours;  
        public int TurnaroundUrgentHours { get { return _TurnaroundUrgentHours; } set { SetWithNotify(value, ref _TurnaroundUrgentHours); } } 


        private int _TurnaroundStandardHours;  
        public int TurnaroundStandardHours { get { return _TurnaroundStandardHours; } set { SetWithNotify(value, ref _TurnaroundStandardHours); } } 


        private int _TurnaroundClockType;  
        public int TurnaroundClockType { get { return _TurnaroundClockType; } set { SetWithNotify(value, ref _TurnaroundClockType); } } 


        private bool _RunStateMandateAnalyzer;  
        public bool RunStateMandateAnalyzer { get { return _RunStateMandateAnalyzer; } set { SetWithNotify(value, ref _RunStateMandateAnalyzer); } } 


        private bool _IsDefaultLOBAllowed;  
        public bool IsDefaultLOBAllowed { get { return _IsDefaultLOBAllowed; } set { SetWithNotify(value, ref _IsDefaultLOBAllowed); } } 


        private bool _ShowMatchTrial;  
        public bool ShowMatchTrial { get { return _ShowMatchTrial; } set { SetWithNotify(value, ref _ShowMatchTrial); } } 


        #endregion
        #region Generated Relationships
        #endregion
    }
}
