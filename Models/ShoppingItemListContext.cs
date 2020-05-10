using Microsoft.EntityFrameworkCore;

namespace ShoppingList.Models
{
    public class ShoppingItemListContext : DbContext
    {
        public ShoppingItemListContext(DbContextOptions<ShoppingItemListContext> options)
            : base(options)
        {
        }

        public DbSet<ShoppingItemList> ShoppingItemLists { get; set; }
    }
}