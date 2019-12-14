using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BookStore.Models
{
    public class SquaresDbInitializer: DropCreateDatabaseAlways<SquareContext>
    {
        protected override void Seed(SquareContext sqdb)
        {
            //sqdb.Squares.Add(new Square {});
            base.Seed(sqdb);
        }
    }
}