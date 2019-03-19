using EvitiContact.Domain.Services;
using FluentValidation;

namespace EvitiContact.Domain.ContactModelDB
{
    public partial class ContactAddressViewModelValidator : AbstractValidator<ContactAddressViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactAddressViewModelValidator"/> class.
        /// </summary>
        public ContactAddressViewModelValidator(IStateService myStateService)
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
            //RuleFor(p => p.ZipCode).NotEmpty().InclusiveBetween(10000, 99999);
            //RuleFor(p => p.ZipCode).InclusiveBetween(10000, 99999);
            //int i = 0;
            //// RuleFor(x => x.ZipCode).Length(5, 5).Must(x => int.TryParse(x, out i));
            ////RuleFor(x => x.ZipCode).Length(5, 5).WithMessage("Zip Code must be 5 digits");
            //var test = i;
             RuleFor(x => x.ZipCode).Matches(@"^\d{5}$").WithMessage("Zip Code must be 5 digits");


            RuleFor(x => x.ZipCode).Must((model, zipcode) =>
            {
                
                string t = string.Empty;
                if (string.IsNullOrWhiteSpace(model.ZipCode) == true)
                {
                    return false;
                }

                var testZip = myStateService.GetZipByCode(zipcode);
                if (testZip == null)
                {
                    return false;
                }

                if (testZip.StateCode != model.State)
                {
                    return false;
                }
                var stateCode = model.State;


                return true;
            }).WithMessage("The zip code is not valid for the selected State.");


            //RuleFor(x => x.ZipCode).Must((model, zipcode) =>
            //{

            //    string t = string.Empty;
            //    if (string.IsNullOrWhiteSpace(model.ZipCode) == true)
            //    {
            //        return false;
            //    }
            //    myStateService.GetAllStates.w
            //    var testZip = myStateService.GetZipByCode(zipcode);
            //    if (testZip == null)
            //    {
            //        return false;
            //    }
            //    var stateCode = model.State;


            //    return true;
            //}).WithMessage("The zip code is not valid.");

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
