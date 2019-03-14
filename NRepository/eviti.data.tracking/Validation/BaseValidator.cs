//using FluentValidation;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace eviti.Data.Tracking.Validation
//{
//    public abstract class BaseValidator<T> : AbstractValidator<T> where T : new()
//    {


//        public new bool Validate (T instance)
//        {
//            var results = base.Validate(instance);
//            var resultObj = new ValidationResult(results);
           
//            return resultObj.IsValid;
//        }

//        public IList<ValidationError> Errors { get; set; }
//    }
//}
