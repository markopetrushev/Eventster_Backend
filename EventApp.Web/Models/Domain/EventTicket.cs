using System.ComponentModel.DataAnnotations;

namespace EventApp.Web.Models.Domain
{
    public class EventTicket
    {
        public Guid Id { get; set; }
        [Required]
        public string EventName { get; set; }
        [Required]
        public DateTime? StartDate { get; set; }
        [Required]
        public DateTime? EndDate  { get; set; }
        [Required]
        public string Details { get; set; }
        [Required]
        public string CoverImage { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public double? Rating { get; set; }
        [Required]
        public EventType? Type { get; set; }
        [Required]
        public virtual ICollection<TicketInShoppingCart>? TicketInShoppingCart { get; set; }
    }
}
