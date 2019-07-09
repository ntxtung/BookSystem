using System;
using System.Collections.Generic;
using System.Linq;
using BookSystem.Entities;
using BookSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

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
            var result = _userService.RegisterNewUser(userData);
            if (result > 0) {
                return Json(new {
                    message = "Create User Successfully"
                });
            }

            return Json(new {
                message = "Create User Unsuccessfully"
            });
        }

        [HttpPut("{id}")]
        public ActionResult UpdateUser([FromRoute] int id, [FromBody] Users userData) {
            var result = _userService.UpdateUser(id, userData);
            if (result > 0) {
                return Json(new {
                    message = "Update User Successfully"
                });
            }

            return Json(new {
                message = "Update User Unsuccessfully"
            });
        }
    }
}