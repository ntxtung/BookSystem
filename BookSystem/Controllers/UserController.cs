using System;
using BookSystem.Entities;
using BookSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookSystem.Controllers {
    [Route("api/users")]
    public class UserController : Controller {
        private readonly IUserServices _userService;
        private readonly IRequestBookServices _requestBookServices;
        private readonly IRentServices _rentServices;
        
        public UserController(IUserServices userServices, IRequestBookServices requestBookServices, 
                                IRentServices rentServices) {
            _userService = userServices;
            _requestBookServices = requestBookServices;
            _rentServices = rentServices;
        }

        [HttpGet]
        public IActionResult GetAll() {
            return Ok(_userService.GetAllUsers());
        }
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id) {
            try {
                return Ok(_userService.GetUserById(id));
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}/fundedBook")]
        public IActionResult GetFundedBookOfUser([FromRoute]int id) {
            return Ok(_userService.GetFundedBookOfUser(id));
        }
        
        [HttpGet("{id}/rentedBook")]
        public IActionResult GetRentedBookOfUser([FromRoute]int id) {
            return Ok(_userService.GetRentedBookOfUser(id));
        }

        [HttpPost]
        public IActionResult RegisterNewUser([FromBody] Users userData) {
            try {
                var result = _userService.RegisterNewUser(userData);
                if (result > 0) {
                    var loggedUser = _userService.Authenticate(userData.Username, userData.Password);
                    return CreatedAtAction(nameof(RegisterNewUser), loggedUser);
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

        [HttpPost("{userId}/request/{bookId}")]
        public IActionResult RequestBook([FromRoute] int userId, [FromRoute] int bookId) {
            return Ok(_requestBookServices.DoRequest(userId, bookId));
        }

        [HttpPost("{funderId}/approve/{renterId}/{bookId}")]
        public IActionResult ApproveRequest([FromRoute] int funderId, [FromRoute] int renterId, [FromRoute] int bookId) {
            return Ok(new {
                funderId, renterId, bookId
            });
        }
    }
}