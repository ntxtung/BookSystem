using System.Linq;
using BookSystem.Domain.Entities;

namespace BookSystem.Application.Services.Interface {
    public interface IDoResearchServices {
        Users GetIncludeUserById(int id);
        IQueryable GetIncludeUsers();
    }
}