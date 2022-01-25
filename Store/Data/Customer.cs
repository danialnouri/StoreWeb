using Microsoft.AspNetCore.Identity;

namespace Store.Data
{
    public class Customer:IdentityUser
    {
        public string CustomerName { get; set; }
        public string CustomerFamily { get; set; }
        
    }
}