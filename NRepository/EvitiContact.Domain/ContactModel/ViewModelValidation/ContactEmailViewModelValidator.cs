using FluentValidation;

namespace EvitiContact.Domain.ContactModelDB
{
    public partial class ContactEmailViewModelValidator : AbstractValidator<ContactEmailViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactEmailViewModelValidator"/> class.
        /// </summary>
        public ContactEmailViewModelValidator()
        {
            #region Generated Validation For ViewModel
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Name).MaximumLength(100);
            RuleFor(p => p.EmailAddress).NotEmpty();
            RuleFor(p => p.EmailAddress).MaximumLength(200);
            #endregion
            RuleFor(p => p.Name).MinimumLength(10).WithMessage("your ContactEmail Name is too short");

            RuleFor(p => p.EmailAddress).EmailAddress();

            RuleFor(x => x.EmailAddress).Must((model, userName) => {
                // Determine whether 'userName' is unique.
                string t = string.Empty;

                t = model.Name;
                if (model.Name.Contains("test")==false)
                {
                    return false;
                }
                return true;
            }).WithMessage("Your EmailAddress does not contain the word 'test'");
          


            //RuleFor(p => p.Name).CreditCard();
        }

    }
    /*
    #region Generated Reference Class
    public partial class ContactEmail
    {
        public Guid Guid { get; set; }
        public Guid ContactGuid { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public bool IsPrimary { get; set; }

        public Contact ContactGu { get; set; }
    }
    #endregion
    */
}
