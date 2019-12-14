using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BookStore.Models
{
    public class SquareContext: DbContext
    {
        public DbSet<Square> Squares { get; set; }
    }
}