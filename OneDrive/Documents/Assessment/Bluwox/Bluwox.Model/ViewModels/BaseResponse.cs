namespace Bluwox.Model.ViewModels
{
    public class BaseResponse
    {
        public bool Status { get; set; }
        public string? Message { get; set; }

        public static BaseResponse Success(string? message = null)
        {
            return new BaseResponse()
            {
                Status = true,
                Message = message ?? "Request was Successful",
            };
        }

        public static BaseResponse Failure(string? message = null)
        {
            return new BaseResponse()
            {
                Message = message ?? "Request failed",
            };
        }
    }

    public class BaseResponse<T> : BaseResponse
    {
        public T Data { get; set; }

        public static BaseResponse<T> Success(T data, string? message = null)
        {
            return new BaseResponse<T>()
            {
                Status = true,
                Message = message ?? "Request was Successful",
                Data = data
            };
        }

        public static BaseResponse<T> Failure(T data, string message = null)
        {
            return new BaseResponse<T>()
            {
                Message = message ?? "Request was not completed",
                Data = data
            };
        }
    }

    public class PageBaseResponse<T> : BaseResponse
    {
        public IEnumerable<T> Data { get; set; }
        public int CurrentPage { get; set; }
        public bool HasNextPage { get; set; }
        public int TotalRecordInStore { get; set; }

        public static PageBaseResponse<T> Success(IEnumerable<T> data, string? message = null, int currentPage = 0, bool hasNext = false, int totalRecord = 0)
        {
            return new PageBaseResponse<T>()
            {
                Status = true,
                Message = message ?? "Request was Successful",
                Data = data,
                CurrentPage = currentPage,
                HasNextPage = hasNext,
                TotalRecordInStore = totalRecord
            };
        }

        public static PageBaseResponse<T> Failure(IEnumerable<T> data, string? message = null)
        {
            return new PageBaseResponse<T>()
            {
                Message = message ?? "Request was not completed",
                Data = data,
                CurrentPage = 0,
                TotalRecordInStore = 0
            };
        }
    }
}
