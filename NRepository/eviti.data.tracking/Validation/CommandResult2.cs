using FluentValidation.Results;
using System;
namespace eviti.data.tracking
{
    public class CommandResult2<T> where T : class
    {
        public T Payload { get; set; }

        public bool IsValid = true;


        public ValidationResult ValidationReult { get; private set; }


        public void SetValidationReult(ValidationResult value)
        {
            IsValid = value.IsValid;
            ValidationReult = value;
        }

        public CommandResult2()
        {


        }

    }
    public class ValidationException : Exception
    {
        public ValidationException(object payload, ValidationResult result)
        {
            ValidationResult = result;
            Payload = payload;

        }
        public object Payload { get; }
        public ValidationResult ValidationResult { get; set; }

    }



    //public class CommandResult<T> : CommandResult
    //{
    //    private CommandResult(string reason) : base(reason)
    //    { }

    //    private CommandResult(T payload)
    //    {
    //        Payload = payload;
    //    }

    //    public T Payload { get; }

    //    public static new CommandResult<T> Fail(string reason)
    //    {
    //        return new CommandResult<T>(reason);
    //    }

    //    public static CommandResult<T> Success(T payload)
    //    {
    //        return new CommandResult<T>(payload);
    //    }

    //    public static implicit operator bool(CommandResult<T> result)
    //    {
    //        return result.IsSuccess;
    //    }
    //}
    //public class CommandResult
    //{
    //    protected CommandResult() { }


    //    protected CommandResult(string failureReason)
    //    {
    //        FailureReason = failureReason;
    //    }

    //    public string FailureReason { get; }
    //    public bool IsSuccess => string.IsNullOrEmpty(FailureReason);


    //    public static CommandResult Success { get; } = new CommandResult();

    //    //public static CommandResult Fail(string reason) 
    //    //    => new CommandResult(reason);


    //    public static implicit operator bool(CommandResult result)
    //    {
    //        return result.IsSuccess;
    //    }
    //}


}
