using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_koletonm.Models
{
    // Add basket functionality to add functionality to create a cart and pass in the book wanted to purchase. It creates a line item for each book with quantity and price
    // Add method to caluclate the total for the orders
    public class Basket
    {
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();

        public void AddItem(Book book, int qty)
        {
            BasketLineItem line = Items
                .Where(b => b.Book.BookId == book.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                Items.Add(new BasketLineItem
                {
                    Book = book,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }

        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * x.Book.Price);

            return sum;
        }
   
    }

    public class BasketLineItem
    {
        public int LineId { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}
