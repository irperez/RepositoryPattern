using System;
using System.Collections.Generic;
using AutoMapper;
using FluentValidation;
using eviti.Data.Tracking.BaseObjects;
using eviti.data.tracking.Interfaces;
using EvitiContact.ContactModel;
 

namespace EvitiContact.Domain.ContactModelDB
{
    public partial class MDMasterProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MDMasterProfile"/> class.
        /// Based on <see cref="MDMaster"/> class.
        /// </summary>
        public MDMasterProfile()
        {
            if (1 == 0)
            {
                #region Generated Mapping
                CreateMap<MDMaster, MDMasterViewModel>();
                #endregion
            }


            CreateMap<MDMaster, MDMasterViewModel>(MemberList.None)
             .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.ToBase64String(s.RowVersion)));
            //.ForMember(d => d.PriorityName, opt => opt.MapFrom(s => s.Priority.Name))
            //.ForMember(d => d.StatusName, opt => opt.MapFrom(s => s.Status.Name))
            //.ForMember(d => d.AssignedEmail, opt => opt.MapFrom(s => s.AssignedUser.EmailAddress));


            CreateMap<MDMasterViewModel, MDMaster>(MemberList.None)
                .ForMember(d => d.RowVersion, opt => opt.MapFrom(s => Convert.FromBase64String(s.RowVersion)));
        }
    }
    /*
    #region Generated Reference Class
    public partial class MDMaster
    {
        public MDMaster()
        {
            MDDetails = new HashSet<MDDetail>();
        }

        public Guid MasterId { get; set; }
        public string Name { get; set; }
        public decimal? TotalDollars { get; set; }
        public decimal NewRequired { get; set; }
        public string Version { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public byte[] RowVersion { get; set; }

        public ICollection<MDDetail> MDDetails { get; set; }
    }
    #endregion
    */
}
