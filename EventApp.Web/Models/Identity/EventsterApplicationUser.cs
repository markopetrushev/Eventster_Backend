using EventApp.Web.Models.Domain;
using MessagePack;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace EventApp.Web.Models.Identity
{
    public class EventsterApplicationUser : IdentityUser
    {
        public string? Address { get; set; }
        public string? Password { get; set; }
        public virtual ShoppingCart? UserCart { get; set; }
    }
}
