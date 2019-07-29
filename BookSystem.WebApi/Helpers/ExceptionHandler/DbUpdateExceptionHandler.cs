using BookSystem.WebApi.Helpers.Exception;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace BookSystem.WebApi.Helpers.ExceptionHandler {
    public class DbUpdateExceptionHandler {
        private readonly DbUpdateException dbe;

        public DbUpdateExceptionHandler(DbUpdateException dbe) {
            this.dbe = dbe;
        }

        public void DoHandle() {
            var mysqlEx = dbe.InnerException as MySqlException;
            if (mysqlEx == null) throw new ApiException();
            switch (mysqlEx.Number) {
                case 1062:
                    throw new DuplicateEntryException();
                default:
                    throw new ApiException("Unknown or unhandled MySql Exception");
            }
        }
    }
}