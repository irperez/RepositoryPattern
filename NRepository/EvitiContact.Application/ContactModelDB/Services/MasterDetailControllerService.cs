using System;
using System.Linq;
using AutoMapper;
using eviti.data.tracking;
using eviti.data.tracking.DataContactBase;
using EvitiContact.ContactModel;
using EvitiContact.Domain.ContactModelDB;
using EvitiContact.Service.RepositoryDB;
using FluentValidation.Results;
using Newtonsoft.Json;

namespace EvitiContact.ApplicationService.ContactModelDB.Services
{

    /// <summary>
    /// Added root level validation to the sample
    /// </summary>
    public class MasterDetailControllerService
    {

        private readonly ContactModelDbContext _context;
        private readonly MapAndSerializeGeneric _mapAndSerlizeGeneric;
        private readonly IUnitOfWorkContactAndShoool unitOfWork;
        private readonly IMapper _mapper;
        private readonly bool IsFormatedArrayOn = true;
        public MasterDetailControllerService(ContactModelDbContext context, IMapper mapper, MapAndSerializeGeneric mapAndSerlizeGeneric, IUnitOfWorkContactAndShoool unitOfWork)
        {
            _context = context;
            _mapper = mapper;
            _mapAndSerlizeGeneric = mapAndSerlizeGeneric;
            this.unitOfWork = unitOfWork;
        }


        public MDMasterViewModel Get()
        {
            var mid = _context.MDMaster.OrderByDescending(x => x.CreatedDate).FirstOrDefault().MasterId;
            return Get(mid);

        }

        public MDMasterViewModel Get(Guid id)
        {
            //-- See https://docs.microsoft.com/en-us/ef/core/querying/related-data and https://stackoverflow.com/questions/45264534/automapper-projectto-ignoring-include
            //MDMasterViewModel viewModel = _context.MDMaster
            //            .Where(x => x.MasterId == id)
            //            // this will trigger an include (of MDDetails) automatically 
            //            //because of the mapping profile that has the mddetails in it already   
            //            .ProjectTo<MDMasterViewModel>(_mapper.ConfigurationProvider)
            //            .FirstOrDefault();

            MDMasterViewModel viewModel = unitOfWork.MDDetails.GetVM(id);

            _mapAndSerlizeGeneric.SerializToViewModel(viewModel);

            return viewModel;
        }




        //  [ValidateAntiForgeryToken] //https://docs.microsoft.com/en-us/aspnet/core/security/anti-request-forgery?view=aspnetcore-2.1
        public CommandResult2<MDMasterViewModel> Post(MDMasterViewModel value)
        {

            CommandResult2<MDMasterViewModel> result = new CommandResult2<MDMasterViewModel>();

            MDMasterViewModelValidator validator = new MDMasterViewModelValidator();
            ValidationResult validationResult = validator.Validate(value);

        
            if (value.Name.Trim().ToLower() == "Master".ToLower())
            {
                ValidationFailure vf1 = new ValidationFailure($"{nameof(MDMaster)}.{nameof(MDMaster.Name)}", "Domain Service Error - Master Name must not contain 'master' - HAS prefix");
                validationResult.Errors.Add(vf1);
                // root level items should not get a key prefix like 'Master.Name' and should be just 'Name'
                ValidationFailure vf2 = new ValidationFailure($"{nameof(MDMaster.Name)}", "Domain Service Error - Master Name must not contain 'master' - set with No prefix");
                validationResult.Errors.Add(vf2);
            }

            bool ForceError = false;
            if (value.Name.Trim().ToLower() == "ForceError".ToLower())
            {
                ForceError = true;
            }

            if (ForceError)// force Error
            {
                ValidationFailure vf = new ValidationFailure(string.Empty, "Root Level Error");
                validationResult.Errors.Add(vf);

                ValidationFailure vf1 = new ValidationFailure("MDMaster.Name", "Name Forced Error");
                validationResult.Errors.Add(vf1);

                ValidationFailure vf2 = new ValidationFailure("DeptCode", "Department code not valid");
                validationResult.Errors.Add(vf2);


                ValidationFailure vf3 = new ValidationFailure("MDMaster.Name", "Name Forced Error1");
                validationResult.Errors.Add(vf3);

                ValidationFailure vf4 = new ValidationFailure("Nametest", "Name Forced Error2");
                validationResult.Errors.Add(vf4);


                ValidationFailure vf5 = new ValidationFailure("Name", "Name Forced Error3");
                validationResult.Errors.Add(vf5);
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

            MDMasterViewModel deserializedViewModel = JsonConvert.DeserializeObject<MDMasterViewModel>(StringEncryptionProtection.DecryptData(value.OriginalVMObject));


            // repopulate the original item  
            MDMaster dbrecord = MDMaster.GetNewMasterRecord();
            _mapAndSerlizeGeneric.AutoMapToDBModel(deserializedViewModel, dbrecord);


            // reset the  modified properties tracking items that were triggered by the serialization 
            EvitiDBContactBase.ResetTrackingStatic<ContactModelDbContext>(dbrecord);


            // map the new changes to the DB record
            _mapAndSerlizeGeneric.AutoMapToDBModel(value, dbrecord);


            // Deleted Items are setup in the auto mapper profile
            // attach the DB record back into the context.  WHen this happens it will 
            // look into all the modified properties and mark them as changed
            //_context.AttachOnly(dbrecord);
            //_context.SaveChanges();
            unitOfWork.MDDetails.AttachOnly(dbrecord);
            unitOfWork.Commit();


            result.Payload = _mapAndSerlizeGeneric.AutoMapToViewModel<MDMaster, MDMasterViewModel>(dbrecord);
            result.IsValid = true;

            return result;



        }


    }




}
