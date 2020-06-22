using QLSACH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Runtime.Serialization;
using Microsoft.EntityFrameworkCore.Storage;

namespace QLSACH.Controllers
{
    public class BOOKController : Controller
    {
        // GET: BOOK
        public string hello(string university)
        {
            return "Hello Tuan-university" +university;
        }
        public ActionResult Listbook()
        {
            var books = new List<string>();
            books.Add("HTML5 & css3 complete manual - author name book 1");
            books.Add("HTML5 & css3 reponsive wed design cookbook - author name book 2");
            books.Add("Professional ASP.Net MVCS - Author name book 2");
            ViewBag.Books = books;
            return View();
        }
        public ActionResult ListbookModel()
        {
            var books = new List<Book>();
            books.Add(new Book(1, "sach1", "hinh1", "/Content/Img/1.jpg"));
            books.Add(new Book(2, "sach2", "hinh2", "/Content/Img/3.jpg"));
            books.Add(new Book(3, "sach3", "hinh3", "/Content/Img/4.jpg"));
            return View(books);
        }
        public ActionResult EditBook(int id)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "sach1", "hinh1", "/Content/Img/1.jpg"));
            books.Add(new Book(2, "sach2", "hinh2", "/Content/Img/3.jpg"));
            books.Add(new Book(3, "sach3", "hinh3", "/Content/Img/4.jpg"));
            Book book = new Book();
            foreach (Book b in books)
            {
                if(b.Id==id)
                {
                    book = b;
                    break;
                }
            }
            if(book==null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        [HttpPost, ActionName("EditBook")]
        [ValidateAntiForgeryToken]
        public ActionResult EditBook(int id,string Title,string Author,string ImageCover)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "Sach 1", "hinh 1", "/Content/Img/1.jpg"));
            books.Add(new Book(2, "Sach 2", "hinh 2", "/Content/Img/3.jpg"));
            books.Add(new Book(3, "Sach 3", "hinh 3", "/Content/Img/4.jpg"));
            if (id == null)
            {
                return HttpNotFound();
            }
            foreach (Book b in books)
            {
                if (b.Id == id)
                {
                    b.Title = Title;
                    b.Author = Author;
                    b.Imgcover = ImageCover;
                    break;
                }
            }
            return View("ListBookModel",books);
        }
        public ActionResult CreateBook()
        {
            return View();
        }
        [HttpPost,ActionName("CreateBook")]
        [ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include ="Id,Title,Author,ImgeCover")]Book book)
        {
            var books = new List<Book>();
            //sach mac dinh
            books.Add(new Book(1, "Sach 1", "hinh 1", "/Content/Img/1.jpg"));
            books.Add(new Book(2, "Sach 2", "hinh 2", "/Content/Img/3.jpg"));
            books.Add(new Book(3, "Sach 3", "hinh 3", "/Content/Img/4.jpg"));
            try
            {
                if(ModelState.IsValid)
                {
                    //them sach moi
                    books.Add(book);
                }
            }

            catch (RetryLimitExceededException/* dex*/)
            {
                ModelState.AddModelError("", "Error save data");
            }
            //tra ve trang xem sach voi danh sach book mnoi
            return View("ListBookModel", books);
        }
    }
   
}