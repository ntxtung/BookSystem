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

        #region Basic

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetBooks([FromQuery(Name="page")] int? page = 1, [FromQuery(Name="pageSize")] int? pageSize = 10) {
            return Ok(_booksServices.GetBooks(page, pageSize));
        }
        
        [Authorize(Roles = "Admin, User")]
        [HttpGet("{id}", Name = "BookLink")]
        public IActionResult GetBookById([FromRoute]int id) {
            try {
                return Ok(_booksServices.GetBookById(id));
            }
            catch (Exception) {
                return StatusCode(500);
            }
        }
        
        [Authorize(Roles = "Admin, User")]
        [HttpDelete("{id}")]
        public IActionResult DeleteBookById([FromRoute] int id) {
//            return Ok(_booksServices.DeleteBooks(id));
            return StatusCode(501);
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
                        new FullBooksDTO(bookData));
            }
            catch (DuplicationEntryException) {
                return BadRequest(new {
                    message = "Duplicated Entry"
                });
            }
            catch (Exception) {
                return StatusCode(500);
            }
            return StatusCode(500);
        }
        
        [Authorize(Roles = "Admin, User")]
        [HttpPut("{bookId}")]
        public IActionResult UpdateBook([FromBody] FullBooksDTO bookData) {
            return StatusCode(501);
        }

        #endregion

        #region Request

        [Authorize(Roles = "Admin, User")]
        [HttpGet("{bookId}/request/users")]
        public IActionResult GetAllUsersWhoRequestBook([FromRoute] int bookId, [FromQuery(Name="page")] int? page = 1, [FromQuery(Name="pageSize")] int? pageSize = 5) {
            return Ok(_requestBookServices.GetAllUsersWhoRequestBook(bookId, page, pageSize));
        }
        
        #endregion

        #region Fund
        [Authorize(Roles = "Admin, User")]
        [HttpGet("{id}/fund/users")]
        public IActionResult GetFundedUser([FromRoute] int id) {
            return Ok(_booksServices.GetFundedUser(id));
        }

        #endregion

        #region Rent
        
        [Authorize(Roles = "Admin, User")]
        [HttpGet("{id}/rent/users")]
        public IActionResult GetRentedUser([FromRoute] int id) {
            return Ok(_booksServices.GetRentedUser(id));
        }
        

        #endregion

        #region Review
        [Authorize(Roles = "Admin, User")]
        [HttpGet("{bookId}/reviews/")]
        public IActionResult GetReviewsOfBook([FromRoute] int bookId) {
            return StatusCode(501);
        }
        

        #endregion
        #endregion
    }
}