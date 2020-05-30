namespace Core.Utilities.Results
{
    public class ErorrsDataResult<T> : DataResult<T>
    {
        public ErorrsDataResult(T data, bool success, string message) : base(data, success: false, message)
        {
        }

        public ErorrsDataResult(T data) : base(data, success: false)
        {
        }

        public ErorrsDataResult(string message) : base(default, success: false, message)
        {
        }

        public ErorrsDataResult() : base(default, success: false)
        {
        }
    }
}
