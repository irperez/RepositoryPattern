using EvitiContact.ContactModel;
using eviti.data.tracking;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using static ContactDB.IntegrationTests.SliceFixture;
using EvitiContact.Domain.ContactModelDB;
using EvitiContact.Service;

namespace ContactDB.IntegrationTests.ControlerTests
{

    public class MDControlerServiceTests : IntegrationTestBase
        {

            //[Fact]
            //public async Task UpdateTestThisHasABugWithScopeTracking()
            //{
            //    MDMaster master = await MasterDetailDBHelper.GetMasterInserted();

            //    await ExecuteBobScopedServiceProfiderAsync(async (sp) =>
            //    {
            //        MDControlerHelper controler = sp.GetRequiredService<MDControlerHelper>();

            //        MDMasterViewModel item = controler.Get(master.MasterId);

            //       var newModel = controler.Post(item);

            //    });



            //}

            [Fact]
            public async Task UpdateTestWorking()
            {
                MDMaster master = await MasterDetailDBHelper.GetMasterInserted();

                CommandResult2<MDMasterViewModel> outboundItem = null;
                MDMasterViewModel inbounditem = null;


                await ExecuteBobScopedServiceProfiderAsync(async (sp) =>
                {
                    MasterDetailControllerService controler = sp.GetRequiredService<MasterDetailControllerService>();
                    inbounditem = controler.Get(master.MasterId);
                });

                await ExecuteBobScopedServiceProfiderAsync(async (sp) =>
                {
                    MasterDetailControllerService controler = sp.GetRequiredService<MasterDetailControllerService>();
                    outboundItem = controler.Post(inbounditem);
                });

            }


            [Fact]
            public async Task UpdateTesModifyItem()
            {
                MDMaster master = await MasterDetailDBHelper.GetMasterInserted();
                string NameToUpdate = "BobBob";
                MDMasterViewModel inbounditem = null;
                CommandResult2<MDMasterViewModel> outboundItem = null;

                await ExecuteBobScopedServiceProfiderAsync(async (sp) =>
                {
                    MasterDetailControllerService controler = sp.GetRequiredService<MasterDetailControllerService>();
                    inbounditem = controler.Get(master.MasterId);
                });

                inbounditem.Name = NameToUpdate;

                await ExecuteBobScopedServiceProfiderAsync(async (sp) =>
                {
                    MasterDetailControllerService controler = sp.GetRequiredService<MasterDetailControllerService>();
                    outboundItem = controler.Post(inbounditem);
                });

                MDMaster masterFromPostUpdate = null;
                await ExecuteBobScopedServiceProfiderAsync(async (sp) =>
                {
                    ContactModelDbContext contect = sp.GetRequiredService<ContactModelDbContext>();
                    masterFromPostUpdate = await contect.MDMaster.Where(x => x.MasterId == master.MasterId).FirstOrDefaultAsync();
                });

                masterFromPostUpdate.ShouldNotBeNull();
                masterFromPostUpdate.MasterId.ShouldBe(master.MasterId);

                NameToUpdate.ShouldBe(masterFromPostUpdate.Name);
            }



            [Fact]
            public async Task MDControlerServiceUpdateTesModifyItemBadData()
            {
                MDMaster master = await MasterDetailDBHelper.GetMasterInserted();
                string NameToUpdate = string.Empty;
                MDMasterViewModel inbounditem = null;
                CommandResult2<MDMasterViewModel> outboundItem = null;

                await ExecuteBobScopedServiceProfiderAsync(async (sp) =>
                {
                    MasterDetailControllerService controler = sp.GetRequiredService<MasterDetailControllerService>();
                    inbounditem = controler.Get(master.MasterId);
                });

                inbounditem.Name = NameToUpdate;

                inbounditem.MDDetails[0].Name = string.Empty;

                await ExecuteBobScopedServiceProfiderAsync(async (sp) =>
                {
                    MasterDetailControllerService controler = sp.GetRequiredService<MasterDetailControllerService>();

                    try
                    {
                        outboundItem = controler.Post(inbounditem);
                    }
                    catch (ValidationException ex)
                    {
                        string t = ex.Message;
                    }

                });

                MDMaster masterFromPostUpdate = null;
                await ExecuteBobScopedServiceProfiderAsync(async (sp) =>
                {
                    ContactModelDbContext contect = sp.GetRequiredService<ContactModelDbContext>();
                    masterFromPostUpdate = await contect.MDMaster.Where(x => x.MasterId == master.MasterId).FirstOrDefaultAsync();
                });

                masterFromPostUpdate.ShouldNotBeNull();
                masterFromPostUpdate.MasterId.ShouldBe(master.MasterId);
           


                ValidationResult vr = outboundItem.ValidationReult;
                vr.ShouldNotBeNull();
                vr.IsValid.ShouldBe(false);
                vr.IsValid.ShouldBe(false);

                var nameError = vr.Errors.Where(x => x.PropertyName == nameof(inbounditem.Name)).FirstOrDefault();
                nameError.ShouldNotBeNull();
                nameError.ErrorMessage.ShouldContain(nameof(inbounditem.Name));

                foreach (var item in vr.Errors)
                {
                    System.Diagnostics.Debug.WriteLine(item.ErrorMessage);
                }

            }


      
            //[Fact]
            //public async Task UpdateTesModifyItemControlerBadData()
            //{
            //    MDMaster master = await MasterDetailDBHelper.GetMasterInserted();
            //    string NameToUpdate = string.Empty;
            //    ActionResult<MDMasterViewModel> inbounditem = null;
            //    ActionResult<MDMasterViewModel> outboundItem = null;

            //    await ExecuteBobScopedServiceProfiderAsync(async (sp) =>
            //    {
            //        MDController controler = sp.GetRequiredService<MDController>();
            //        inbounditem = controler.Get(master.MasterId);
            //    });

            //    inbounditem.Value.Nametest = NameToUpdate;

            //    await ExecuteBobScopedServiceProfiderAsync(async (sp) =>
            //    {
            //        MDController controler = sp.GetRequiredService<MDController>();
            //        outboundItem = controler.Post(inbounditem.Value);
            //    });

            //    MDMaster masterFromPostUpdate = null;
            //    await ExecuteBobScopedServiceProfiderAsync(async (sp) =>
            //    {
            //        ContactModelDbContext contect = sp.GetRequiredService<ContactModelDbContext>();
            //        masterFromPostUpdate = await contect.MDMaster.Where(x => x.MasterId == master.MasterId).FirstOrDefaultAsync();
            //    });

            //    masterFromPostUpdate.ShouldNotBeNull();
            //    masterFromPostUpdate.MasterId.ShouldBe(master.MasterId);

            //    NameToUpdate.ShouldBe(masterFromPostUpdate.Name);
            //}
        }

        public class MasterDetailDBHelper
        {

            public static async Task<MDMaster> GetMasterInserted()
            {

                var master = MasterDetailHelper.GetMasterTestObjext();
                await SliceFixture.ExecuteBobScopedServiceProfiderAndContactDBContextAsync(async (sp, dbContext) =>
                {

                    dbContext.AttachOnly(master);
                    await dbContext.SaveChangesAsync();

                });

                return master;

            }
        }

        public class MasterDetailHelper
        {

            public static MDMaster GetMasterTestObjext()
            {

                MDMaster master = new MDMaster
                {
                    Name = "Master1"
                };


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
