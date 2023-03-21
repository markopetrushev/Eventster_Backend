using EventApp.Web.Models.Domain;

namespace EventApp.Web.Models.DTO
{
    public class AddToShoppingCartDto
    {
        public EventTicket SelectedTicket { get; set; }
        public Guid EventId { get; set; }
        public int Quantity { get; set; }
    }
}
