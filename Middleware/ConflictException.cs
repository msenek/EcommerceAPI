namespace EcommerceAPI.Middleware
{
    public class ConflictException : AppException
    {
        public ConflictException(string message) : base(message, 400)
        {
        }
    }
}
