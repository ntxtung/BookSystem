using System;
using System.Linq;
using BookSystem.Entities;
using BookSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookSystem.Controllers {
    [Route("api/books")]
    public class BookController : Controller {
        #region Properties
        private readonly IBooksServices _booksServices;
        private readonly IRequestBookServices _requestBookServices;
        private readonly IAuthenticationServices _authenticationServices;
        #endregion

        public BookController(IBooksServices booksServices, IRequestBookServices requestBookServices, IAuthenticationServices authenticationServices) {
            _booksServices = booksServices;
            _requestBookServices = requestBookServices;
            _authenticationServices = authenticationServices;
        }

        #region API Declaration

        #region Fundamental

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetBooks() {
            return Ok(_booksServices.GetBooks());
        }
        
        [Authorize(Roles = "Admin, User")]
        [HttpGet("{id}", Name = "BookLink")]
        public IActionResult GetBookById([FromRoute]int id) {
            try {
                return Ok(_booksServices.GetBookById(id));
            }
            catch (Exception e) {
                return BadRequest(new {
                    message = e.Message
                });
            }
        }
        
        [Authorize(Roles = "Admin, User")]
        [HttpDelete("{id}")]
        public IActionResult DeleteBookById([FromRoute] int id) {
            return Ok(_booksServices.DeleteBooks(id));
        }

        [Authorize(Roles = "Admin, User")]
        [HttpPost]
        public IActionResult PostBook([FromBody] Books bookData) {
            try {
                var result = _booksServices.PostBooks(bookData);
                if (result > 0)
                    return CreatedAtRoute(
                        "BookLink",
                        new { id = bookData.Id }, 
                        new FullBooksDTO {
                            Id = bookData.Id,
                            Title = bookData.Title,
                            Author = bookData.Author,
                            Image = bookData.Image
                        });
            }
            catch (DuplicationEntryException) {
                return Conflict(new {
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

        [Authorize(Roles = "Admin, User")]
        [HttpGet("{id}/rentUser")]
        public IActionResult GetRentedUser([FromRoute] int id) {
            return Ok(_booksServices.GetRentedUser(id));
        }
        
        [Authorize(Roles = "Admin, User")]
        [HttpGet("{id}/fundedUser")]
        public IActionResult GetFundedUser([FromRoute] int id) {
            return Ok(_booksServices.GetFundedUser(id));
        }
        
        #endregion

        #region Request

        [Authorize(Roles = "Admin, User")]
        [HttpGet("{bookId}/request")]
        public IActionResult GetAllUsersWhoRequestBook([FromRoute] int bookId) {
            return Ok(_requestBookServices.GetAllUsersWhoRequestBook(bookId));
        }
        
        #endregion
        #endregion
    }
}