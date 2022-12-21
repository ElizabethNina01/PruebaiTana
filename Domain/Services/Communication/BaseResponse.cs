

namespace BackendData.Domain.Services.Communication
{
    public abstract class BaseResponse<T>
    {
        public bool Success { get; protected set; }
        public string Message { get; protected set; }
        public T Resource { get; set; }

        public BaseResponse(T resource)
        {
            Success = true;
            Resource = resource;
        }
        public BaseResponse(string message)
        {
            Success = false;
            Message = message;
        }

        
        
    }
}