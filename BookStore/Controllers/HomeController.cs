using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;
using System.IO;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        // Создаем контекст данных
        BookContext db = new BookContext();
        SquareContext sqdb = new SquareContext();
        public ActionResult Index()
        {
            // Получаем из бд все объекты VideoGame
            IEnumerable<Book> books = db.Books;
            // Передаем все объекты в динамическое св-во VideoGames в ViewBag
            ViewBag.Books = books;
            ViewBag.Message = "Это вызов частичного представления из обычного";
            // Возвращаем представление
            return View();
        }

        public string IndexContext()
        {
            HttpContext.Response.Charset = "utf-8";
            HttpContext.Response.Write("<h1>Hello World</h1>");

            string browser = HttpContext.Request.Browser.Browser;
            string user_agent = HttpContext.Request.UserAgent;
            string url = HttpContext.Request.RawUrl;
            string ip = HttpContext.Request.UserHostAddress;
            string referrer = HttpContext.Request.UrlReferrer == null ? "" : HttpContext.Request.UrlReferrer.AbsoluteUri;
            return "<p>Browser: " + browser + "</p><p>User-Agent: " + user_agent + "</p><p>Url запроса: " + url +
                "</p><p>Реферер: " + referrer + "</p><p>IP-адрес: " + ip + "</p>" +
                "<br><td><a href = \"/Home/Index\"> Главная</a></td></br>";
        }

        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.BookId = id;
            return View();
        }

        [HttpPost]
        public string Buy(Purchase purchase)
        {
            purchase.Date = DateTime.Now;
            db.Purchases.Add(purchase);
            db.SaveChanges();
            return "Спасибо, " + purchase.Person + ", за покупку!";
        }

        [HttpGet]
        public ActionResult SquareOf()
        {
            IEnumerable<Square> squares = sqdb.Squares;
            // передаем все объекты в динамическое свойство Books в ViewBag
            ViewBag.Squares = squares;
            return View();
        }

        [HttpPost]
        public string SquareOf(Square square)
        {

            int a = square.a;
            int h = square.h;
            square.count(a, h);
            double s1 = square.s1;

            square.Date = DateTime.Now; 
            sqdb.Squares.Add(square);
            sqdb.SaveChanges();

            return "<h2>Площадь треугольника с основанием " + a +
                    " и высотой " + h + " равна " + s1 + "</h2>" +
                    "<td><a href = \"/Home/SquareOf\"> Еще раз</a></td>" +
                    "<br><td><a href = \"/Home/Index\"> Главная</a></td></br>";
        }


        public ActionResult IndexSquares()
        {
            // получаем из бд все объекты Square
            IEnumerable<Square> squares = sqdb.Squares;
            // передаем все объекты в динамическое свойство Squares в ViewBag
            ViewBag.Squares = squares;
            // возвращаем представление
            return View();
        }

            public string Square()
            {
                int a;
                int.TryParse(Request.Params["a"], out a);
                int h;
                int.TryParse(Request.Params["h"], out h);

                var s = a * h / 2.0;

            return "<h2>Площадь треугольника с основанием " + a + " и высотой " + h + " равна " + s + "</h2>"; 
        }

        public ActionResult IndexPurchased()
        {
            // получаем из бд все объекты Purchase
            IEnumerable<Purchase> purchases = db.Purchases;
            // передаем все объекты в динамическое свойство Purchase в ViewBag
            ViewBag.Purchases = purchases;
            // возвращаем представление
            return View();
        }

        public ActionResult GetHtml()
        {
            return new HtmlResult("<h2>Привет мир!</h2>");
        }

        public ActionResult GetImage()
        {
            string path = "../Images/book.jpg";
            return new ImageResult(path);
        }

        public ActionResult Partial()
        {
            ViewBag.Message = "Это частичное представление.";
            return PartialView();
        }

        [HttpGet]
        public ActionResult Create()
        {
            var book = db.Books.FirstOrDefault();
            return View(book);
        }

        [HttpPost]
        public ActionResult Create(Book book, Book myBook)
        {
            db.Books.Add(myBook);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ViewResult SomeMethodData()
        {
            ViewData["Head"] = "Привет мир!";
            return View("SomeView");
        }

        public ViewResult SomeMethodBag()
        {
            ViewBag.Head = "Привет мир!";
            return View("SomeView");
        }

    }
}