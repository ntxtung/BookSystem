using System;
using System.Collections.Generic;
using System.Linq;
using BookSystem.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace BookSystem.Controllers {
    [Route("api/books")]
    public class BookController : Controller {
        private readonly BookSystemContext _context;
        private readonly DbSet<Books> _booksContext;

        public BookController() {
            _context = new BookSystemContext();
            _booksContext = _context.Books;
        }

        [HttpGet]
        public IEnumerable<Books> GetAll() {
            return null;
        }

        [HttpPost]
        public ActionResult RegisterNewBook([FromBody] Books userData) {
            return null;
        }

        [HttpGet("{id}")]
        public Books GetUserById(int id) {
            return _booksContext.Find(id);
        }
    }
}