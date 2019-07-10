using System;
using System.Collections.Generic;
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
        public List<Users> GetAll() {
            return _userService.GetAllUsers();
        }

        [HttpGet("{id}")]
        public Users GetUserById(int id) {
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