using AutoMapper;
using EvitiContact.ContactModel;
using EvitiContact.Domain.ContactModelDB;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace EvitiContact.Service.ContactModelDB
{
    public class EntityJsonMapper
    {

        public void SaveZipCodes(ContactModelDbContext context, IMapper mapper)
        {
            var states = context.States.ToArray();
            IEnumerable<StatesViewModel> statesDest = mapper.Map<States[], IEnumerable<StatesViewModel>>(states);
            string json = JsonConvert.SerializeObject(statesDest);
            File.WriteAllText(@"c:\States2.json", json);


            ZipCodes[] zips = context.ZipCodes.ToArray();
            IEnumerable<ZipCodesViewModel> zipDest = mapper.Map<ZipCodes[], IEnumerable<ZipCodesViewModel>>(zips);
            string jsonZips = JsonConvert.SerializeObject(zipDest);
            File.WriteAllText(@"c:\Zips2.json", jsonZips);
        }



        public static ZipCodes[] GetZipsFromJSON(IMapper mapper)
        {

            var test3 = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            var file = Path.Combine(test3, "SampleFiles", "Zips2.json");

            string jsonZips = File.ReadAllText(file);
            IEnumerable<ZipCodesViewModel> zipVM = JsonConvert.DeserializeObject<IEnumerable<ZipCodesViewModel>>(jsonZips);
            ZipCodes[] zips = mapper.Map<IEnumerable<ZipCodesViewModel>, ZipCodes[]>(zipVM);
            return zips;
        }
        public static States[] GetStatesFromJSON(IMapper mapper)
        {

            //string absolute = Path.GetFullPath("../SampleFiles/States2.json");

            var test3 = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            var file = Path.Combine(test3, "SampleFiles", "States2.json");

            string jsonStates = File.ReadAllText(file);
            IEnumerable<StatesViewModel> statesVM = JsonConvert.DeserializeObject<IEnumerable<StatesViewModel>>(jsonStates);
            States[] states = mapper.Map<IEnumerable<StatesViewModel>, States[]>(statesVM);

            return states;
        }
    }
}
