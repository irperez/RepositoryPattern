using EvitiContact.ContactModel;

namespace EvitiContact.Service.ContactModelDB
{
    public class MasterDetailHelper
    {

        public static MDMaster GetMasterTestObjext()
        {

            MDMaster master = new MDMaster("Master1");
            

            MDDetail detail1 = new MDDetail
            {
                Name = "Detail1",
                SomeOtherName = "detail1 - SomeOtherName"
            };
            master.MDDetails.Add(detail1);

            MDDetail detail2 = new MDDetail
            {
                Name = "Detail2",
                SomeOtherName = "detail2 - SomeOtherName"
            };
            master.MDDetails.Add(detail2);

            MDDetail detail3 = new MDDetail
            {
                Name = "Detail1",
                SomeOtherName = "detail3 - SomeOtherName"
            };
            master.MDDetails.Add(detail3);

            return master;
        }
    }
}
