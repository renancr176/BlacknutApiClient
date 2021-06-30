namespace BlacknutApiClient.Models.Responses
{
    public class PaginationResponse
    {
        /// <summary>
        /// Pagination data
        /// </summary>
        public PaginationData Meta { get; set; }
    }
    public class PaginationData
    {
        /// <summary>
        /// Number of element per page, default value set to 50.
        /// </summary>
        public int Limit { get; set; } = 50;
        /// <summary>
        /// Page number of the next page.
        /// </summary>
        public int Next { get; set; }
        /// <summary>
        /// Number of elements in the previous pages.
        /// </summary>
        public int Offset { get; set; }
        /// <summary>
        /// Current page number, default value set to 1 initial page.
        /// </summary>
        public int Page { get; set; } = 1;
        /// <summary>
        /// Page number of the previous page
        /// </summary>
        public int Prev { get; set; }
        /// <summary>
        /// Total count of elements
        /// </summary>
        public int Total { get; set; }
        /// <summary>
        /// Total count of pages
        /// </summary>
        public int TotalPages { get; set; }
    }
}