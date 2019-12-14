using System;

namespace BookStore.Models
{
    public class Purchase
    {
        // Идентификатор заказа
        public int Id { get; set; }
        // Имя фамилия покупателя
        public string Person { get; set; }
        // Адрес покупателя
        public string Address { get; set; }
        // Идентификатор игры
        public int BookId { get; set; }
        // Дата покупки
        public DateTime Date { get; set; }
    }
}