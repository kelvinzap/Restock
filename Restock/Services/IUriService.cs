using Restock.Contracts.v1.Request;

namespace Restock.Services;

public interface IUriService
{
    Uri GetProductUri(string ProductId);
    Uri GetAllProductsUri(PaginationQuery paginationQuery = null);
}