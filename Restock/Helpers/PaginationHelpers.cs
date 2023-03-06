using Restock.Contracts.v1.Request;
using Restock.Contracts.v1.Response;
using Restock.Models;
using Restock.Services;

namespace Restock.Helpers;

public static class PaginationHelpers
{
    public static PagedResponse<T> CreatePaginatedResponse<T>(IUriService _uriService, PaginationFilter pagination, List<T> response)
    {
        //Creates the next page uri based on the current page
        var nextPage = pagination.PageNumber >= 1
            ? _uriService.GetAllProductsUri(new PaginationQuery(pagination.PageNumber + 1, pagination.PageSize)).ToString()
            : null;

        var previousPage = pagination.PageNumber -1 >= 1
            ? _uriService.GetAllProductsUri(new PaginationQuery(pagination.PageNumber - 1, pagination.PageSize)).ToString()
            : null;
            

        
        return new PagedResponse<T>
        {
            Data = response,
            PageNumber = pagination.PageNumber >=1 ? pagination.PageNumber : null,
            PageSize = pagination.PageSize >=1 ? pagination.PageSize : null,
            NextPage = response.Any() ? nextPage : null,
            PreviousPage = previousPage
        };
   
    }
}