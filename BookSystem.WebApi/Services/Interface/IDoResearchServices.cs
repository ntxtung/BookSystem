using System.Linq;
using BookSystem.Entities;

namespace BookSystem.WebApi.Services.Interface {
    public interface IDoResearchServices {
        Users GetIncludeUserById(int id);
        IQueryable GetIncludeUsers();
    }
}