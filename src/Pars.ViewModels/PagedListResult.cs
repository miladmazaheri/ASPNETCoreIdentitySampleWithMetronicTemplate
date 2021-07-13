namespace Pars.ViewModels
{
    public class PagedListResult<T, TSearch>
    {
        public PagedListViewModel<T> PagedListViewModel { get; set; }

        public TSearch SearchViewModel { get; set; }
    }
}
