using System.Collections.Generic;
using System.Linq;
using BookSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookSystem.Controllers {
    [Route("users")]
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
    }
}