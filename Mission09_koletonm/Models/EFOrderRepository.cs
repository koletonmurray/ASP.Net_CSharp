using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_koletonm.Models
{
    // Creates the actual repository for orders to reference when we add to an order or save it to the db 
    public class EFOrderRepository : IOrderRepository
    {
        private BookstoreContext context;

        public EFOrderRepository(BookstoreContext temp)
        {
            context = temp;
        }

        public IQueryable<Order> Orders => context.Orders.Include(x => x.Lines).ThenInclude(x => x.Book);

        public void SaveOrder(Order order)
        {
            context.AttachRange(order.Lines.Select(x => x.Book));

            if (order.OrderId == 0)
            {
                context.Orders.Add(order);
            }

            context.SaveChanges();
        }
    }
}
