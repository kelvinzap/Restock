using Restock.Contracts.v1.Request;
using Restock.Models;

namespace Restock.Repositories;

public interface IProductRepository
{
    Task<bool> CreateProduct(ProductModel model);
    Task<bool> UpdateProduct(ProductModel model);
    Task<ProductModel?> GetProductById(string id);
    Task<bool> DeleteProduct(string id);
    Task<List<ProductModel>> GetAllProducts(PaginationFilter? paginationFilter = null);
}