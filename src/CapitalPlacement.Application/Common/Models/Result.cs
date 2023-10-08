using System.Net;

namespace CapitalPlacement.Application.Common.Models
{
    public class Result
    {
        internal Result(bool succeeded, IEnumerable<string> errors, HttpStatusCode? errorCode = null)
        {
            Succeeded = succeeded;
            Errors = errors.ToArray();
            ErrorCode = errorCode;
            Message = errors.FirstOrDefault() ?? "error occured";
        }

        public string Message { get; set; }
        public bool Succeeded { get; set; }

        public string[] Errors { get; set; }

        public HttpStatusCode? ErrorCode { get; set; }

        public static Result Failure(IEnumerable<string> errors, HttpStatusCode? errorCode = null)
        {
            return new Result(false, errors, errorCode);
        }
        public static Result Failure(string message, HttpStatusCode? errorCode = null)
        {

            var errors = new[] { message };

            var result = new Result(false, errors)
            {
                Errors = new[] { message },
                Message = message,
                ErrorCode = errorCode
            };
            return result;
        }
        public static Result Success(string message = "success")
        {
            var result = new Result(true, Array.Empty<string>()) { Message = message, };
            return result;
        }


        public static Result Failure(IEnumerable<string> errors, string message, HttpStatusCode? errorCode = null)
        {
            return new Result(false, errors, errorCode) { Message = message };
        }
    }

    public class Result<T> : Result
    {
        internal Result(bool succeeded, string?[] errors, HttpStatusCode? errorCode = null) : base(succeeded, errors, errorCode)
        {
        }


        public T Data { get; set; }
        public static Result<T> Success(T data, string message = "success", HttpStatusCode? errorCode = null)
        {
            var result = new Result<T>(true, Array.Empty<string>(), errorCode) { Data = data, Message = message, };
            return result;
        }

        public static Result<T> Failure(string?[] errors, string message, HttpStatusCode? errorCode = null)
        {
            if (errors == null)
            {
                errors = new[] { "" };
            }
            var result = new Result<T>(false, errors, errorCode) { Message = message };
            return result;
        }

        public static Result<T> Failure(string?[] errors, HttpStatusCode? errorCode = null)
        {
            return new Result<T>(false, errors, errorCode);
        }

        public static Result<T> Failure(string message, HttpStatusCode? errorCode = null)
        {

            var errors = new[] { message };

            var result = new Result<T>(false, errors, errorCode) { Message = message };
            return result;
        }
    }
}
