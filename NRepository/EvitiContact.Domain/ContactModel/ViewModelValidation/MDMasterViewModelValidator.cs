using FluentValidation;

using FluentValidation.Results;
using FluentValidation.Validators;
namespace EvitiContact.Domain.ContactModelDB
{
    public partial class MDMasterViewModelValidator : AbstractValidator<MDMasterViewModel>
    {
        //https://www.jerriepelser.com/blog/remote-client-side-validation-with-fluentvalidation/
        //private readonly Func<IApplicationDbContext> dbContextFunction;
        /// <summary>
        /// Initializes a new instance of the <see cref="MDMasterViewModelValidator"/> class.
        /// </summary>
        public MDMasterViewModelValidator()
        {
            #region Generated Validation For ViewModel
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Name).MaximumLength(50);
            //RuleFor(p => p.Version).NotEmpty();
            //RuleFor(p => p.Version).MaximumLength(50);
            //RuleFor(p => p.CreatedBy).NotEmpty();
            //RuleFor(p => p.CreatedBy).MaximumLength(256);
            //RuleFor(p => p.ModifiedBy).NotEmpty();
            //RuleFor(p => p.ModifiedBy).MaximumLength(256);
            //RuleFor(p => p.RowVersion).NotEmpty();
            #endregion
            RuleFor(p => p.RowVersion).NotEmpty();
            RuleFor(p => p.Name).Must(BeValidName);
            RuleFor(x => x).Custom(OtherCommentsMustBeValid);
            RuleFor(x => x.Name).Must(BeAValidPostcode).WithMessage("View Model Error - It looks like you set the name equal to ForceError2");


            RuleForEach(model => model.MDDetails).SetValidator(new MDDetailViewModelValidator())
            .WithState(order => order.MDDetails); // pass order info into state;   
        }

        private void OtherCommentsMustBeValid(MDMasterViewModel arg1, CustomContext arg2)
        {
            //  throw new NotImplementedException();
        }

        //https://www.codeproject.com/Articles/1178380/How-To-Master-Complex-Scenarios-Using-Fluent-Valid

        //https://stackoverflow.com/questions/9380010/unobtrusive-client-validation-using-fluentvalidation-and-asp-net-mvc-lessthanore
        //https://www.codeproject.com/Articles/1175553/How-To-Easily-Set-Up-Fluent-Validation-With-Autofa
        private static bool BeValidName(MDMasterViewModel model, string comments)
        {
            if (model.NoNameNeeded)
            { return true; }
            return comments != null && comments.Length <= 50;
        }
        private bool BeAValidPostcode(string IsForceError2)
        {
            if (IsForceError2.Equals("ForceError2"))
            {
                return false;
            }
            return true;
            // custom postcode validating logic goes here
        }

        private static ValidationFailure OtherCommentsMustBeValid(MDMasterViewModel model)
        {
            if (model.NoNameNeeded)
            {
                return null;
            }

            return model.Name != null && model.OtherComments.Length >= 50 ? null :
                new ValidationFailure("OtherComments", "Please enter at least 50 characters of comments.    If you have nothing to say, please check the checkbox.");
        }

        /*
        #region Generated Reference Class
        public partial class MDMaster
        {
            public MDMaster()
            {
                MDDetails = new HashSet<MDDetail>();
            }

            public Guid MasterId { get; set; }
            public string Name { get; set; }
            public string Version { get; set; }
            public DateTime CreatedDate { get; set; }
            public string CreatedBy { get; set; }
            public DateTime ModifiedDate { get; set; }
            public string ModifiedBy { get; set; }
            public byte[] RowVersion { get; set; }

            public ICollection<MDDetail> MDDetails { get; set; }
        }
        #endregion
        */
    }
    /*
    #region Generated Reference Class
    public partial class MDMaster
    {
        public MDMaster()
        {
            MDDetails = new HashSet<MDDetail>();
        }

        public Guid MasterId { get; set; }
        public string Name { get; set; }
        public decimal? TotalDollars { get; set; }
        public decimal NewRequired { get; set; }
        public string Version { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public byte[] RowVersion { get; set; }

        public ICollection<MDDetail> MDDetails { get; set; }
    }
    #endregion
    */
}
