using System;
using BookSystem.Entities;
using BookSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookSystem.Controllers {
    [Route("api/users")]
    public class UserController : Controller {
        private readonly IUserServices _userService;

        public UserController(IUserServices userServices) {
            _userService = userServices;
        }

        [HttpGet]
        public ActionResult GetAll() {
            return Ok(_userService.GetAllUsers());
        }
        [HttpGet("{id}")]
        public ActionResult GetUserById(int id) {
            try {
                return Ok(_userService.GetUserById(id));
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}/fundedBook")]
        public ActionResult GetFundedBookOfUser([FromRoute]int id) {
            return Ok(_userService.GetFundedBookOfUser(id));
        }
        
        [HttpGet("{id}/rentedBook")]
        public ActionResult GetRentedBookOfUser([FromRoute]int id) {
            return Ok(_userService.GetRentedBookOfUser(id));
        }


        [HttpPost]
        public ActionResult RegisterNewUser([FromBody] Users userData) {
            try {
                var result = _userService.RegisterNewUser(userData);
                if (result > 0) {
                    var loggedUser = _userService.Authenticate(userData.Username, userData.Password);
                    return Accepted(loggedUser);
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
    }
}