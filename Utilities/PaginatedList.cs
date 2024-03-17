using GolfClub.Models;
using Microsoft.EntityFrameworkCore;


namespace GolfClub.Utilities
{
    public class PaginatedList<T> : List<T>
    {
        
       
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }

        public bool HasPreviousPage => (PageIndex > 1);
        public bool HasNextPage => (PageIndex < TotalPages);
        /*
         * constructor that sets items that are to be used in the
         * pagination in a list
         */
        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            AddRange(items);
        }

        /*
         * method returns paginatedlist of items
         * depending on the number of items(source)
         * and the assigned pageSize
         * the pageIndex usally assigned the value of 1
         */
        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }

       
    }
}
