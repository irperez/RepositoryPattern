using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EvitiContact.ContactModel;
using EvitiContact.Domain.Services;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Configuration;

namespace EvitiContact.ApplicationService.Services
{



    public partial class StateService : IStateService
    {


        private readonly ContactModelDbContext ctx;
        private List<States> _list;

        public Dictionary<string, States> _dictByAppriviation { get; private set; }

        public Dictionary<string, States> _dictByName { get; private set; }
        public Dictionary<string, ZipCodes> _zipcodesByCode { get; private set; }

        public StateService(ContactModelDbContext ctx)
        {
            this.ctx = ctx;
        }

        public void DummyItems()
        {


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
        }

        public States GetStateByAbbreviation(string Abbreviation)
        {
            PrepList();

            if (_dictByAppriviation.ContainsKey(Abbreviation) == true)
            {
                return _dictByAppriviation[Abbreviation];
            }

            //  var item = _list.Where(x => x.Abbreviation == Abbreviation).FirstOrDefault();

            return null;
        }

        public States GetStateByName(string Name)
        {
            PrepList();

            if (_dictByName.ContainsKey(Name) == true)
            {
                return _dictByAppriviation[Name];
            }

            return null;
        }

        private object _mylock = new object();
        private void PrepList()
        {
            if (_list == null)
            {

                lock (_mylock)
                {
                    if (_list == null)
                    {
                        _list = ctx.States.Include(x => x.ZipCodes).ToList();
                        _dictByAppriviation = _list.ToDictionary(x => x.Abbreviation, x => x);
                        _dictByName = _list.ToDictionary(x => x.Name, x => x);
                        _zipcodesByCode = new Dictionary<string, ZipCodes>();

                        foreach (var item in _list)
                        {
                            foreach (var subItem in item.ZipCodes)
                            {
                                _zipcodesByCode[subItem.ZipCode] = subItem;
                            }
                        }

                        //    _zipcodesByCode = _list.ToDictionary(x => x.ZipCodes.Select(zip => zip.ZipCode), x => x.ZipCodes.Select(zip => zip));
                    }
                }
            }

        }

        public ZipCodes GetZipByCode(string zipCode)
        {
            PrepList();

            if (_zipcodesByCode.ContainsKey(zipCode) == true)
            {
                return _zipcodesByCode[zipCode];
            }

            return null;
        }

        public void StartUp()
        {
            PrepList();
        }
    }
}
