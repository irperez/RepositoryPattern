 
using eviti.data.tracking.DIHelp;
using eviti.Data.Tracking.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;
using EvitiContact.ContactModel;
using EvitiContact.Domain.Services;

namespace ContactDB.IntegrationTests.ContactDBHelpers
{
    public class ContactHelper
    {

        private readonly IMessageSink diagnosticMessageSink;

        public ContactHelper(IMessageSink diagnosticMessageSink)
        {
            this.diagnosticMessageSink = diagnosticMessageSink;

        }


        public static ContactUser GetContactUserFull()
        {
            ContactUser contactUser = new ContactUser
            {
                UserName = "ContactUserUserName",
                IsDeleted = false
            };


            Contact c = GetContactFull();
            contactUser.ContactGu = c;

            c.ContactAddresses.Add(GetAddress());
            c.ContactAddresses.Add(GetAddress());

            return contactUser;

        }

        public static Contact GetContact()
        {

            Contact contact = new Contact
            {
                FirstName = "TestPartialSelectUserAnomous",
                LastName = "bob-LastName",
                TypeID = 1,
                IsDemo = true,
                IsDeleted = false
            };


            return contact;
        }

        public static Contact GetContactFull()
        {
            Contact contact = GetContactWithAddress();

            contact.ContactEmails.Add(GetContactEmail());
            contact.ContactPhones.Add(GetContactPhone());


            return contact;
        }
        public static Contact GetContactWithAddress()
        {
            Contact contact = GetContact();

            ContactAddress address1 = GetAddress();

            contact.ContactAddresses.Add(address1);

            return contact;
        }

        public static ContactPhone GetContactPhone()
        {
            ContactPhone phone = new ContactPhone
            {
                Name = "Name",
                IsPrimary = true,
                AreaCode = "302",
                PhoneNumber = "388-2920",
                Extension = "123",
                PhoneTypeId = 1,
            };
            return phone;

        }

        public static ContactEmail GetContactEmail()
        {
            ContactEmail email = new ContactEmail
            {
                Name = "Name",
                IsPrimary = true,
                EmailAddress = "rgodfrey@nanthealth.com",
            };
            return email;

        }
        public static ContactAddress GetAddress(IStateService stateService, string StateCode, string ZipCode)
        {


            // States state = stateService.GetStateByAbbreviation(StateCode);
            //ZipCodes zipCode = stateService.GetZipByCode(ZipCode);

            States state1 = new States
            {
                StateCode = 10,
                Name = "Delaware",
                Abbreviation = "DE"
            };

            ZipCodes zipCode1 = new ZipCodes
            {
                ID = 7761,
                City = "HOCKESSIN",
                ZipCode = "19707"
            };


            //https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings
            ContactAddress address1 = new ContactAddress
            {
                Name = "Name",
                Street = "Street1",
                Street2 = "Stree2" + DateTime.Now.ToString("s"),
                City = zipCode1.City,
                ZipCode = zipCode1.ZipCode,
                State = state1.StateCode
            };
            return address1;
        }
        public static ContactAddress GetAddress()
        {
            IStateService stateService = ServiceLocator.GetService<IStateService>();
            return GetAddress(stateService, "DE", "19707");
        }




        private void DebugUser(ContactUser cu, string header)
        {


            StringBuilder sb = new StringBuilder();
            sb.AppendLine(header);
            sb.AppendLine("User Guid: " + cu.UserGUID);
            sb.AppendLine("Contact Guid: " + cu.ContactGu.GUID);
            sb.AppendLine("First Name: " + cu.ContactGu.FirstName);
            sb.AppendLine("Last Name: " + cu.ContactGu.LastName);

            foreach (var address in cu.ContactGu.ContactAddresses)
            {
                sb.AppendLine("address GUID: " + address.GUID);
                sb.AppendLine("address Name: " + address.Name);
            }


            foreach (var phone in cu.ContactGu.ContactPhones)
            {
                sb.AppendLine("phone GUID: " + phone.GUID);
                sb.AppendLine("phone Name: " + phone.Name);
            }


            //            use[evitiContactModel]


            //declare @contactguid as uniqueidentifier

            //set @contactguid = '7EC18482-D8F9-42E0-31B7-08D6392FD27A'
            //select* from contactuser cu
            //inner join Contact c on c.GUID = cu.ContactGuid
            //where c.GUID = @contactguid

            //select* from ContactAddress where ContactGUID = @contactguid
            //select* from ContactEmail where ContactGUID = @contactguid
            //select* from ContactPhone where ContactGUID = @contactguid




            System.Diagnostics.Debug.WriteLine(sb.ToString());

        }


        public static List<Contact> GetNewContactList(int TotalCount = 500)
        {
            List<Contact> resultList = new List<Contact>();
            RandomNameGenerator rn = new RandomNameGenerator();
            var list = rn.GenerateWithRandomNamesBob(TotalCount);

            foreach (var item in list)
            {

                Contact p = new Contact
                {
                    FirstName = item.FirstName,
                    MiddleName = item.Middle,
                    LastName = item.LastName,
                    TypeID = 1,
                    IsDeleted = false,
                   // CreatedOn = DateTime.Now
                };
              //  p.ModifiedOn = p.CreatedOn;
                p.CompanyName = "Inserted";

                resultList.Add(p);


            }

            return resultList;
        }
    }
}
