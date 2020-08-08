namespace MVCGram.Application
{
    public class ApplicationResponse
    {
        protected ApplicationResponse()
        {
        }

        public bool IsSuccess { get; protected set; }

        public string Message { get; protected set; }

        public static ApplicationResponse Success(string message = null)
        {
            return new ApplicationResponse
            {
                IsSuccess = true,
                Message = message
            };
        }

        public static ApplicationResponse Failure(string message = null)
        {
            return new ApplicationResponse
            {
                IsSuccess = false,
                Message = message
            };
        }
    }

    public class ApplicationResponse<TData> : ApplicationResponse
    {
        private ApplicationResponse()
        {
        }

        public TData Data { get; private set; }

        public static ApplicationResponse<TData> Success(TData data, string message = null)
        {
            return new ApplicationResponse<TData>
            {
                Data = data,
                IsSuccess = true,
                Message = message
            };
        }

        public new static ApplicationResponse<TData> Failure(string message = null)
        {
            return new ApplicationResponse<TData>
            {
                IsSuccess = false,
                Message = message
            };
        }
    }
}
