using System.Data.Entity;

namespace BookStore.Models
{
    public class BookDbInitializer: DropCreateDatabaseAlways<BookContext>
    {
        protected override void Seed(BookContext db)
        {
            db.Books.Add(new Book { Name = "Мастер и Маргарита", Author = "Михаил Булгаков", Price = 2200 });
            db.Books.Add(new Book { Name = "Ася", Author = "Иван Тургенев", Price = 1800 });
            db.Books.Add(new Book { Name = "Мертвые души", Author = "Николай Гоголь", Price = 1500 });
            base.Seed(db);
        }
    }
}