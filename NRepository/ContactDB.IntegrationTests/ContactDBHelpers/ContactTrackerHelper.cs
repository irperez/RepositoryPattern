using eviti.data.tracking.BaseObjects;
using EvitiContact.ContactModel;
namespace ContactDB.IntegrationTests.ContactDBHelpers
{

    public class ContactTrackerHelper
    {

        public static int GetModifiedPropertiesCount(ContactUser cu)
        {

            int result = TrackingHelper. GetModifiedPropertiesForTrackedItem(cu);

            Contact c = cu.ContactGu;

            if (c != null)
            {
                result = result + TrackingHelper.GetModifiedPropertiesForTrackedItem(c);

                foreach (var item in c.ContactAddresses)
                {
                    result = result + TrackingHelper.GetModifiedPropertiesForTrackedItem(item);
                }

                foreach (var item in c.ContactPhones)
                {
                    result = result + TrackingHelper.GetModifiedPropertiesForTrackedItem(item);
                }

                foreach (var item in c.ContactEmails)
                {
                    result = result + TrackingHelper.GetModifiedPropertiesForTrackedItem(item);
                }

                foreach (var item in c.ContactExternalIDs)
                {
                    result = result + TrackingHelper.GetModifiedPropertiesForTrackedItem(item);
                }
            }

            return result;


        }
        //private static int GetModifiedPropertiesForTrackedItem(ClientChangeTracker item)
        //{
        //    int? result = item.ModifiedProperties?.Count;

        //    if (result.HasValue)
        //    {
        //        return result.Value;
        //    }
        //    else
        //    {
        //        return 0;
        //    }

        //}
    }
}
