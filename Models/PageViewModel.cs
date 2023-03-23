namespace MvcEFApp.Models
{
    public class PageViewModel
    {
        public int PageCurrent { set; get; }
        public int TotalPages { get; set; }
        public bool HasPrevPage => PageCurrent > 1;
        public bool HasNextPage => PageCurrent < TotalPages;

        public PageViewModel(int count, int pageCurrent, int pageSize)
        {
            PageCurrent = pageCurrent;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }
    }
}
