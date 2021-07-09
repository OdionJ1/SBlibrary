﻿using SBLibrary.Data.Models.Domain;
using SBLibrary.Service.IService;
using SBLibrary.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SBLibrary.Controllers
{
    public class BookController : Controller
    {
        IBookService bookService;

        public BookController()
        {
            bookService = new BookService();
        }

        //get book info with id
        //public ActionResult GetBook(int id)
        //{
        //    return View(bookService.GetBook(id));
        //}
        //public ActionResult GetBooks(int id)
        //{
        //    return View(bookService.GetBooks(id));
        //}
        public ActionResult GetBooks()
        {
            return View(bookService.GetBooks());
        }

        public ActionResult EditBook(int id)
        {
            
            return View(bookService.EditBook(id));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditBook(Book edit)
        {
            if (ModelState.IsValid)
            {
                bookService.EditBook(edit);
                //return RedirectToAction("GetBooks", "Book", new { id = "UserID" });
                return RedirectToAction("GetBooks");
            }
            return View();
        }

        //public ActionResult DelBook(int id)
        //{

        //    return View(bookService.DelBook(id));
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult DelBook(Book del)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        bookService.DelBook(del);
        //        //return RedirectToAction("GetBooks", "Book", new { id = "UserID" });
        //        return RedirectToAction("GetBooks");
        //    }
        //    return View();
        //}









        // GET: Book
        public ActionResult Index()
        {
            return View();
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}