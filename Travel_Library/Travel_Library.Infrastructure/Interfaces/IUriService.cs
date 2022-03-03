using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel_Library.Core.QueryFilters;

namespace Travel_Library.Infrastructure.Interfaces
{
    public interface IUriService
    {     
        Uri GetPostPaginationUri(PostQueryFilter filter, string actionUrl);
    }
}
