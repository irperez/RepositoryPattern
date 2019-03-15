using FluentValidation;

namespace EvitiContact.Domain.ContactModelDB
{
    public partial class ContactViewModelValidator : AbstractValidator<ContactViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactViewModelValidator"/> class.
        /// </summary>
        public ContactViewModelValidator()
        {
            #region Generated Validation For ViewModel
            RuleFor(p => p.FirstName).MaximumLength(50);
            RuleFor(p => p.LastName).MaximumLength(50);
            RuleFor(p => p.MiddleName).MaximumLength(50);
            RuleFor(p => p.Title).MaximumLength(50);
            //RuleFor(p => p.Credentials).MaximumLength(50);
            //RuleFor(p => p.Prefix).MaximumLength(50);
            //RuleFor(p => p.Suffix).MaximumLength(50);
            RuleFor(p => p.CompanyName).MaximumLength(100);
            //RuleFor(p => p.Version).NotEmpty();
            //RuleFor(p => p.Version).MaximumLength(50);
            //RuleFor(p => p.CreatedBy).NotEmpty();
            //RuleFor(p => p.CreatedBy).MaximumLength(256);
            //RuleFor(p => p.ModifiedBy).NotEmpty();
            //RuleFor(p => p.ModifiedBy).MaximumLength(256);
            //RuleFor(p => p.SSN).MaximumLength(500);
            //RuleFor(p => p.Department).MaximumLength(100);
            #endregion

            //RuleFor(p => p.FirstName).NotEmpty();
            RuleFor(p => p.LastName).NotEmpty();

            RuleFor(p => p.TypeID).NotEmpty();
            RuleFor(p => p.TypeID).GreaterThan(0);

            RuleFor(x => x.LastName).Must((model, userName) => {
                // Determine whether 'userName' is unique.
                string t = string.Empty;

                t = model.LastName;
                if (model.LastName.Contains("test") == false)
                {
                    return false;
                }
                return true;
            }).WithMessage("Your last name does not contain the word 'test'");


            RuleForEach(x => x.ContactEmails).SetValidator(new ContactEmailViewModelValidator());
            RuleForEach(x => x.ContactAddresses).SetValidator(new ContactAddressViewModelValidator());
            RuleForEach(x => x.ContactPhones).SetValidator(new ContactPhoneViewModelValidator());
        }
    }
    /*
    #region Generated Reference Class
    public partial class Contact
    {
        public Contact()
        {
            ContactAddresses = new HashSet<ContactAddress>();
            ContactEmails = new HashSet<ContactEmail>();
            ContactExternalIDs = new HashSet<ContactExternalIDs>();
            ContactPhones = new HashSet<ContactPhone>();
            ContactUsers = new HashSet<ContactUser>();
        }

        public Guid GUID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Title { get; set; }
        public string Credentials { get; set; }
        public string Prefix { get; set; }
        public string Suffix { get; set; }
        public string CompanyName { get; set; }
        public int TypeID { get; set; }
        public bool IsMd { get; set; }
        public string Version { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string SSN { get; set; }
        public bool? IsTest { get; set; }
        public bool IsDemo { get; set; }
        public bool IsDeleted { get; set; }
        public string Department { get; set; }
        public Guid? CreatedByUserID { get; set; }
        public Guid? ModifiedByUserID { get; set; }

        public ContactType Type { get; set; }
        public ICollection<ContactAddress> ContactAddresses { get; set; }
        public ICollection<ContactEmail> ContactEmails { get; set; }
        public ICollection<ContactExternalIDs> ContactExternalIDs { get; set; }
        public ICollection<ContactPhone> ContactPhones { get; set; }
        public ICollection<ContactUser> ContactUsers { get; set; }
    }
    #endregion
    */
}
