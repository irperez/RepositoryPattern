using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using AutoMapper;
using EvitiContact.ContactModel;
using EvitiContact.Domain.ContactModelDB;
using Newtonsoft.Json;

namespace EvitiContact.ApplicationService.ContactModelDB.DBSetup
{
    public class EntityJsonMapper
    {

        public static void SaveZipCodes(ContactModelDbContext context, IMapper mapper)
        {
            var states = context.States.ToArray();
            IEnumerable<StatesViewModel> statesDest = mapper.Map<States[], IEnumerable<StatesViewModel>>(states);
            string json = JsonConvert.SerializeObject(statesDest);
            File.WriteAllText(@"c:\States2.json", json);


            ZipCodes[] zips = context.ZipCodes.ToArray();
            IEnumerable<ZipCodesViewModel> zipDest = mapper.Map<ZipCodes[], IEnumerable<ZipCodesViewModel>>(zips);
            string jsonZips = JsonConvert.SerializeObject(zipDest);
            File.WriteAllText(@"c:\Zips2.json", jsonZips);

            ContactType[] ct = context.ContactType.ToArray();
            IEnumerable<ContactTypeViewModel> ctDest = mapper.Map<ContactType[], IEnumerable<ContactTypeViewModel>>(ct);
            string jsoncontacttypes = JsonConvert.SerializeObject(ctDest);
            File.WriteAllText(@"c:\ContactTypes.json", jsoncontacttypes);
        }




        public static ZipCodes[] GetZipsFromJSON(IMapper mapper)
        {
            string filePath = GetFilePath("SampleFiles", "Zips2.json");

            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new System.Exception("Could not find Zips2 Sample json Sample File");
            }
            string jsonZips = File.ReadAllText(filePath);
            IEnumerable<ZipCodesViewModel> zipVM = JsonConvert.DeserializeObject<IEnumerable<ZipCodesViewModel>>(jsonZips);
            ZipCodes[] zips = mapper.Map<IEnumerable<ZipCodesViewModel>, ZipCodes[]>(zipVM);
            return zips;
        }


        public static string GetFilePath(string dir, string fileName)
        {
            var test3 = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string filePath = Path.Combine(test3, dir, fileName);

            if (File.Exists(filePath) == false)
            {
                filePath = string.Empty;
                var test2 = Directory.GetCurrentDirectory();
                filePath = Path.Combine(test2, dir, fileName);
            }

            if (File.Exists(filePath) == false)
            {
                filePath = string.Empty;
            }
            return filePath;


        }

        public static States[] GetStatesFromJSON(IMapper mapper)
        {

            //string absolute = Path.GetFullPath("../SampleFiles/States2.json");

            string filePath = GetFilePath("SampleFiles", "States2.json");


            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new System.Exception("Could not find States Sample json Sample File");
            }


            string jsonStates = File.ReadAllText(filePath);
            IEnumerable<StatesViewModel> statesVM = JsonConvert.DeserializeObject<IEnumerable<StatesViewModel>>(jsonStates);
            States[] states = mapper.Map<IEnumerable<StatesViewModel>, States[]>(statesVM);

            return states;
        }

        public static ContactType[] GetContactTypeFromJSON(IMapper mapper)
        {
  
            string filePath = GetFilePath("SampleFiles", "ContactTypes.json");
             
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new System.Exception("Could not find ContactTypes Sample json Sample File");
            }
             
            string json = File.ReadAllText(filePath);
            IEnumerable<ContactTypeViewModel> contactTypeVM = JsonConvert.DeserializeObject<IEnumerable<ContactTypeViewModel>>(json);
            ContactType[] contactTypes = mapper.Map<IEnumerable<ContactTypeViewModel>, ContactType[]>(contactTypeVM);

            return contactTypes;
        }
    }
}
