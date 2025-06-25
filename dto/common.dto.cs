using System.ComponentModel.DataAnnotations;

namespace EcommerceWebApi.Dto
{
    public class PaginationQuery
    {
        [Required]
        public int PageNumber { get; set; } = 1; // default to page 1

        [Required]
        public int PageSize { get; set; } = 10; // default to 10 items per page
    }
}
