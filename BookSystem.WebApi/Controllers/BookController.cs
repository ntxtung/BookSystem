using BookSystem.Application.Exception;
using BookSystem.Application.UseCase.BookManagement;
using BookSystem.Application.UseCase.RequestBookManagement;
using BookSystem.Domain.Entities;
using BookSystem.WebApi.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookSystem.WebApi.Controllers {
    [Route("api/books")]
    public class BookController : Controller {
        #region Properties
        private readonly IBookManagementServices _bookManagementServices;
        private readonly IRequestBookManagementServices _requestBookManagementServices;
        #endregion

        public BookController(IRequestBookManagementServices requestBookManagementServices, IBookManagementServices bookManagementServices) {
            _bookManagementServices = bookManagementServices;
            _requestBookManagementServices = requestBookManagementServices;
        }

        #region API Declaration

        #region Basic

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetBooks([FromQuery(Name="page")] int page = 1, [FromQuery(Name="pageSize")] int pageSize = 10) {
            return Ok(_bookManagementServices.GetBooks(page, pageSize));
        }
        
        [Authorize(Roles = "Admin, User")]
        [HttpGet("{bookId}", Name = "BookLink")]
        public IActionResult GetBookById([FromRoute]int bookId) {
            try {
                return Ok(_bookManagementServices.GetBookById(bookId));
            }
            catch (System.Exception) {
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
        [HttpPut("{bookId}")]
        public IActionResult UpdateBook([FromBody] FullBooksDto bookData) {
            return StatusCode(StatusCodes.Status501NotImplemented);
        }

        #endregion

        #region Request

        [Authorize(Roles = "Admin, User")]
        [HttpGet("{bookId}/request/users")]
        public IActionResult GetAllUsersWhoRequestBook([FromRoute] int bookId, [FromQuery(Name="page")] int page = 1, [FromQuery(Name="pageSize")] int pageSize = 5) {
            return Ok(_requestBookManagementServices.GetAllUsersWhoRequestBook(bookId, page, pageSize));
        }
        
        #endregion

        #region Fund
        [Authorize(Roles = "Admin, User")]
        [HttpGet("{bookId}/fund/users")]
        public IActionResult GetFundedUser([FromRoute] int bookId) {
            return Ok(_bookManagementServices.GetFundedUser(bookId));
        }
        
        
        [Authorize(Roles = "Admin, User")]
        [HttpPost]
        public IActionResult FundBook([FromBody] Books bookData) {
            try {
                var result = _bookManagementServices.PostBooks(bookData);
                if (result > 0)
#warning Should fix this into CreatedAtRoute
                    return Ok(new FullBooksDto(bookData));
//                    return CreatedAtRoute(
//                        "BookLink",
//                        new { id = bookData.Id }, 
//                        new FullBooksDto(bookData));
            }
            catch (DuplicateEntryException) {
                return BadRequest(new {
                    message = "Duplicated Entry"
                });
            }
            catch (System.Exception) {
                return StatusCode(StatusCodes.Status500InternalServerError, "Unhandled Exception");
            }
            return StatusCode(StatusCodes.Status500InternalServerError, "Unknown Exception");
        }

        #endregion

        #region Rent
        
        [Authorize(Roles = "Admin, User")]
        [HttpGet("{bookId}/rent/users")]
        public IActionResult GetRentedUser([FromRoute] int bookId) {
            return Ok(_bookManagementServices.GetRentedUser(bookId));
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