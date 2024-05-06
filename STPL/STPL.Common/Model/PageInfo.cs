using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STPL.Common.Model
{
    public class PageInfo
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int CurrentPageIndex { get; set; }
        public string? SearchValue { get; set; }
        public bool? IsOrderDescending { get; set; }
        public string? OrderColumn { get; set; }
    }
}
