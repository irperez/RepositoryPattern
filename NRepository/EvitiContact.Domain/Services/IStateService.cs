using System;
using System.Collections.Generic;
using System.Text;
using EvitiContact.ContactModel;

namespace EvitiContact.Domain.Services
{
    public interface IStateService
    {
        void StartUp();
        States GetStateByAbbreviation(string Abbreviation);
        List<States> GetAllStates();
        States GetStateByName(string Name);
        ZipCodes GetZipByCode(string zipCode);
    }
}
