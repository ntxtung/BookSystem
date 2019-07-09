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
        public List<Books> GetAll() {
            return _booksContext.ToList();
        }

        [HttpPost]
        public ActionResult RegisterNewUser([FromBody] Books userData) {
            return null;
        }


        [HttpGet("{id}")]
        public Users GetUserById(int id) {
            return null;
        }
    }
}