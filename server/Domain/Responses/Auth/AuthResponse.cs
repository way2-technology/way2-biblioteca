using Domain.Base;

namespace Domain.Responses.Auth
{
    public class AuthResponse : BaseResponse
    {
        public string Key { get; set; }
    }
}