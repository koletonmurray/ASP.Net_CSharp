using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_koletonm.Models
{
    // Sets up the I portion of the Bookstore repository
    public interface IBookstoreRepository
    {
        IQueryable<Book> Books { get; }
    }
}
