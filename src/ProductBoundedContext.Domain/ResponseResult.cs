namespace ProductBoundedContext.Domain
{
    public class ResponseResult
    {
        public bool Success { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public object Validation { get; set; }

        public static ResponseResult Succeeded(int statusCode = 0, string message = null, object validation = null)
        {
            return new ResponseResult()
            {
                Success = true,
                StatusCode = statusCode,
                Message = message,
                Validation = validation
            };
        }
        public static ResponseResult Failed(int statusCode = 0, string message = null, object validation = null)
        {
            return new ResponseResult()
            {
                Success = false,
                StatusCode = statusCode,
                Message = message,
                Validation = validation
            };
        }
    }

    public class ResponseResult<TResult> : ResponseResult
     where TResult : class
    {
        public TResult Value { get; set; }

        public static ResponseResult<TResult> Succeeded(TResult value, int statusCode = 0, string message = null, object validation = null)
        {
            return new ResponseResult<TResult>()
            {
                Success = true,
                Value = value,
                StatusCode = statusCode,
                Message = message,
                Validation = validation
            };
        }
        public new static ResponseResult<TResult> Succeeded(int statusCode = 0, string message = null, object validation = null)
        {
            return Succeeded(default(TResult), statusCode, message, validation);
        }

        public static ResponseResult<TResult> Failed(TResult value, int statusCode = 0, string message = null, object validation = null)
        {
            return new ResponseResult<TResult>()
            {
                Success = false,
                Value = value,
                StatusCode = statusCode,
                Message = message,
                Validation = validation
            };
        }

        public new static ResponseResult<TResult> Failed(int statusCode = 0, string message = null, object validation = null)
        {
            return Failed(default(TResult), statusCode, message, validation);
        }

    }
}