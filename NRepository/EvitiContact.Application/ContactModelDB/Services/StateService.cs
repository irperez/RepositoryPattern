using System.Collections.Generic;
using System.Linq;
using EvitiContact.ContactModel;
using EvitiContact.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EvitiContact.ApplicationService.ContactModelDB.Services
{

    //using System;
    //using System.Collections.Generic;
    //using CachedRepoSample.Data.Models;
    //using Microsoft.Extensions.Caching.Memory;

    //namespace CachedRepoSample.Data.Repositories
    //{
    //    public class CachedAuthorRepositoryDecorator : IReadOnlyRepository<Author>
    //    {
    //        private readonly AuthorRepository _repository;
    //        private readonly IMemoryCache _cache;
    //        private const string MyModelCacheKey = "Authors";
    //        private MemoryCacheEntryOptions cacheOptions;

    //        // alternatively use IDistributedCache if you use redis and multiple services
    //        public CachedAuthorRepositoryDecorator(AuthorRepository repository,
    //            IMemoryCache cache)
    //        {
    //            _repository = repository;
    //            _cache = cache;

    //            // 5 second cache
    //            cacheOptions = new MemoryCacheEntryOptions()
    //                .SetAbsoluteExpiration(relative: TimeSpan.FromSeconds(Constants.DEFAULT_CACHE_SECONDS));
    //        }

    //        public Author GetById(int id)
    //        {
    //            string key = MyModelCacheKey + "-" + id;

    //            return _cache.GetOrCreate(key, entry =>
    //            {
    //                entry.SetOptions(cacheOptions);
    //                return _repository.GetById(id);
    //            });
    //        }

    //        public List<Author> List()
    //        {
    //            return _cache.GetOrCreate(MyModelCacheKey, entry =>
    //            {
    //                entry.SetOptions(cacheOptions);
    //                return _repository.List();
    //            });
    //        }
    //    }
    //}

    public partial class StateService : IStateService
    {


        // private readonly ContactModelDbContext ctx;
        private readonly IServiceScopeFactory _services;
        private List<States> _list;

        public Dictionary<string, States> _dictByAppriviation { get; private set; }

        public Dictionary<string, States> _dictByName { get; private set; }
        public Dictionary<string, ZipCodes> _zipcodesByCode { get; private set; }

        //public StateService(ContactModelDbContext ctx)
        //{
        //    this.ctx = ctx;
        //}
        public StateService(IServiceScopeFactory services)
        {
            _services = services;

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

                        using (var scope = _services.CreateScope())
                        {
                            var ctx = scope.ServiceProvider.GetRequiredService<ContactModelDbContext>();



                            _list = ctx.States.Include(x => x.ZipCodes).AsNoTracking().ToList();
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

        public List<States> GetAllStates()
        {
            PrepList();
            return _list;  // this should be changed to a I read only list but i forget the sysntax 
        }
    }
}
