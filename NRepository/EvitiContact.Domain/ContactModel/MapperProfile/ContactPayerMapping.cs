using System;
using System.Collections.Generic;
using AutoMapper;
using FluentValidation;
using eviti.Data.Tracking.BaseObjects;
using eviti.data.tracking.Interfaces;
using EvitiContact.ContactModel;

namespace EvitiContact.Domain.ContactModelDB
{
    public partial class ContactPayerProfile : Profile
    {
    /// <summary>
    /// Initializes a new instance of the <see cref="ContactPayerProfile"/> class.
    /// Based on <see cref="ContactPayer"/> class.
    /// </summary>
        public ContactPayerProfile()
        {
            #region Generated Mapping
            CreateMap<ContactPayer, ContactPayerViewModel>();
            #endregion
         }
     }
    /*
    #region Generated Reference Class
    public partial class ContactPayer
    {
        public Guid PayerGuid { get; set; }
        public string PayerID { get; set; }
        public string Name { get; set; }
        public bool DefaultToEBM { get; set; }
        public string EligibilityVerifier { get; set; }
        public int? EligibilityVerifierMode { get; set; }
        public Guid? PrimaryAdminContact { get; set; }
        public bool? IsComplete { get; set; }
        public string RegistrationPin { get; set; }
        public string EvitiDisplayName { get; set; }
        public string ParameterDictionary { get; set; }
        public bool IsInPublicList { get; set; }
        public Guid? EntityGuid { get; set; }
        public bool IsPayerEmailOn { get; set; }
        public bool HideNonCompliantRegimens { get; set; }
        public bool IsActive { get; set; }
        public bool ShowPerformanceStatus { get; set; }
        public bool ShowPlanCompliantColumn { get; set; }
        public bool ShowBiomarkersForChemo { get; set; }
        public bool ShowBiomarkersForRadiation { get; set; }
        public int TreatmentEndDate { get; set; }
        public int TurnaroundUrgentHours { get; set; }
        public int TurnaroundStandardHours { get; set; }
        public int TurnaroundClockType { get; set; }
        public bool RunStateMandateAnalyzer { get; set; }
        public bool IsDefaultLOBAllowed { get; set; }
        public bool ShowMatchTrial { get; set; }
    }
    #endregion
    */
}
