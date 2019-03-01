using AutoMapper;
using AutoMapper.QueryableExtensions;
using eviti.data.tracking;
using EvitiContact.ContactModel;
using EvitiContact.Domain.ContactModelDB;
using FluentValidation.Results;
using System;
using System.Linq;
namespace EvitiContact.Service
{
    public class MasterDetailControllerServiceNOSerlication
    {

        private readonly ContactModelDbContext _context;
        private readonly MapAndSerializeGeneric _mapAndSerlizeGeneric;
        private readonly IMapper _mapper;
        private readonly bool IsFormatedArrayOn = true;
        public MasterDetailControllerServiceNOSerlication(ContactModelDbContext context, IMapper mapper, MapAndSerializeGeneric mapAndSerlizeGeneric)
        {
            _context = context;
            _mapper = mapper;
            _mapAndSerlizeGeneric = mapAndSerlizeGeneric;
        }


        public MDMasterViewModel Get()
        {
            Guid mid = new Guid("0FAD3A78-9C71-4622-2E06-08D65F6CDF21");
            return Get(mid);

        }

        public MDMasterViewModel Get(Guid id)
        {
            //-- See https://docs.microsoft.com/en-us/ef/core/querying/related-data and https://stackoverflow.com/questions/45264534/automapper-projectto-ignoring-include
            MDMasterViewModel viewModel = _context.MDMaster
                        .Where(x => x.MasterId == id)
                        // this will trigger an include (of MDDetails) automatically 
                        //because of the mapping profile that has the mddetails in it already   
                        .ProjectTo<MDMasterViewModel>(_mapper.ConfigurationProvider)
                        .FirstOrDefault();


            //  _mapAndSerlizeGeneric.SerializToViewModel(viewModel);

            return viewModel;
        }




        //  [ValidateAntiForgeryToken] //https://docs.microsoft.com/en-us/aspnet/core/security/anti-request-forgery?view=aspnetcore-2.1
        public CommandResult2<MDMasterViewModel> Post(MDMasterViewModel value)
        {

            CommandResult2<MDMasterViewModel> result = new CommandResult2<MDMasterViewModel>();

            MDMasterViewModelValidator validator = new MDMasterViewModelValidator();
            ValidationResult validationResult = validator.Validate(value);

            bool ForceError = false;
            if (value.Name.Trim().ToLower() == "ForceError".ToLower())
            {
                ForceError = true;
            }

            if (value.Name.Contains("Master"))
            {
                ValidationFailure vf1 = new ValidationFailure($"{nameof(MDMaster)}.{nameof(MDMaster.Name)}", "Domain Service Error - Master Name must not contain 'master'");
                validationResult.Errors.Add(vf1);
            }
            if (ForceError)// force Error
            {
                ValidationFailure vf = new ValidationFailure(string.Empty, "Root Level Error");
                validationResult.Errors.Add(vf);

                ValidationFailure vf1 = new ValidationFailure("MDMaster.Name", "Name Forced Error");
                validationResult.Errors.Add(vf1);

                ValidationFailure vf2 = new ValidationFailure("DeptCode", "Department code not valid");
                validationResult.Errors.Add(vf2);
            }


            if (validationResult.IsValid == false)
            {
                //var ex = new  ValidationException(value,result);
                //throw ex;
                result.IsValid = false;
                result.Payload = value;
                result.SetValidationReult(validationResult);
                return result;


            }

            //  MDMasterViewModel deserializedViewModel = JsonConvert.DeserializeObject<MDMasterViewModel>(StringEncryptionProtection.DecryptData(value.OriginalVMObject));


            // repopulate the original item  
            MDMaster dbrecord = new MDMaster();
            //  _mapAndSerlizeGeneric.AutoMapToDBModel(deserializedViewModel, dbrecord);


            // reset the  modified properties tracking items that were triggered by the serialization 
            //    EvitiDBContactBase.ResetTrackingStatic<ContactModelDbContext>(dbrecord);


            // map the new changes to the DB record
            _mapAndSerlizeGeneric.AutoMapToDBModel(value, dbrecord);


            // Deleted Items are setup in the auto mapper profile
            // attach the DB record back into the context.  WHen this happens it will 
            // look into all the modified properties and mark them as changed
            _context.AttachOnly(dbrecord);
            _context.SaveChanges();


            result.Payload = _mapAndSerlizeGeneric.AutoMapToViewModel<MDMaster, MDMasterViewModel>(dbrecord);
            result.Payload.OriginalVMObject = null;
            result.IsValid = true;

            return result;



        }


    }
}
