using BookSystem.WebApi.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BookSystem.WebApi.Controllers {
    [Route("api/research")]
    public class DoResearchController : Controller {
        private readonly IUserServices _userService;
        private readonly IRequestBookServices _requestBookServices;
        private readonly IDoResearchServices _doResearchServices;

        public DoResearchController(IUserServices userServices, IRequestBookServices requestBookServices,
            IDoResearchServices doResearchServices) {
            _userService = userServices;
            _requestBookServices = requestBookServices;
            _doResearchServices = doResearchServices;
        }

        [HttpGet]
        public IActionResult GetIncludeUsers() {
            return Ok(_doResearchServices.GetIncludeUsers());
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id) {
            return Ok(_doResearchServices.GetIncludeUserById(id));
        }
    }
}