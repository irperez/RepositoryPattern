using AutoMapper;
using eviti.data.tracking;
using eviti.data.tracking.PrincipalAccessor;
using EvitiContact.Domain.ContactModelDB;
using EvitiContact.Service;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EvitiContact.ContactModel;

namespace NRepository.RazorPages.Pages.MD
{


    public class EditMediatorModel : PageModel
    {
        private readonly bool UseSerialization = true;
        private readonly ContactModelDbContext _context;

        private readonly MasterDetailControllerService _serviceWITHSerialization;
        private readonly MasterDetailControllerServiceNOSerlication _serviceMasterDetailControllerServiceNOSerialization;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public EditMediatorModel( ContactModelDbContext context, MasterDetailControllerService serviceWITHSerialization, IMapper mapper,
            MasterDetailControllerServiceNOSerlication NOSerializationservice, IPrincipalAccessor accessor,
            IMediator mediator)

        //   public EditModel(EvitiContact.ContactModelDB.ContactModelDbContext context, MasterDetailControllerService service)
        {
            _context = context;
            _serviceMasterDetailControllerServiceNOSerialization = NOSerializationservice;
            Accessor = accessor;
            _serviceWITHSerialization = serviceWITHSerialization;
            _mediator = mediator;
            _mapper = mapper;
        }

        [BindProperty]
        public MDMasterViewModel MDMaster { get; set; }
        public IPrincipalAccessor Accessor { get; }


        public class Query : IRequest<MDMasterViewModel>
        {
            public Guid? Id { get; set; }
            // public int? CourseId { get; set; }


        }


        public class Handler : IRequestHandler<Query, MDMasterViewModel>
        {

            private readonly IConfigurationProvider _configuration;
            private readonly MasterDetailControllerService _serviceWITHSerialization;
            public Handler(MasterDetailControllerService serviceWITHSerialization, IConfigurationProvider configuration)
            {
                _serviceWITHSerialization = serviceWITHSerialization;
                _configuration = configuration;
            }

            public async Task<MDMasterViewModel> Handle(Query message, CancellationToken token)
            {

                var vm = _serviceWITHSerialization.Get(message.Id.Value);
                return vm;


                //var instructors = await _db.Instructors
                //    .Include(i => i.CourseAssignments)
                //    .ThenInclude(c => c.Course)
                //    .OrderBy(i => i.LastName)
                //    .ProjectTo<Model.Instructor>(_configuration)
                //    .ToListAsync(token)
                //    ;

                //// EF Core cannot project child collections w/o Include
                //// See https://github.com/aspnet/EntityFrameworkCore/issues/9128
                ////var instructors = await _db.Instructors
                ////    .OrderBy(i => i.LastName)
                ////    .ProjectToListAsync<Model.Instructor>();

                //var courses = new List<Model.Course>();
                //var enrollments = new List<Model.Enrollment>();

                //if (message.Id != null)
                //{
                //    courses = await _db.CourseAssignments
                //        .Where(ci => ci.InstructorID == message.Id)
                //        .Select(ci => ci.Course)
                //        .ProjectTo<Model.Course>(_configuration)
                //        .ToListAsync(token);
                //}

                //if (message.CourseId != null)
                //{
                //    enrollments = await _db.Enrollments
                //        .Where(x => x.CourseID == message.CourseId)
                //        .ProjectTo<Model.Enrollment>(_configuration)
                //        .ToListAsync(token);
                //}

                //var viewModel = new Model
                //{
                //    Instructors = instructors,
                //    Courses = courses,
                //    Enrollments = enrollments,
                //    InstructorID = message.Id,
                //    CourseID = message.CourseId
                //};

                //return viewModel;
            }
        }

        //public async Task<IActionResult> OnGetAsync(Guid? id)
        //{

        public async Task<IActionResult> OnGetAsync(Query query)
        {


            var Data = await _mediator.Send(query);

            if (query.Id.HasValue == false)
            {
                return NotFound();
            }
            if (UseSerialization)
            {
                MDMaster = _serviceWITHSerialization.Get(query.Id.Value);
            }
            else
            {
                MDMaster = _serviceMasterDetailControllerServiceNOSerialization.Get(query.Id.Value);
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
