using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wareship.ViewModel.Global
{
    public class PagingParameterModel
    {
        const int maxPageSize = 20;

        public int pageNumber { get; set; } = 1;

        public int _pageSize { get; set; } = 10;

        public int pageSize
        {

            get { return _pageSize; }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }

    public class PagingResponse
    {
        public int Page { get; set; }
        public int Limit { get; set; }
        public int TotalPage { get; set; }
        public int TotalRecord { get; set; }
    }
}
