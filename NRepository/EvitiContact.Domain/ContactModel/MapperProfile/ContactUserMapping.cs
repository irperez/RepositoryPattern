using System;
using System.Collections.Generic;
using AutoMapper;
using FluentValidation;
using eviti.Data.Tracking.BaseObjects;
using eviti.data.tracking.Interfaces;
using EvitiContact.ContactModel;

namespace EvitiContact.Domain.ContactModelDB
{
    public partial class ContactUserProfile : Profile
    {
    /// <summary>
    /// Initializes a new instance of the <see cref="ContactUserProfile"/> class.
    /// Based on <see cref="ContactUser"/> class.
    /// </summary>
        public ContactUserProfile()
        {
            #region Generated Mapping
            CreateMap<ContactUser, ContactUserViewModel>();
            #endregion
         }
     }
    /*
    #region Generated Reference Class
    public partial class ContactUser
    {
        public Guid UserGUID { get; set; }
        public string UserName { get; set; }
        public Guid? ManagerGUID { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string Version { get; set; }
        public Guid ContactGuid { get; set; }
        public bool IsComplete { get; set; }
        public int? TermsOfUserVersion { get; set; }
        public DateTime? TermsOfUsedDate { get; set; }
        public bool IsApproved { get; set; }
        public bool IsSecurityQuestionRedefineRequired { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsPasswordRedefineRequired { get; set; }
        public DateTime? SetupCompletedDate { get; set; }
        public int AccountTypeId { get; set; }
        public string Comment { get; set; }
        public byte[] TSStamp { get; set; }
        public bool IsEvitiManaged { get; set; }
        public Guid? CreatedByUserID { get; set; }
        public Guid? ModifiedByUserID { get; set; }

        public Contact ContactGu { get; set; }
    }
    #endregion
    */
}
