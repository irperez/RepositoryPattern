using System;
using System.Collections.Generic;
using System.Text;
 
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using EvitiContact.ContactModel;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using static ContactDB.IntegrationTests.SliceFixture;
 
using System.Threading;
using ContactDB.IntegrationTests.ContactDBHelpers;

namespace ContactDB.IntegrationTests.Other
{


  
    public class PartialTest : IntegrationTestBase
    {


        [Fact]
        public async Task TestPartialSelectUserAnomous()
        {

            var contact = ContactHelper.GetContactWithAddress();

            try
            {
                await InsertAsync(contact);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }




            Guid contactGuid = contact.GUID;

            string FirstName = string.Empty;
            await ExecuteDbContextAsync(async (contect, mediator) =>
            {
                var cu = await contect.Contact
                .Where(x => x.GUID == contactGuid)
                .Select(x => new
                {
                    ContactGuid = x.GUID,
                    x.FirstName,
                    Addresses = x.ContactAddresses.ToList(),
                })
                .FirstOrDefaultAsync();

                FirstName = cu.FirstName;

            });


            FirstName.ShouldBe(contact.FirstName);




        }
    }
}
