using EventApp.Web.Models.Domain;
using EventApp.Web.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EventApp.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<EventsterApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EventTicket> EventTickets { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts{ get; set; }
        public virtual DbSet<TicketInShoppingCart> TicketInShoppingCarts{ get; set; }
        public virtual DbSet<EventsterApplicationUser> EventsterApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<EventsterApplicationUser>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<EventTicket>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<ShoppingCart>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<TicketInShoppingCart>()
                .HasKey(x => new { x.EventTicketId, x.ShoppingCartId });

            builder.Entity<TicketInShoppingCart>()
                .HasOne(x => x.Ticket)
                .WithMany(x => x.TicketInShoppingCart)
                .HasForeignKey(x => x.ShoppingCartId);

            builder.Entity<TicketInShoppingCart>()
                .HasOne(x => x.ShoppingCart)
                .WithMany(x => x.TicketInShoppingCart)
                .HasForeignKey(x => x.EventTicketId);

            builder.Entity<ShoppingCart>()
                .HasOne<EventsterApplicationUser>(x => x.ShoppingCartOwner)
                .WithOne(x => x.UserCart)
                .HasForeignKey<ShoppingCart>(x => x.OwnerId);

        }
    }
}