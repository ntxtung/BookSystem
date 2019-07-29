using BookSystem.Application.Exception;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace BookSystem.Application.Handler {
    public class DbUpdateExceptionHandler {
        private readonly DbUpdateException dbe;

        public DbUpdateExceptionHandler(DbUpdateException dbe) {
            this.dbe = dbe;
        }

        public void DoHandle() {
            var mysqlEx = dbe.InnerException as MySqlException;
            if (mysqlEx == null) throw new UnknownException();
            switch (mysqlEx.Number) {
                case 1062:
                    throw new DuplicateEntryException();
                default:
                    throw new UnknownException("Unknown or unhandled MySql Exception");
            }
        }
    }
}