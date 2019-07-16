using System;
using System.Collections;
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
        public ActionResult GetAll() {
            return Ok(_booksServices.GetAllBooks());
        }

        [HttpPost]
        public ActionResult RegisterNewBook([FromBody] Books bookData) {
            try {
                var result = _booksServices.RegisterNewBook(bookData);
                if (result > 0)
                    return Ok(new {
                        message = "Register Successfully"
                    });
            }
            catch (DuplicationEntryException) {
                return BadRequest(new {
                    message = "Duplicated Entry"
                });
            }
            catch (Exception) {
                return BadRequest(new {
                    message = "Unhandled Exception"
                });
            }
            return BadRequest(new {
                message = "Register Unsuccessfully"
            });
        }

        [HttpGet("{id}")]
        public ActionResult GetBookById([FromRoute]int id) {
            try {
                return Ok(_booksServices.GetBookById(id));
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBookById([FromRoute] int id) {
            return Ok(_booksServices.DeleteBook(id));
        }

        [HttpGet("{id}/rentUser")]
        public ActionResult GetRentedUser([FromRoute] int id) {
            return Ok(_booksServices.GetRentedUser(id));
        }
    }
}