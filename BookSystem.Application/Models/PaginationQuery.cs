namespace BookSystem.Application.Models {
    public class PaginationQuery {
        public int Page { set; get; } = 1;
        public int PageSize { set; get; } = 5;
    }
}