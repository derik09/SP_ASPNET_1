using SP_ASPNET_1.Models;

namespace SP_ASPNET_1.ViewModels
{
    public class UserViewModel 
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
    }
}