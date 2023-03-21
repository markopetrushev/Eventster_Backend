namespace EventApp.Web.Models.Domain
{
    public class TicketInShoppingCart
    {
        public Guid EventTicketId { get; set; }
        public EventTicket Ticket { get; set; }
        public Guid ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public int Quantity { get; set; }
    }
}
