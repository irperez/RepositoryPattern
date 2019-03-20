using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EvitiContact.ContactModel;
using EvitiContact.Domain.ContactModelDB;
using EvitiContact.Domain.Services;
using EvitiContact.Service.RepositoryDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NRepository.RazorPages.Infrastructure;

namespace NRepository.RazorPages.Pages.Contacts
{



    public class EditModel : PageModel
    {


        private readonly IMapper _mapper;
        private readonly IUnitOfWorkContactAndShoool _unitOfWork;
        private readonly IStateService _stateService;

        public EditModel(IMapper mapper, IUnitOfWorkContactAndShoool unitOfWork, IStateService stateService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _stateService = stateService;
        }

        [BindProperty]
        public ContactViewModel Contact { get; set; }

        public ContactViewModel DummyContact { get; set; }


        private void AddDummyModel()
        {
            // maybe we can move this into a partial view so we don't need to pollute the model here
            DummyContact = new ContactViewModel
            {
                ContactPhones = new List<ContactPhoneViewModel>()
            };
            DummyContact.ContactPhones.Add(new ContactPhoneViewModel());

            DummyContact.ContactAddresses = new List<ContactAddressViewModel>
            {
                new ContactAddressViewModel()
            };


            DummyContact.ContactEmails = new List<ContactEmailViewModel>
            {
                new ContactEmailViewModel()
            };



        }


        public async Task<IActionResult> OnGetAsync(Guid? id)
        {

            AddDummyModel();


            if (id == null)
            {
                return NotFound();
            }
            var c = _unitOfWork.Contacts.GetContactWithDetails(id.Value);
            Contact = _mapper.Map<ContactViewModel>(c);
            //Contact = await _context.Contact
            //    .Include(c => c.Type).FirstOrDefaultAsync(m => m.GUID == id);
            var test = new SelectList(_stateService.GetAllStates(), "StateCode", "Name");

            ViewData["State"] = new SelectList(_stateService.GetAllStates(), "StateCode", "Name");
            if (Contact == null)
            {
                return NotFound();
            }
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

            //  _context.Attach(Contact).State = EntityState.Modified;

            //try
            //{

            try

            {
                Contact contact = _mapper.Map<Contact>(Contact);
                _unitOfWork.Contacts.AttachOnly(contact);
                _unitOfWork.Commit();

            }
            catch (Exception ex)
            {
                string t = ex.Message;
                throw;
            }

            //  await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!ContactExists(Contact.GUID))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            // return  this. RedirectToActionJson(nameof(Index));

            TempData["Message"] = "Contact Type saved!";
            return this.RedirectToPageJson(nameof(Index));
            //return this.RedirectToPageJson( "Index" );

            //  return RedirectToPage("./Index");
        }

        //private bool ContactExists(Guid id)
        //{
        //    return _context.Contact.Any(e => e.GUID == id);
        //}
    }
}
