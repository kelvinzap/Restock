using Restock.Contracts.v1.Request;
using Restock.Models;

namespace Restock.Repositories;

public interface IProductRepository
{
    bool CreateProduct(ProductModel model);
    bool UpdateProduct(string id, UpdateProductRequest model);
    ProductModel GetProduct(string id);
    bool DeleteProduct(string id);
    List<ProductModel> GetAllProducts();
}