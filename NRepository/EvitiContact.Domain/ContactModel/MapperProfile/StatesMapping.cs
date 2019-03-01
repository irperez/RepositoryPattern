using System;
using System.Collections.Generic;
using AutoMapper;
using FluentValidation;
using eviti.Data.Tracking.BaseObjects;
using eviti.data.tracking.Interfaces;
using EvitiContact.ContactModel;

namespace EvitiContact.Domain.ContactModelDB
{
    public partial class StatesProfile : Profile
    {
    /// <summary>
    /// Initializes a new instance of the <see cref="StatesProfile"/> class.
    /// Based on <see cref="States"/> class.
    /// </summary>
        public StatesProfile()
        {
            #region Generated Mapping
            CreateMap<States, StatesViewModel>();
            #endregion
            CreateMap<States, StatesViewModel>(MemberList.None);
            CreateMap<StatesViewModel, States>(MemberList.None);
        }
     }
    /*
    #region Generated Reference Class
    public partial class States
    {
        public States()
        {
            ContactAddresses = new HashSet<ContactAddress>();
            ZipCodes = new HashSet<ZipCodes>();
        }

        public int StateCode { get; set; }
        public string Abbreviation { get; set; }
        public string Name { get; set; }
        public bool IsStandard { get; set; }

        public ICollection<ContactAddress> ContactAddresses { get; set; }
        public ICollection<ZipCodes> ZipCodes { get; set; }
    }
    #endregion
    */
}
