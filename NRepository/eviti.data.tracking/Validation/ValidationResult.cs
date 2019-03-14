//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace eviti.Data.Tracking.Validation
//{
//    public class ValidationResult
//    {
//        public ValidationResult() { }

//        internal ValidationResult(FluentValidation.Results.ValidationResult result)
//        {
//            IsValid = result.IsValid;

//            if(result.Errors?.Count > 0)
//            {
//                Errors = new List<ValidationError>();
//                foreach(var item in result.Errors)
//                {
//                    Errors.Add(new ValidationError(item.PropertyName, item.ErrorMessage, item.ErrorCode, item.AttemptedValue));
//                }
//            }
            
//        }

//        public bool IsValid { get; set; }
//        public IList<ValidationError> Errors { get; set; }
//    }
//}
