using EventApp.Web.Models.Identity;

namespace EventApp.Web.Models.Domain
{
    public class ShoppingCart
    {
        public Guid Id { get; set; }
        public string OwnerId { get; set; }
        public EventsterApplicationUser ShoppingCartOwner { get; set; }
        public virtual ICollection<TicketInShoppingCart> TicketInShoppingCart { get; set; }
    }
}
