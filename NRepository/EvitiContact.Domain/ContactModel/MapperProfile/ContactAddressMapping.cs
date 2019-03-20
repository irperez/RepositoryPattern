using AutoMapper;
using AutoMapper.EquivalencyExpression;
using eviti.data.tracking.BaseObjects;
using EvitiContact.ContactModel;

namespace EvitiContact.Domain.ContactModelDB
{
    public partial class ContactAddressProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactAddressProfile"/> class.
        /// Based on <see cref="ContactAddress"/> class.
        /// </summary>
        public ContactAddressProfile()
        {
            #region Generated Mapping
            CreateMap<ContactAddress, ContactAddressViewModel>();
            #endregion
            //   CreateMap<ContactAddressViewModel, ContactAddress>();

            CreateMap<ContactAddressViewModel, ContactAddress>(MemberList.None)
        .EqualityComparison((odto, o) => odto.GUID == o.GUID)
        .ForMember(d => d.TrackingState, opt => opt.MapFrom(s => TrackingHelper.SetIsDeletedToTrackingStateDeleted(s.IsDeleted)));
        }
    }
    /*
    #region Generated Reference Class
    public partial class ContactAddress
    {
        public Guid GUID { get; set; }
        public Guid ContactGUID { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public int? State { get; set; }
        public string Province { get; set; }
        public string ZipCodeExtension { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public bool IsPrimary { get; set; }
        public string TimeZone { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string ZipCodeString { get; set; }

        public Contact ContactGU { get; set; }
        public States StateNavigation { get; set; }
    }
    #endregion
    */
}
