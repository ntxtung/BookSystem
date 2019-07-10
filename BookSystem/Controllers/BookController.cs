using System;
using System.Collections.Generic;
using BookSystem.Entities;
using BookSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookSystem.Controllers {
    [Route("api/books")]
    public class BookController : Controller {
        private readonly IBooksServices _booksServices;

        public BookController(IBooksServices booksServices) {
            _booksServices = booksServices;
        }

        [HttpGet]
        public IEnumerable<Books> GetAll() {
            return _booksServices.GetAllBooks();
        }

        [HttpPost]
        public ActionResult RegisterNewBook([FromBody] Books bookData) {
            try {
                var result = _booksServices.RegisterNewBook(bookData);
                if (result > 0)
                    return Json(new {
                        message = "Register Successfully"
                    });
            }
            catch (DuplicationEntryException) {
                return Json(new {
                    message = "Duplicated Entry"
                });
            }
            catch (Exception) {
                return Json(new {
                    message = "Unhandled Exception"
                });
            }
            
            return Json(new {
                message = "Register Unsuccessfully"
            });
        }

        [HttpGet("{id}")]
            public Books GetUserById(int id) {
                return _booksServices.GetBookById(id);
            }
    }
}