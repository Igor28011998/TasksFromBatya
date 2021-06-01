using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Controllers
{
    public class BooksController : Controller
    {
        static List<Book> BooksList = new List<Book>() { };
        // GET: Books
        public ActionResult Index()
        {
            return View(BooksList);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            
            try
            {
                if (ModelState.IsValid)
                {
                    BooksList.Add(book);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Books/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = BooksList.Find(u=>u.Id==id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                if (book.Id !=0)
                {
                    var bookid = BooksList.Find(u => u.Id == book.Id);
                    BooksList.Remove(bookid);
                    BooksList.Add(book);
                }
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = BooksList.Find(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                var book = BooksList.Find(u=>u.Id==id);
                BooksList.Remove(book);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}