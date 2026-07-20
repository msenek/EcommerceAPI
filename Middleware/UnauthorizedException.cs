namespace EcommerceAPI.Middleware
{
    public class UnauthorizedException : AppException
    {
        public UnauthorizedException(string message) 
            : base(message, 401)
        {
        }
    }
}
