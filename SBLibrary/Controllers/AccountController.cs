﻿using SBLibrary.Data.Models.Domain;
using SBLibrary.Service.IService;
using SBLibrary.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SBLibrary.Controllers
{
    public class AccountController : Controller
    {
        IUserService userService;
        LoginService loginService;
        IBookService bookService;

        public AccountController()
        {
            userService = new UserService();
            loginService = new LoginService();
            bookService = new BookService();
        }
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        // GET: Account/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Account/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Account/Create
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

        // GET: Account/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Account/Edit/5
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

        // GET: Account/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Account/Delete/5
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
        

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login loginmodel)
        {
            if (ModelState.IsValid)
            {
                var user = userService.GetUser(loginmodel.Email);
                if (loginService.UserAuthenticated(loginmodel)) 
                {
                    Session["Email"] = loginmodel.Email;
                    return RedirectToAction("GetBooks", "Book", new { id = user.UserID }); 
                }
                
                return RedirectToAction("Login");
            }

            return View();
        }

        public ActionResult Register()
        {
            ViewBag.Message = "Register a user";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User usermodel)
        {
            if (ModelState.IsValid)
            {
                userService.CreateUser(usermodel);
                //return RedirectToAction("GetBooks", "Book", new { id = "UserID" });
                return RedirectToAction("Login");
            }



            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult GetBook(int id)
        {
            return View(bookService.GetBook(id));
        }
        public ActionResult GetBooks(int id)
        {
            return View(bookService.GetBooks(id));
        }



    }
}