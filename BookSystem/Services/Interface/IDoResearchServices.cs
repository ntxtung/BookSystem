using System.Linq;
using BookSystem.Entities;

namespace BookSystem.Services {
    public interface IDoResearchServices {
        Users GetIncludeUserById(int id);
        IQueryable GetIncludeUsers();
    }
}