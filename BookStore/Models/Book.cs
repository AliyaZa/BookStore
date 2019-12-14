namespace BookStore.Models
{
    public class Book
    {
        // Идентификатор
        public int Id { get; set; }
        // Название
        public string Name { get; set; }
        // Компания выпустившая игру
        public string Author { get; set; }
        // Цена
        public int Price { get; set; }
    }
}