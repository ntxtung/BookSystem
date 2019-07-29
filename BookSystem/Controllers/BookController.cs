using System;
using BookSystem.Entities;
using BookSystem.Dtos;
using BookSystem.Helpers.ExceptionHelper;
using BookSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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

        #region Basic

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetBooks([FromQuery(Name="page")] int page = 1, [FromQuery(Name="pageSize")] int pageSize = 10) {
            return Ok(_booksServices.GetBooks(page, pageSize));
        }
        
        [Authorize(Roles = "Admin, User")]
        [HttpGet("{bookId}", Name = "BookLink")]
        public IActionResult GetBookById([FromRoute]int bookId) {
            try {
                return Ok(_booksServices.GetBookById(bookId));
            }
            catch (Exception) {
                return StatusCode(StatusCodes.Status500InternalServerError, "Unhandled Exception");
            }
        }
        
        [Authorize(Roles = "Admin, User")]
        [HttpDelete("{bookId}")]
        public IActionResult DeleteBookById([FromRoute] int bookId) {
//            return Ok(_booksServices.DeleteBooks(bookId));
            return StatusCode(StatusCodes.Status501NotImplemented, "This method was not implemented, sorry :(");
        }

        [Authorize(Roles = "Admin, User")]
        [HttpPost]
        public IActionResult FundBook([FromBody] Books bookData) {
            try {
                var result = _booksServices.PostBooks(bookData);
                if (result > 0)
                    return CreatedAtRoute(
                        "BookLink",
                        new { id = bookData.Id }, 
                        new FullBooksDto(bookData));
            }
            catch (DuplicateEntryException) {
                return BadRequest(new {
                    message = "Duplicated Entry"
                });
            }
            catch (Exception) {
                return StatusCode(StatusCodes.Status500InternalServerError, "Unhandled Exception");
            }
            return StatusCode(StatusCodes.Status500InternalServerError, "Unknown Exception");
        }
        
        [Authorize(Roles = "Admin, User")]
        [HttpPut("{bookId}")]
        public IActionResult UpdateBook([FromBody] FullBooksDto bookData) {
            return StatusCode(StatusCodes.Status501NotImplemented);
        }

        #endregion

        #region Request

        [Authorize(Roles = "Admin, User")]
        [HttpGet("{bookId}/request/users")]
        public IActionResult GetAllUsersWhoRequestBook([FromRoute] int bookId, [FromQuery(Name="page")] int page = 1, [FromQuery(Name="pageSize")] int pageSize = 5) {
            return Ok(_requestBookServices.GetAllUsersWhoRequestBook(bookId, page, pageSize));
        }
        
        #endregion

        #region Fund
        [Authorize(Roles = "Admin, User")]
        [HttpGet("{bookId}/fund/users")]
        public IActionResult GetFundedUser([FromRoute] int bookId) {
            return Ok(_booksServices.GetFundedUser(bookId));
        }

        #endregion

        #region Rent
        
        [Authorize(Roles = "Admin, User")]
        [HttpGet("{bookId}/rent/users")]
        public IActionResult GetRentedUser([FromRoute] int bookId) {
            return Ok(_booksServices.GetRentedUser(bookId));
        }
        

        #endregion

        #region Review
        [Authorize(Roles = "Admin, User")]
        [HttpGet("{bookId}/reviews/")]
        public IActionResult GetReviewsOfBook([FromRoute] int bookId) {
            return StatusCode(StatusCodes.Status501NotImplemented);
        }
        

        #endregion
        #endregion
    }
}