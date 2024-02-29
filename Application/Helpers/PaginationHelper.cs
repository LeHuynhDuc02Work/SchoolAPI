namespace Application.Helpers
{
    public class PaginationHelper<T>
    {
        public ICollection<T> Paginate(IEnumerable<T> items, int page, int pageSize)
        {
            var totalItems = items.Count();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            var result = items
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return result;
        }
    }
}