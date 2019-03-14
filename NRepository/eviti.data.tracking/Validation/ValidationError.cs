//namespace eviti.Data.Tracking.Validation
//{
//    public class ValidationError
//    {
//        public ValidationError(string propertyName, string errorMessage)
//        {
//            PropertyName = propertyName;
//            ErrorMessage = errorMessage;
//        }

//        public ValidationError(string propertyName, string errorMessage, string errorCode):this(propertyName, errorMessage)
//        {
//            ErrorCode = errorCode;
//        }

//        public ValidationError(string propertyName, string errorMessage, string errorCode, object attemptedValue) : this(propertyName, errorMessage, errorCode)
//        {
//            AttemptedValue = attemptedValue;
//        }


//        public string PropertyName { get; set; }
//        public string ErrorMessage { get; set; }
//        public string ErrorCode { get; set; }
//        public object AttemptedValue { get; set; }
//    }
//}
