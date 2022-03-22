using ViewModel.Enums;

namespace ViewModel
{
    // в базе не храним
    public class LoginResult
    {
        public bool Success { get; set; }

        public LoginError ErrorCode { get; set; }

        public string Token { get; set; }
    }
}
