using System;
using System.Text.RegularExpressions;
using FluentValidation;



namespace EvitiContact.Domain.ContactModelDB
{


//    //https://github.com/matthewschrager/FluentValidation/blob/master/FluentValidation/Rule.cs
//    public class Rule<T>
//    {
//        //===============================================================
//        public Rule(Func<T, bool> rule, Func<T, string> failureMsg)
//        {
//            Evaluator = rule;
//            FailureMessage = failureMsg;
//        }
//        //===============================================================
//        public virtual String Evaluate(T val, Func<T, string> customFailureMsg = null)
//        {
//            if (!Evaluator(val))
//                return customFailureMsg != null ? customFailureMsg(val) : FailureMessage(val);

//            return null;
//        }
//        //===============================================================
//        public Func<T, bool> Evaluator { get; private set; }
//        //===============================================================
//        public Func<T, string> FailureMessage { get; private set; }
//        //===============================================================
//    }


//    public static partial class Rules
//    {
//        //===============================================================
//        // Regex taken from http://stackoverflow.com/questions/123559/a-comprehensive-regex-for-phone-number-validation. Matches 10-digit phone numbers like 123-456-7890
//        public static Rule<String> IsPhoneNumber =
//            new Rule<string>(
//                x =>
//                Regex.IsMatch(x,
//                              @"(?:(?:(\s*\(?([2-9]1[02-9]|[2-9][02-8]1|[2-9][02-8][02-9])\s*)|([2-9]1[02-9]|[2‌​-9][02-8]1|[2-9][02-8][02-9]))\)?\s*(?:[.-]\s*)?)([2-9]1[02-9]|[2-9][02-9]1|[2-9]‌​[02-9]{2})\s*(?:[.-]\s*)?([0-9]{4})"),
//                x => String.Format("{0} is not a valid phone number.", x));
//        //===============================================================
//        // Regex taken from http://regexlib.com/Search.aspx?k=ssn&AspxAutoDetectCookieSupport=1. Matches hyphenated SSN like 123-45-6789
//        public static Rule<String> IsSocialSecurityNumber = new Rule<string>(x => Regex.IsMatch(x, @"^\d{3}-\d{2}-\d{4}$"), x => String.Format("{0} is not a valid social security number.", x));
//        //===============================================================
//        // Taken from http://stackoverflow.com/questions/2577236/regex-for-zip-code
//        public static Rule<String> IsZipCode = new Rule<string>(x => Regex.IsMatch(x, @"^\d{5}(?:[-\s]\d{4})?$"), x => String.Format("{0} is not a valid zip code.", x));
//        //===============================================================
//        public static Rule<String> IsNotNullOrWhitespace = new Rule<string>(x => !String.IsNullOrWhiteSpace(x), x => String.Format("{0} cannot be null or whitespace."));
//        //===============================================================
//        public static Rule<decimal> IsGreaterThan(decimal val)
//        {
//            return new Rule<decimal>(x => x > val, x => String.Format("{0} is not greater than {1}.", x, val));
//        }
//        //===============================================================
//        public static Rule<decimal> IsGreaterThanOrEqualTo(decimal val)
//        {
//            return new Rule<decimal>(x => x >= val, x => String.Format("{0} is not greater than or equal to {1}.", x, val));
//        }
//        //===============================================================
//        public static Rule<decimal> IsLessThan(decimal val)
//        {
//            return new Rule<decimal>(x => x < val, x => String.Format("{0} is not less than {1}.", x, val));
//        }
//        //===============================================================
//        public static Rule<decimal> IsLessThanOrEqualTo(decimal val)
//        {
//            return new Rule<decimal>(x => x <= val, x => String.Format("{0} is not less than or equal to {1}.", x, val));
//        }
//        //===============================================================
//    }
    public partial class ContactPhoneViewModelValidator : AbstractValidator<ContactPhoneViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactPhoneViewModelValidator"/> class.
        /// </summary>
        public ContactPhoneViewModelValidator()
        {
            #region Generated Validation For ViewModel
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Name).MaximumLength(100);
            RuleFor(p => p.AreaCode).NotEmpty();
            RuleFor(p => p.AreaCode).MaximumLength(5);
            RuleFor(p => p.PhoneNumber).NotEmpty();
            RuleFor(p => p.PhoneNumber).MaximumLength(10);
            RuleFor(p => p.Extension).MaximumLength(10);
            #endregion

 
            RuleFor(x => x.AreaCode).Matches(@"^\d{3}$").WithMessage("Area Code must be 3 digits");
            RuleFor(x => x.PhoneNumber).Matches(@"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}").WithMessage("The phone number must be in the following format xxx-xxxx");

            

        }
    }
    /*
    #region Generated Reference Class
    public partial class ContactPhone
    {
        public Guid GUID { get; set; }
        public Guid ContactGUID { get; set; }
        public string Name { get; set; }
        public string AreaCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Extension { get; set; }
        public bool IsInternational { get; set; }
        public bool IsPrimary { get; set; }
        public int PhoneTypeId { get; set; }

        public Contact ContactGU { get; set; }
    }
    #endregion
    */
}
