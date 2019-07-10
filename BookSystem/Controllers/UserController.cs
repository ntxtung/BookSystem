using System;
using System.Collections;
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
        public IList GetAll() {
            return _userService.GetAllUsers();
        }

        [HttpGet("{id}/fundedBook")]
        public IList GetFundedBookOfUser([FromRoute]int id) {
            return _userService.GetFundedBookOfUser(id);
        }
        
        [HttpGet("{id}/rentedBook")]
        public IList GetRentedBookOfUser([FromRoute]int id) {
            return _userService.GetRentedBookOfUser(id);
        }

        [HttpGet("{id}")]
        public Object GetUserById(int id) {
            return _userService.GetUserById(id);
        }

        [HttpPost]
        public ActionResult RegisterNewUser([FromBody] Users userData) {
            try {
                var result = _userService.RegisterNewUser(userData);
                if (result > 0)
                    return Json(new {
                        message = "Register Successfully"
                    });
            }
            catch (DuplicationEntryException) {
                return Json(new {
                    message = "Duplicated Entry"
                });
            }
            catch (Exception) {
                return Json(new {
                    message = "Unhandled Exception"
                });
            }

            return Json(new {
                message = "Register Unsuccessfully"
            });
        }
    }
}