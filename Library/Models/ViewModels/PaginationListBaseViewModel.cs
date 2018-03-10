using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.ViewModels
{
    public class PaginationListBaseViewModel<TItems>
    {
        public IEnumerable<TItems> Items { get; set; }
        public PagingInfo PagingInfo { get; set; }
        /* как сюда еще что-то воткнуть не понятно, хотя если нужно что-то добавить можно просто унаследоваться */
    }
}
