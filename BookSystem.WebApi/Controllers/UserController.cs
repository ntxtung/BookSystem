using System;
using BookSystem.Entities;
using BookSystem.WebApi.Helpers.Exception;
using BookSystem.WebApi.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookSystem.WebApi.Controllers {
    [Route("api/users")]
    public class UserController : Controller {
        #region Properties

        private readonly IUserServices _userService;
        private readonly IRequestBookServices _requestBookServices;
        private readonly IRentServices _rentServices;
        private readonly IAuthenticationServices _authenticationServices;

        #endregion

        public UserController(IUserServices userServices, IRequestBookServices requestBookServices,
            IRentServices rentServices, IAuthenticationServices authenticationServices) {
            
            _userService = userServices;
            _requestBookServices = requestBookServices;
            _rentServices = rentServices;
            _authenticationServices = authenticationServices;
        }

        #region API Declaration

        #region Basic

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetUsers() {
            return Ok(_userService.GetUsers());
        }
        
        [Authorize(Roles = "Admin, User")]
        [HttpGet("{id}", Name = "UserLink")]
        public IActionResult GetUserById(int id) {
            try {
                if (_authenticationServices.GetCurrentUserId(HttpContext) == id)
                    return Ok(_userService.GetFullUserById(id));
                return Ok(_userService.GetBasicUserById(id));
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        #endregion
        
        #region Fund
                
        [Authorize(Roles = "Admin, User")]
        [HttpGet("{id}/fund/books")]
        public IActionResult GetFundedBookOfUser([FromRoute] int id, [FromQuery(Name="page")] int page = 1, [FromQuery(Name="pageSize")] int pageSize = 5) {
            return Ok(_userService.GetFundedBookOfUser(id, page, pageSize));
        }
        

        #endregion

        #region Request
        [Authorize(Roles = "Admin, User")]
        [HttpGet("request/books")]
        public IActionResult GetRequestedBook([FromQuery(Name="page")] int page = 1, [FromQuery(Name="pageSize")] int pageSize = 5) {
            return Ok(_requestBookServices.GetAllBooksUserDidRequest(_authenticationServices.GetCurrentUserId(HttpContext), page, pageSize));
        }
        
        [Authorize(Roles = "Admin, User")]
        [HttpPost("request/books/{bookId}")]
        public IActionResult RequestBook([FromRoute] int bookId) {
            try {
                var currentUserId = _authenticationServices.GetCurrentUserId(HttpContext);
                if (_requestBookServices.DoRequest(currentUserId, bookId) > 0) {
                    return Ok(new {message = "Request Successful"});
                }
            }
            catch (DuplicateEntryException) {
                return BadRequest(new {message = "Duplicated Entry"});
            }
            catch (Exception) {
                return BadRequest(new {message = "Unknown Error"});
            }

            return BadRequest(new {message = "Request Failed"});
        }
        
        [Authorize(Roles = "Admin, User")]
        [HttpDelete("request/books/{bookId}")]
        public IActionResult CancelRequest([FromRoute] int bookId) {
            throw new NotImplementedException();
        }
        
        [Authorize(Roles = "Admin")]
        [HttpGet("{userId}/request/books")]
        public IActionResult GetAllBooksUserDidRequest([FromRoute] int userId) {
            return Ok(_requestBookServices.GetAllBooksUserDidRequest(userId));
        }
        
        [Authorize(Roles = "Admin, User")]
        [HttpPost("approve/users/{requestUserId}/books/{bookId}")]
        public IActionResult ApproveRequest([FromRoute] int requestUserId, [FromRoute] int bookId) {
//            return Ok(new {
//                funderId = fundUserId, renterId = requestUserId, bookId
//            });
            throw new NotImplementedException();
        }
        
        [Authorize(Roles = "Admin, User")]
        [HttpDelete("approve/users/{requestUserId}/books/{bookId}")]
        public IActionResult DisApproveRequest([FromRoute] int requestUserId, [FromRoute] int bookId) {
//            return Ok(new {
//                funderId = fundUserId, renterId = requestUserId, bookId
//            });
            throw new NotImplementedException();
        }

        #endregion

        #region Rent
        
        [Authorize(Roles = "Admin, User")]
        [HttpGet("{userId}/rent/books")]
        public IActionResult GetRentedBookOfUser([FromRoute] int userId,[FromQuery(Name="page")] int page = 1, [FromQuery(Name="pageSize")] int pageSize = 5) {
            return Ok(_userService.GetRentedBookOfUser(userId, page, pageSize));
        }

        #endregion
        
        #region Review
        
        [Authorize(Roles = "Admin, User")]
        [HttpPost("reviews/{bookId}")]
        public IActionResult ReviewBook([FromBody] UsersReviewsBooks reviewData, [FromRoute] int bookId) {
            reviewData.UsersId = _authenticationServices.GetCurrentUserId(HttpContext);
            throw new NotImplementedException();
        }

        #endregion
        #endregion
    }
}