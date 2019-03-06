using AutoMapper;
using eviti.data.tracking;
 
using eviti.data.tracking.PrincipalAccessor;
 
using EvitiContact.Domain.ContactModelDB;
using EvitiContact.Service;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EvitiContact.ContactModel;
using EvitiContact.ApplicationService.ContactModelDB.Services;

namespace NRepository.RazorPages.Pages.MD
{
    public class EditModel : PageModel
    {
        private readonly bool UseSerialization = true;
        private readonly  ContactModelDbContext _context;

        private readonly MasterDetailControllerService _serviceWITHSerialization;
        private readonly MasterDetailControllerServiceNOSerlication _serviceMasterDetailControllerServiceNOSerialization;
        private readonly IMapper _mapper;
        public EditModel( ContactModelDbContext context, MasterDetailControllerService serviceWITHSerialization, IMapper mapper, 
            MasterDetailControllerServiceNOSerlication NOSerializationservice,   IPrincipalAccessor accessor)

        //   public EditModel(EvitiContact.ContactModelDB.ContactModelDbContext context, MasterDetailControllerService service)
        {
            _context = context;
            _serviceMasterDetailControllerServiceNOSerialization = NOSerializationservice;
            Accessor = accessor;
            _serviceWITHSerialization = serviceWITHSerialization;

            _mapper = mapper;
        }

        [BindProperty]
        public MDMasterViewModel MDMaster { get; set; }
        public IPrincipalAccessor Accessor { get; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
     
            if (id == null)
            {
                return NotFound();
            }
            if (UseSerialization)
            {
                MDMaster = _serviceWITHSerialization.Get(id.Value);
            }
            else
            {
                MDMaster = _serviceMasterDetailControllerServiceNOSerialization.Get(id.Value);
            }

            //  MDMaster = await _context.MDMaster.FirstOrDefaultAsync(m => m.MasterId == id);

            if (MDMaster == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            CommandResult2<MDMasterViewModel> result = null;

            if (UseSerialization)
            {
                result = _serviceWITHSerialization.Post(MDMaster);
            }
            else
            {
                result = _serviceMasterDetailControllerServiceNOSerialization.Post(MDMaster);
            }



            if (result.IsValid == false)
            {
                result.ValidationReult.AddToModelState(ModelState, null);
                return Page();
            }
            //_context.Attach(MDMaster).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!MDMasterExists(MDMaster.MasterId))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return RedirectToPage("./Index");
        }

        private bool MDMasterExists(Guid id)
        {
            return _context.MDMaster.Any(e => e.MasterId == id);
        }
    }
}
