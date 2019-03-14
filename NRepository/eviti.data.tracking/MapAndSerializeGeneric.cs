using AutoMapper;
using eviti.data.tracking.Interfaces;
using Newtonsoft.Json;


namespace eviti.data.tracking
{
    public class MapAndSerializeGeneric
    {
        private IMapper _mapper;

        public MapAndSerializeGeneric(IMapper mapper)
        {
            _mapper = mapper;
        }

        //public outputViewModel AutoMapToViewModelWithOrginalValue<inputDBModel, outputViewModel>(inputDBModel dbModel) where outputViewModel : class, ITrackOrginalValue, ITrackOrginalDBValue, new()
        //{


        //    string dbModelJson = JsonConvert.SerializeObject(dbModel, new JsonSerializerSettings()
        //    {
        //        // PreserveReferencesHandling = PreserveReferencesHandling.Objects,
        //        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
        //        Formatting = Formatting.Indented
        //    });


        //    var viewModel = new outputViewModel();
        //    _mapper.Map(dbModel, viewModel);
        //    string viewModelJson = JsonConvert.SerializeObject(viewModel);
        //    viewModel.OriginalVMObject = StringEncryptionProtection.EncryptData(viewModelJson);
        //    viewModel.OriginalObject = StringEncryptionProtection.EncryptData(dbModelJson);

        //    return viewModel;

        //}


        public outputViewModel AutoMapToViewModel<inputDBModel, outputViewModel>(inputDBModel dbModel) where outputViewModel : class, ITrackOrginalValue, new()
        {


            //string dbModelJson = JsonConvert.SerializeObject(dbModel, new JsonSerializerSettings()
            //{
            //    // PreserveReferencesHandling = PreserveReferencesHandling.Objects,
            //    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            //    Formatting = Formatting.Indented
            //});


            var viewModel = new outputViewModel();
            _mapper.Map(dbModel, viewModel);
            string viewModelJson = JsonConvert.SerializeObject(viewModel);
            viewModel.OriginalVMObject = StringEncryptionProtection.EncryptData(viewModelJson);


            return viewModel;

        }


        public void SerializToViewModel(ITrackOrginalValue viewModel)
        {
            string viewModelJson = JsonConvert.SerializeObject(viewModel);


            viewModel.OriginalVMObject = StringEncryptionProtection.EncryptData(viewModelJson);
        }


        public outputDBModell AutoMapToDBModel<inputViewModel, outputDBModell>(inputViewModel sourceViewModel, outputDBModell destDB) where outputDBModell : class //, new()
        {
            _mapper.Map(sourceViewModel, destDB);
            return destDB;

        }

    }
}
