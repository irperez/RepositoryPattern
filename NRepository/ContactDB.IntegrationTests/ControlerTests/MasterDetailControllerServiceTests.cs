//using EfGenOutputTestLib.ContactModelDB;
//using eviti.data.tracking;
//using FluentValidation.Results;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;
//using Shouldly;
//using System.Linq;
//using System.Threading.Tasks;
//using Xunit;
//using static ContactDB.IntegrationTests.SliceFixture;

//namespace ContactDB.IntegrationTests.ControlerTests
//{
//    public class MasterDetailControllerServiceTests : IntegrationTestBase
//    {
//        [Fact]
//        public async Task MasterDetailControllerServiceTest()
//        {
//            MDMaster master = await MasterDetailDBHelper.GetMasterInserted();
//            string NameToUpdate = "BobBob";
//            MDMasterUpdateModel inbounditem = null;
//            CommandResult2<MDMasterUpdateModel> outboundResult = null;
//            MDMasterUpdateModel outboundItem = null;

//            await ExecuteBobScopedServiceProfiderAsync(async (sp) =>
//            {
//                MasterDetailControllerService controler = sp.GetRequiredService<MasterDetailControllerService>();
//                inbounditem = controler.Get(master.MasterId);
//            });

//            inbounditem.Name = NameToUpdate;

//            await ExecuteBobScopedServiceProfiderAsync(async (sp) =>
//            {
//                MasterDetailControllerService controler = sp.GetRequiredService<MasterDetailControllerService>();
//                outboundResult = controler.Post(inbounditem);
//                outboundItem = outboundResult.Payload;

//            });

//            MDMaster masterFromPostUpdate = null;
//            await ExecuteBobScopedServiceProfiderAsync(async (sp) =>
//            {
//                ContactModelDbContext contect = sp.GetRequiredService<ContactModelDbContext>();
//                masterFromPostUpdate = await contect.MDMaster.Where(x => x.MasterId == master.MasterId).FirstOrDefaultAsync();
//            });
//            outboundItem.ShouldNotBeNull();
//            masterFromPostUpdate.ShouldNotBeNull();
//            masterFromPostUpdate.MasterId.ShouldBe(master.MasterId);
//            NameToUpdate.ShouldBe(outboundItem.Name);
//            NameToUpdate.ShouldBe(masterFromPostUpdate.Name);
//        }

//        [Fact]
//        public async Task MasterDetailControllerServiceTestDeleteData()
//        {
//            MDMaster master = await MasterDetailDBHelper.GetMasterInserted();
//            string NameToUpdate = "MasterDetailControllerServiceTestDeleteData";
//            MDMasterUpdateModel inbounditem = null;
//            CommandResult2<MDMasterUpdateModel> outboundResult = null;
//            MDMasterUpdateModel outboundItem = null;

//            int TotalSubItems = master.MDDetails.Count;

//            await ExecuteBobScopedServiceProfiderAsync(async (sp) =>
//            {
//                MasterDetailControllerService controler = sp.GetRequiredService<MasterDetailControllerService>();
//                inbounditem = controler.Get(master.MasterId);
//            });

//            inbounditem.Name = NameToUpdate;
//            // flag this item as deleted
//            inbounditem.MDDetails[1].IsDeleted = true;
         
//            await ExecuteBobScopedServiceProfiderAsync(async (sp) =>
//            {
//                MasterDetailControllerService controler = sp.GetRequiredService<MasterDetailControllerService>();
//                outboundResult = controler.Post(inbounditem);
//                outboundItem = outboundResult.Payload;

//            });

//            MDMaster masterFromPostUpdate = null;
//            await ExecuteBobScopedServiceProfiderAsync(async (sp) =>
//            {
//                ContactModelDbContext contect = sp.GetRequiredService<ContactModelDbContext>();
//                masterFromPostUpdate = await contect.MDMaster
//                    .Where(x => x.MasterId == master.MasterId).Include(x=>x.MDDetails)
//                    .FirstOrDefaultAsync();
//            });
//            outboundItem.ShouldNotBeNull();
//            masterFromPostUpdate.ShouldNotBeNull();
//            masterFromPostUpdate.MasterId.ShouldBe(master.MasterId);
//            NameToUpdate.ShouldBe(outboundItem.Name);
//            NameToUpdate.ShouldBe(masterFromPostUpdate.Name);


//            int TotalSubItemsAafterDelete = masterFromPostUpdate.MDDetails.Count;
//            TotalSubItemsAafterDelete.ShouldBe(TotalSubItems - 1);

//        }

//        [Fact]
//        public async Task MasterDetailControllerServiceModifyItemBadData()
//        {
//            MDMaster master = await MasterDetailDBHelper.GetMasterInserted();
//            string NameToUpdate = string.Empty;
//            MDMasterUpdateModel inbounditem = null;
//            CommandResult2<MDMasterUpdateModel> outboundItem = null;

//            await ExecuteBobScopedServiceProfiderAsync(async (sp) =>
//            {
//                MasterDetailControllerService controler = sp.GetRequiredService<MasterDetailControllerService>();
//                inbounditem = controler.Get(master.MasterId);
//            });

//            inbounditem.Name = NameToUpdate;

//            inbounditem.MDDetails[0].Name = string.Empty;

//            await ExecuteBobScopedServiceProfiderAsync(async (sp) =>
//            {
//                MasterDetailControllerService controler = sp.GetRequiredService<MasterDetailControllerService>();

//                try
//                {
//                    outboundItem = controler.Post(inbounditem);
//                }
//                catch (ValidationException ex)
//                {
//                    string t = ex.Message;
//                }

//            });

//            MDMaster masterFromPostUpdate = null;
//            await ExecuteBobScopedServiceProfiderAsync(async (sp) =>
//            {
//                ContactModelDbContext contect = sp.GetRequiredService<ContactModelDbContext>();
//                masterFromPostUpdate = await contect.MDMaster.Where(x => x.MasterId == master.MasterId).FirstOrDefaultAsync();
//            });

//            masterFromPostUpdate.ShouldNotBeNull();
//            masterFromPostUpdate.MasterId.ShouldBe(master.MasterId);



//            ValidationResult vr = outboundItem.ValidationReult;
//            vr.ShouldNotBeNull();
//            vr.IsValid.ShouldBe(false);
//            vr.IsValid.ShouldBe(false);

//            var nameError = vr.Errors.Where(x => x.PropertyName == nameof(inbounditem.Name)).FirstOrDefault();
//            nameError.ShouldNotBeNull();
//            nameError.ErrorMessage.ShouldContain(nameof(inbounditem.Name));

//            foreach (var item in vr.Errors)
//            {
//                System.Diagnostics.Debug.WriteLine(item.ErrorMessage);
//            }

//        }
//    }
//}
