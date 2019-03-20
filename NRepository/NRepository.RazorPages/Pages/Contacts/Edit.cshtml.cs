using System;
using System.Threading.Tasks;
using AutoMapper;
using eviti.data.tracking;
using eviti.data.tracking.DataContactBase;
using EvitiContact.ContactModel;
using EvitiContact.Domain.ContactModelDB;
using EvitiContact.Domain.Services;
using EvitiContact.Service.RepositoryDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using NRepository.RazorPages.Infrastructure;

namespace NRepository.RazorPages.Pages.Contacts
{



    public class EditModel : PageModel
    {


        private readonly IMapper _mapper;
        private readonly IUnitOfWorkContactAndShoool _unitOfWork;
        private readonly IStateService _stateService;
        private readonly MapAndSerializeGeneric _mapandEncode;

        public EditModel(IMapper mapper, IUnitOfWorkContactAndShoool unitOfWork, IStateService stateService, MapAndSerializeGeneric mapandEncode)
        {

            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _stateService = stateService;
            _mapandEncode = mapandEncode;
        }

        [BindProperty]
        public ContactViewModel ViewModel { get; set; }


        public async Task<IActionResult> OnGetAsync(Guid? id)
        {


            // the dummy template items are now in the ClientTemplates Folder

            if (id == null)
            {
                return NotFound();
            }

            // get the DB model from the Database
            Contact dbRecord = _unitOfWork.Contacts.GetContactWithDetails(id.Value);
            // Map the DB model to the viewModel and it will also snapshot the VM as JSON and put that detail on the OriginalVMObject 
            ViewModel = _mapandEncode.AutoMapToViewModel<Contact, ContactViewModel>(dbRecord);




            if (ViewModel == null)
            {
                return NotFound();
            }

            var test = new SelectList(_stateService.GetAllStates(), "StateCode", "Name");

            ViewData["State"] = new SelectList(_stateService.GetAllStates(), "StateCode", "Name");

            var ctList = _unitOfWork.ContactTypeRepository.GetAll();
            ViewData["TypeID"] = new SelectList(ctList, "ID", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }




            //The idea here is that we pull the serialized state from the OriginalVMObject to use it as a starting tracking point and then merge in the viewModel changes
            // First, Deserialize the view model.
            // Then repopulate the original DB item by mapping the VM back into the DB item
            // reset the tracking on the DB item 
            // then map the current view model (the one the user edited) over the DB item
            // attach that DB item to the DB context as it will have only the changed items in it's tracking state
            // Save the DB item.

            ContactViewModel deserializedViewModel = JsonConvert.DeserializeObject<ContactViewModel>(StringEncryptionProtection.DecryptData(ViewModel.OriginalVMObject));


            // repopulate the original item  
            Contact dbrecord = new Contact();
            _mapandEncode.AutoMapToDBModel(deserializedViewModel, dbrecord);


            // reset the  modified properties tracking items that were triggered by the serialization 
            EvitiDBContactBase.ResetTrackingStatic<ContactModelDbContext>(dbrecord);


            // map the new viewmodel changes to the DB record
            _mapandEncode.AutoMapToDBModel(ViewModel, dbrecord);


            try
            {

                _unitOfWork.Contacts.AttachOnly(dbrecord);
                _unitOfWork.Commit();

            }
            catch (Exception ex)
            {
                string t = ex.Message;
                throw;
            }



            // return  this. RedirectToActionJson(nameof(Index));
            // Add a temp massage for the list page
            TempData["Message"] = "Contact Type saved!";

            // build a redirection for the javascript ajax request. 
            return this.RedirectToPageJson(nameof(Index));
            //return this.RedirectToPageJson( "Index" );

            //  return RedirectToPage("./Index");
        }

    }
}
