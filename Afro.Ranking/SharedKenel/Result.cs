using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedKenel.Errors;

namespace SharedKenel
{
    public class Result
    {
     protected internal Result(bool isSuccess, Error error) 
     {
       if (isSuccess && error != Error.None || !isSuccess && error == Error.None) 
       {
                throw new ArgumentException("Invalid error", nameof(error));
       }
       IsSuccess = isSuccess;
       Error = error;
     }

        public bool IsSuccess { get; }
        public Error Error { get; }
        public static Result Success() 
        {
              return new Result(true, Error.None);
        }
        public static Result<TValue> Success<TValue>(TValue value) => new(value, true,Error.None);

        public static Result Failure(Error error) => new(false, error);
    }
    public class Result<TValue> : Result
    {
        public  Result(TValue value , bool isSuccess, Error error) :base(isSuccess, error) 
        {
        }
    }
}
