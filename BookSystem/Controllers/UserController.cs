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
        private readonly DbSet<Users> _usersContext;

        public UserController() {
            _context = new BookSystemContext();
            _usersContext = _context.Users;
        }

        [HttpGet]
        public List<Users> GetAll() {
            return _usersContext.ToList();
        }

        [HttpPost]
        public ActionResult RegisterNewUser([FromBody] Users userData) {
            _usersContext.Add(userData);
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
            catch (DbUpdateException) {
                return Json(new {
                    message = "Register Unsuccessfully - Database Update Exception"
                });
            }
            return Json(new {
                message = "Register Unsuccessfully - Unknown Exception"
            });
        }


        [HttpGet("{id}")]
        public Users GetUserById(int id) {
            try {
                var hiddenUsers = _usersContext.Find(id);
                hiddenUsers.Password = null;
                return hiddenUsers;
            }
            catch (NullReferenceException) {
                return null;
            }
            
        }
    }
}