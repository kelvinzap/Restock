using Microsoft.AspNetCore.WebUtilities;
using Restock.Contracts.v1.Request;

namespace Restock.Services;

public class UriService : IUriService
{
    private readonly string _baseUri;  
    public UriService(string baseUri)
    {
        _baseUri = baseUri;
    }
    public Uri GetProductUri(string productId)
    {
        return new Uri(_baseUri + "/products/" + productId);
    }

    public Uri GetAllProductsUri(PaginationQuery paginationQuery = null)
    {
        var uri = new Uri(_baseUri);

        if (paginationQuery is null)
        {
            return uri;
        }

        var modifiedUri = QueryHelpers.AddQueryString(_baseUri, "pageNumber", paginationQuery.PageNumber.ToString());
        modifiedUri = QueryHelpers.AddQueryString(modifiedUri, "pageSize", paginationQuery.PageSize.ToString());

        return new Uri(modifiedUri);
    }
}