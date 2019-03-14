using eviti.Data.Tracking.BaseObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace eviti.data.tracking.BaseObjects
{

    /// <summary>
    /// Simple class to get the tracking state count for an object 
    /// </summary>
    public static class TrackingHelper
    {

        public static int GetModifiedPropertiesForTrackedItem(ClientChangeTracker item)
        {
            int? result = item.ModifiedProperties?.Count;

            if (result.HasValue)
            {
                return result.Value;
            }
            else
            {
                return 0;
            }

        }

        /// <summary>
        ///  this method can be used in a auto mapper profile configuration to map the IsDeleted Value to a Deleted Tracking State
 
        /// Example
        /// CreateMap<MDDetailUpdateModel, MDDetail>(MemberList.None)
        ///     .EqualityComparison((odto, o) => odto.DetailID == o.DetailID)
        ///     .ForMember(d => d.TrackingState, opt => opt.MapFrom(s => TrackingStateHelper.SetIsDeletedToTrackingStateDeleted(s.IsDeleted)));
        /// </summary>
        /// <param name="IsDeleted"></param>
        /// <returns></returns>
        public static TrackingState SetIsDeletedToTrackingStateDeleted(bool IsDeleted)
        {
            if (IsDeleted == true)
            {
                return TrackingState.Deleted;
            }
            else
            {
                return TrackingState.Unchanged;
            }

        }
    }



 


    //public partial class MDDetailProfile : Profile
    //{
    //    /// <summary>
    //    /// Initializes a new instance of the <see cref="MDDetailProfile"/> class.
    //    /// </summary>
    //    public MDDetailProfile()
    //    {
    //        //CreateMap<EvitiContactModel.Core.Data.Entities.MDDetail, EvitiContactModel.Core.Domain.Models.MDDetailReadModel>();
    //        //CreateMap<EvitiContactModel.Core.Domain.Models.MDDetailCreateModel, EvitiContactModel.Core.Data.Entities.MDDetail>();


    //        //CreateMap<EvitiContactModel.Core.Domain.Models.MDDetailUpdateModel, EvitiContactModel.Core.Data.Entities.MDDetail>(MemberList.None)
    //        //    .EqualityComparison((odto, o) => odto.DetailID == o.DetailID).ReverseMap();


    //        CreateMap<MDDetailUpdateModel, MDDetail>(MemberList.None)
    //        .EqualityComparison((odto, o) => odto.DetailID == o.DetailID)
    //                         .ForMember(d => d.TrackingState, opt => opt.MapFrom(s => TrackingStateHelper.SetIsDeletedToTrackingStateDeleted(s.IsDeleted)));

    //        CreateMap<MDDetail, MDDetailUpdateModel>(MemberList.None)
    //                  .EqualityComparison((odto, o) => odto.DetailID == o.DetailID);
    //    }



    //}
}
