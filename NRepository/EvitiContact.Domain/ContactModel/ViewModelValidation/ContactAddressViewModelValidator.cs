using FluentValidation;

namespace EvitiContact.Domain.ContactModelDB
{
    public partial class ContactAddressViewModelValidator : AbstractValidator<ContactAddressViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactAddressViewModelValidator"/> class.
        /// </summary>
        public ContactAddressViewModelValidator()
        {
            #region Generated Validation For ViewModel
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Name).MaximumLength(100);
            RuleFor(p => p.Street).MaximumLength(500);
            RuleFor(p => p.Street2).MaximumLength(500);
            RuleFor(p => p.City).MaximumLength(100);
            RuleFor(p => p.Province).MaximumLength(100);
            RuleFor(p => p.ZipCodeExtension).MaximumLength(20);
            RuleFor(p => p.ZipCode).MaximumLength(5);
            RuleFor(p => p.Country).MaximumLength(100);
            RuleFor(p => p.TimeZone).MaximumLength(200);
            RuleFor(p => p.Longitude).MaximumLength(50);
            RuleFor(p => p.Latitude).MaximumLength(50);
            RuleFor(p => p.ZipCodeString).MaximumLength(5);
            #endregion


            RuleFor(p => p.Street).NotEmpty();
            RuleFor(p => p.City).NotEmpty();
            RuleFor(p => p.ZipCode).NotEmpty();
        }
    }
    /*
    #region Generated Reference Class
    public partial class ContactAddress
    {
        public Guid GUID { get; set; }
        public Guid ContactGUID { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public int? State { get; set; }
        public string Province { get; set; }
        public string ZipCodeExtension { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public bool IsPrimary { get; set; }
        public string TimeZone { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string ZipCodeString { get; set; }

        public Contact ContactGU { get; set; }
        public States StateNavigation { get; set; }
    }
    #endregion
    */
}
