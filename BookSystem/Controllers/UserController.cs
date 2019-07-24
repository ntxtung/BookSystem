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

        #region Fundamental

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetUsers() {
            return Ok(_userService.GetUsers());
        }
        
        [Authorize(Roles = "Admin, User")]
        [HttpGet("{id}", Name = "UserLink")]
        public IActionResult GetBasicUserById(int id) {
            try {
                return Ok(_userService.GetUserById(id));
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }
        
        [Authorize(Roles = "Admin, User")]
        [HttpGet("{id}/fundedBook")]
        public IActionResult GetFundedBookOfUser([FromRoute] int id) {
            return Ok(_userService.GetFundedBookOfUser(id));
        }
        
        [Authorize(Roles = "Admin, User")]
        [HttpGet("{id}/rentedBook")]
        public IActionResult GetRentedBookOfUser([FromRoute] int id) {
            return Ok(_userService.GetRentedBookOfUser(id));
        }
        
//        [Authorize(Roles = "Admin, User")]
        [AllowAnonymous]
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

        #endregion

        #region Request
        
        [Authorize(Roles = "Admin, User")]
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
        
        [Authorize(Roles = "Admin, User")]
        [HttpPost("{funderId}/approve/{renterId}/{bookId}")]
        public IActionResult ApproveRequest([FromRoute] int fundUserId, [FromRoute] int requestUserId,
            [FromRoute] int bookId) {
//            return Ok(new {
//                funderId = fundUserId, renterId = requestUserId, bookId
//            });
            throw new NotImplementedException();
        }
        
        [Authorize(Roles = "Admin, User")]
        [HttpGet("{userId}/request")]
        public IActionResult GetAllBooksUserDidRequest([FromRoute] int userId) {
            return Ok(_requestBookServices.GetAllBooksUserDidRequest(userId));
        }

        #endregion

        #region Review
        
        [Authorize(Roles = "Admin, User")]
        [HttpPost("{userId}/review/{bookId}")]
        public IActionResult ReviewBook([FromBody] UsersReviewsBooks reviewData) {
            throw new NotImplementedException();
        }

        #endregion

        #endregion
    }
}