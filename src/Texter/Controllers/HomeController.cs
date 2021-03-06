﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Texter.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Texter.Controllers
{
    public class HomeController : Controller
    {
        private TexterDbContext db = new TexterDbContext();
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetMessages()
        {
            var allMessages = Message.GetMessages();
            return View(allMessages);
        }
        public IActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendMessage(Message newMessage)
        {
            newMessage.Send();
            return RedirectToAction("Index");
        }
        public IActionResult AddContact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddContact(Contact contact)
        {
            db.Contacts.Add(contact);
            db.SaveChanges();
            return RedirectToAction("ContactList");
        }
        public IActionResult ContactList()
        {
            return View(db.Contacts.ToList());
        }
    }
}
