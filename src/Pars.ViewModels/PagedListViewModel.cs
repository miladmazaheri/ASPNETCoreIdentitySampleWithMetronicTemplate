using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cloudscribe.Web.Pagination;

namespace Pars.ViewModels
{
    public class PagedListViewModel<T>
    {
        public List<T> Items { get; set; }
        public PaginationSettings Paging { get; set; }
    }
}
