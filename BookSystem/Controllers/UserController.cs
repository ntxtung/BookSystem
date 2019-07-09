using System;
using System.Collections.Generic;
using System.Linq;
using BookSystem.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace BookSystem.Controllers {
    [Route("api/users")]
    public class UserController : Controller {
        private readonly BookSystemContext _context;
        private readonly DbSet<User> _userContext;

        public UserController() {
            _context = new BookSystemContext();
            _userContext = _context.User;
        }

        [HttpGet]
        public List<User> GetAll() {
            return _userContext.ToList();
        }

        [HttpPost]
        public ActionResult RegisterNewUser([FromBody] User userData) {
            _userContext.Add(userData);
            try {
                if (_context.SaveChanges() > 0) {
                    var hiddenUserData = userData;
                    hiddenUserData.Password = null;
                    return Json(new {
                        message = "Register Successfully",
                        data = hiddenUserData
                    });
                }
            }
            catch (DbUpdateException dbe) {
                return Json(new {
                    message = "Register Unsuccessfully - Database Update Exception"
                });
            }
            return Json(new {
                message = "Register Unsuccessfully - Unknown Exception"
            });
        }


        [HttpGet("{id}")]
        public User GetUserById(int id) {
            var hiddenUsers = _userContext.Find(id);
            hiddenUsers.Password = null;
            return hiddenUsers;
        }
    }
}