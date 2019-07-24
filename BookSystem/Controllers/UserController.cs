using System;
using System.Linq;
using BookSystem.Entities;
using BookSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;

namespace BookSystem.Controllers {
    [Route("api/users")]
    public class UserController : Controller {
        private readonly IUserServices _userService;
        private readonly IRequestBookServices _requestBookServices;
        private readonly IRentServices _rentServices;
        private readonly IAuthenticationServices _authenticationServices;

        public UserController(IUserServices userServices, IRequestBookServices requestBookServices,
            IRentServices rentServices, IAuthenticationServices authenticationServices) {
            _userService = userServices;
            _requestBookServices = requestBookServices;
            _rentServices = rentServices;
            _authenticationServices = authenticationServices;
        }
        
        [Authorize]
        [HttpGet]
        public IActionResult GetUsers() {
            var currentUserId = _authenticationServices.GetCurrentUserId(HttpContext);
            if (currentUserId != 1)
                return Forbid();
            return Ok(_userService.GetUsers());
        }
        
        [Authorize]
        [HttpGet("{id}", Name = "UserLink")]
        public IActionResult GetUserById(int id) {
            try {
                return Ok(_userService.GetUserById(id));
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}/fundedBook")]
        public IActionResult GetFundedBookOfUser([FromRoute] int id) {
            return Ok(_userService.GetFundedBookOfUser(id));
        }

        [HttpGet("{id}/rentedBook")]
        public IActionResult GetRentedBookOfUser([FromRoute] int id) {
            return Ok(_userService.GetRentedBookOfUser(id));
        }

        [HttpPost]
        public IActionResult RegisterNewUser([FromBody] Users userData) {
            try {
                var result = _userService.PostUser(userData);
                if (result > 0) {
                    var loggedUser = _userService.Authenticate(userData.Username, userData.Password);
                    return CreatedAtRoute(
                        "UserLink",
                        new {id = userData.Id},
                        new FullUsersDto {
                            Id = loggedUser.Id,
                            Username = loggedUser.Username,
                            Firstname = loggedUser.Firstname,
                            Lastname = loggedUser.Lastname,
                            Email = loggedUser.Email,
                            Avatar = loggedUser.Avatar,
#warning Change this after apply JWT
                            Password = null,
                            Token = loggedUser.Token
                        }
                    );
                }
            }
            catch (DuplicationEntryException) {
                return Ok(new {
                    message = "Duplicated Entry"
                });
            }
            catch (Exception) {
                return Ok(new {
                    message = "Unhandled Exception"
                });
            }

            return Ok(new {
                message = "Register Unsuccessfully"
            });
        }

        [HttpPost("{userId}/review/{bookId}")]
        public IActionResult ReviewBook([FromBody] UsersReviewsBooks reviewData) {
            throw new NotImplementedException();
        }

        [HttpPost("{userId}/request/{bookId}")]
        public IActionResult RequestBook([FromRoute] int userId, [FromRoute] int bookId) {
            try {
                if (_requestBookServices.DoRequest(userId, bookId) > 0) {
                    return Ok(new {message = "Request Successful"});
                }
            }
            catch (DuplicationEntryException) {
                return BadRequest(new {message = "Duplicated Entry"});
            }
            catch (Exception) {
                return BadRequest(new {message = "Unknown Error"});
            }

            return BadRequest(new {message = "Request Failed"});
        }

        [HttpPost("{funderId}/approve/{renterId}/{bookId}")]
        public IActionResult ApproveRequest([FromRoute] int fundUserId, [FromRoute] int requestUserId,
            [FromRoute] int bookId) {
//            return Ok(new {
//                funderId = fundUserId, renterId = requestUserId, bookId
//            });
            throw new NotImplementedException();
        }

        [HttpGet("{userId}/request")]
        public IActionResult GetAllBooksUserDidRequest([FromRoute] int userId) {
            return Ok(_requestBookServices.GetAllBooksUserDidRequest(userId));
        }
    }
}